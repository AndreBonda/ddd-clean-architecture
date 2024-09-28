using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public sealed class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                convertToProviderExpression: id => id.Value,
                convertFromProviderExpression: id => MenuId.Create(id));

        builder.Property(m => m.Name)
            .HasMaxLength(100);

        builder.Property(m => m.Description)
            .HasMaxLength(100);

        builder.OwnsOne(m => m.AverageRating);

        builder.Property(m => m.HostId)
            .HasConversion(
                id => id.Value,
                id => HostId.Create(id));
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(
            m => m.Sections,
            sBuilder =>
            {
                sBuilder.ToTable("MenuSections");

                sBuilder.WithOwner().HasForeignKey("MenuId");

                sBuilder.HasKey("Id", "MenuId");

                sBuilder.Property(s => s.Id)
                    .HasColumnName("MenuSectionId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        id => MenuSectionId.Create(id));

                sBuilder.Property("Name")
                    .HasMaxLength(100);
                sBuilder.Property("Description")
                    .HasMaxLength(100);

                sBuilder.OwnsMany(
                    s => s.Items,
                    iBuilder =>
                    {
                        iBuilder.ToTable("MenuItems");

                        iBuilder.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                        iBuilder.Property("Name")
                            .HasMaxLength(100);
                        iBuilder.Property("Description")
                            .HasMaxLength(100);

                        iBuilder.Property(i => i.Id)
                            .HasColumnName("MenuItemId")
                            .ValueGeneratedNever()
                            .HasConversion(
                                id => id.Value,
                                id => MenuItemId.Create(id));

                        iBuilder.HasKey("Id", "MenuSectionId", "MenuId");
                    });

                sBuilder.Navigation(s => s.Items).Metadata.SetField("_items");
                sBuilder.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

        // Useful to link Sections with the private property '_sections'
        builder.Metadata
            .FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(
            m => m.DinnerIds,
            dBuilder =>
            {
                dBuilder.ToTable("MenuDinnerIds");

                dBuilder
                    .WithOwner()
                    .HasForeignKey("MenuId");

                dBuilder.HasKey("Id");

                dBuilder.Property(d => d.Value)
                    .HasColumnName("DinnerId")
                    .ValueGeneratedNever();
            });

        builder.Metadata
            .FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(
            m => m.MenuReviewIds,
            rBuilder =>
            {
                rBuilder.ToTable("MenuReviewIds");

                rBuilder
                    .WithOwner()
                    .HasForeignKey("MenuId");

                rBuilder.HasKey("Id");

                rBuilder.Property(d => d.Value)
                    .HasColumnName("ReviewId")
                    .ValueGeneratedNever();
            });

        builder.Metadata
            .FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

}
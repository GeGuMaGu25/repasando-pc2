using si730pc2u202216448.Api.Heroes.Domain.Model.Aggregates;
using si730pc2u202216448.Api.Heroes.Domain.Model.ValueObjects;
using si730pc2u202216448.Api.Shared.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace si730pc2u202216448.Api.Heroes.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

/// <summary>
///     Model builder extensions for the Heroes bounded context.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Applies the Heroes bounded context persistence configuration.
    /// </summary>
    /// <param name="builder">
    ///     The model builder for the database context
    /// </param>
    public static void ApplyHeroesConfiguration(this ModelBuilder builder)
    {
        // Heroes Context

        builder.Entity<Hero>().HasKey(h => h.Id);
        builder.Entity<Hero>().Property(h => h.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Hero>().Property(h => h.HeroId)
            .HasConversion(heroId => heroId.Id, value => new HeroId(value))
            .IsRequired();

        builder.Entity<Hero>().OwnsOne(h => h.RegisterEmailAddress,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("RegisterEmailAddress")
                    .IsRequired()
                    .HasMaxLength(EmailAddress.MaxLength);
            });
        builder.Entity<Hero>().Navigation(h => h.RegisterEmailAddress).IsRequired();

        builder.Entity<Hero>().Property(h => h.HeroPlace).IsRequired().HasMaxLength(Hero.HeroPlaceMaxLength);
        builder.Entity<Hero>().Property(h => h.HeroCountry).IsRequired().HasMaxLength(Hero.HeroCountryMaxLength);
        builder.Entity<Hero>().Property(h => h.HeroContinent).IsRequired();
        builder.Entity<Hero>().Property(h => h.HeroAbility).IsRequired().HasMaxLength(Hero.HeroAbilityMaxLength);
        builder.Entity<Hero>().Property(h => h.RegisterDateAt).IsRequired();

        builder.Entity<Hero>()
            .HasIndex(h => new { h.HeroId, h.HeroPlace, h.HeroCountry, h.HeroContinent })
            .IsUnique();
    }
}

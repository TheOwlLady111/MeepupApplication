using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> entity)
        {
            entity.ToTable("Events");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.DateOfEvent).IsRequired().HasColumnType("datetime");

            entity.Property(e => e.Description).IsRequired().HasMaxLength(255);

            entity.Property(e => e.Name).IsRequired().HasMaxLength(150);

            entity.Property(e => e.Organizer).IsRequired().HasMaxLength(150);

            entity.Property(e => e.Place).IsRequired().HasMaxLength(100);

            entity.Property(e => e.Plan).IsRequired().HasMaxLength(255);

            entity.HasMany(d => d.Speakers)
                .WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "EventSpeaker",
                    l => l.HasOne<Speaker>().WithMany().HasForeignKey("SpeakerId"),
                    r => r.HasOne<Event>().WithMany().HasForeignKey("EventId"),
                    j =>
                    {
                        j.HasKey("EventId", "SpeakerId");

                        j.ToTable("EventSpeaker");
                    });
        }
    }
}

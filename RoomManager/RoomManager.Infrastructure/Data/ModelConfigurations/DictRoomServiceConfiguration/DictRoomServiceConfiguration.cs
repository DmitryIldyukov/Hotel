using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomManager.Domain.Entities.Dicts;

namespace RoomManager.Infrastructure.Data.Configurations.DictRoomServiceConfiguration;

public class DictRoomServiceConfiguration : IEntityTypeConfiguration<DictRoomService>
{
    public void Configure(EntityTypeBuilder<DictRoomService> builder)
    {
        builder.ToTable("dict_room_service", "dict");

        #region Comments

        builder.HasComment("Справочник удобств в номере");
        builder.Property(dict => dict.Name).HasComment("Название удобства");
        builder.Property(dict => dict.SerialNumber).HasComment("Порядковый номер для отображения");
        
        #endregion

        #region Required fields

        builder.Property(dict => dict.Name).IsRequired();

        #endregion

        builder.HasQueryFilter(dict => !dict.IsDeleted);
    }
}
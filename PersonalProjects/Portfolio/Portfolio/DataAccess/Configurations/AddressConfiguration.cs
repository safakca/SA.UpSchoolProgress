using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.DataAccess.Entities;

namespace Portfolio.DataAccess.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(nameof(Address));
        builder.HasKey(x => x.Id);


        Address[] addresses =
        {
            new() { Id=1, Phone="+90 555 666 777 88 99", Mail="test@hotmail.com", AddressDetail="TURKEY", Location="TURKEY"}
        };

        builder.HasData(addresses);
    }
}


 

using DM8.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM8EfCore
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("ADDRESS", "PERSON");
            builder.Property(p => p.AddresseId).HasColumnNameUpper("AddresseId").UseIdentityColumn();
            builder.Property(a=>a.Address1).HasColumnNameUpper("Address1").HasMaxLength(60).IsRequired();
            builder.Property(a => a.Address2).HasColumnNameUpper("Address2").HasMaxLength(60);
            builder.Property(a => a.City).HasColumnNameUpper("City").HasMaxLength(30).IsRequired();
            builder.Property(a => a.PostalCode).HasColumnNameUpper("PostalCode").HasMaxLength(15).IsRequired();

            builder.HasKey(p => p.AddresseId);
        }
    }

    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("PERSON", "PERSON");
            builder.Property(p => p.PersonId).HasColumnNameUpper("PersonId").UseIdentityColumn();
            builder.Property(p=>p.Name).HasColumnNameUpper("Name").HasMaxLength(50).IsRequired().HasComment("我是字段备注：姓名");
            builder.Property(p => p.Sex).HasColumnNameUpper("Sex").IsRequired();
            builder.Property(a => a.Email).HasColumnNameUpper("Email").HasMaxLength(50);
            builder.Property(a => a.Phone).HasColumnNameUpper("Phone").HasMaxLength(25);

            builder.HasKey(p => p.PersonId);

        }
    }

    public static class PropertyExtensions
    {
        public static PropertyBuilder<T> HasColumnNameUpper<T>(this PropertyBuilder<T> property, string columnName)

        {
            return property.HasColumnName(columnName.ToUpper());

        }
    }

 

}



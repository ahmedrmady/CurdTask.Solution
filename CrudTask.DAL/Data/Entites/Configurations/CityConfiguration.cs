﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using CrudTask.DAL.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace CrudTask.DAL.Data.Entites.Configurations
{
    public partial class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> entity)
        {
            entity.Property(e => e.CityId).HasColumnName("CityID");

            entity.Property(e => e.CityName)
                .IsRequired()
                .HasMaxLength(100);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<City> entity);
    }
}

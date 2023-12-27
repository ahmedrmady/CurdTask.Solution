﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using CrudTask.DAL.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace CrudTask.DAL.Data.Entites.Configurations
{
    public partial class VillageConfiguration : IEntityTypeConfiguration<Village>
    {
        public void Configure(EntityTypeBuilder<Village> entity)
        {
            entity.Property(e => e.VillageId).HasColumnName("VillageID");

            entity.Property(e => e.SubCityId).HasColumnName("SubCityID");

            entity.Property(e => e.VillageName)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.SubCity)
                .WithMany(p => p.Villages)
                .HasForeignKey(d => d.SubCityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Villages__SubCit__4D94879B");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Village> entity);
    }
}
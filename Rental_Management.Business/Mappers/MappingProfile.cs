using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Mappers
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
    using Rental_Management.Business.DTOs.Apartment;
    using Rental_Management.Business.DTOs.ApartmentBuilding;
    using Rental_Management.Business.DTOs.Landlord;
    using Rental_Management.Business.DTOs.Tenant;
    using Rental_Management.DataAccess.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Landlord, LandlordDTO>();
            CreateMap<AddLandlordDTO, Landlord>();
            CreateMap<UpdateLandlordDTO, Landlord>();

            CreateMap<Apartment,ApartmentDTO>();
            CreateMap<AddApartmentDTO, Apartment>();
            CreateMap<UpdateApartmentDTO, Apartment>();

            CreateMap<ApartmentBuilding, ApartmentBuildingDTO>();
            CreateMap<AddApartmentBuildingDTO, ApartmentBuilding>();
            CreateMap<UpdateApartmentBuildingDTO, ApartmentBuilding>();

            CreateMap<Tenant, TenantDTO>();
            CreateMap<AddTenantDTO, Tenant>();
            CreateMap<UpdateTenantDTO, Tenant>();

        }
    }

}

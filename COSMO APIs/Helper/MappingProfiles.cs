using AutoMapper;
using cosmo.repro;
using COSMO_APIs.DTOs;

namespace COSMO_APIs.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {

            CreateMap<Product, ProductTORetunDTO>()
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))

        .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name));


        }


    }
}

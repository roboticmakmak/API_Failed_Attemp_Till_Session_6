using AutoMapper;
using cosmo.core2.Entities;  // Ensure this points to where Product is defined
using COSMO_APIs.DTOs;
using Microsoft.Extensions.Configuration;

namespace COSMO_APIs.Helper
{
    public class ProductPictureUrlResolver : IValueResolver<product, ProductTORetunDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(product source, ProductTORetunDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["ApiBaseUrl"]}{source.PictureUrl}";
            }
            return null; // Return null if PictureUrl is empty
        }
    }
}

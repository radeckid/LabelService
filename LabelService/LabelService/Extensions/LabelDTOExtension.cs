using LabelPlatform.DTO;
using LabelService.Models;

namespace LabelService.Extensions
{
    public static class LabelDTOExtension
    {
        public static Address RetrieveAddress(this AddressDTO dto)
        {
            return new Address
            {
                Company = dto.Company,
                Name = dto.Name,
                Surname = dto.Surname,
                Street = dto.Street,
                HomeNo = dto.HomeNo,
                Zip = dto.Zip,
                City = dto.City,
                Country = dto.Country,
                Mobile = dto.Mobile,
                Email = dto.Email
            };
        }

        public static Features RetrieveFeatures(this FeaturesDTO dto)
        {
            return new Features
            {
                Currency = dto.Currency,
                Price = dto.Price,
                DeliveryIns = dto.DeliveryIns,
                Weight = dto.Weight
            };
        }
    }
}

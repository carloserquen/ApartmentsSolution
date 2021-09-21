using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Apartments.Application.Interfaces;

namespace Apartments.Application.features.apartments
{
    public class GetApartmentsByName
    {
        private readonly IApartmentRepository _ApartmentRepository;

        public GetApartmentsByName(IApartmentRepository apartmentRepository)
        {
            _ApartmentRepository = apartmentRepository;
        }
        public async Task<string> GetApartment(string Apartment, int Limit)
        {
            var response = await _ApartmentRepository.GetApartments(Apartment, Limit);


            return response;
        }
    }
}

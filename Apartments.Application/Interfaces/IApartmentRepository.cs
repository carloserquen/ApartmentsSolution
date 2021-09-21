using System;
using System.Collections.Generic;
using System.Net.Http;
using Apartments.Domain.Entities;
using System.Threading.Tasks;

namespace Apartments.Application.Interfaces
{
    public interface IApartmentRepository
    {
        Task<string> GetApartments(string Apartment, int Limit);
    }
}

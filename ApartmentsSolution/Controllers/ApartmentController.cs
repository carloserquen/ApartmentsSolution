using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using Apartments.Application.Interfaces;
using Apartments.Application.features.apartments;
using System.Threading.Tasks;

namespace Apartments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentRepository _IApartmentRepository;

        public ApartmentController(IApartmentRepository iapartmentRepository)
        {
            _IApartmentRepository = iapartmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetApartments(string Apartment, int Limit)
        {
            GetApartmentsByName getApartmentsByName = new GetApartmentsByName(_IApartmentRepository);

            if (Apartment != null)
            {
                try
                {
                    var result = getApartmentsByName.GetApartment(Apartment, Limit).Result;
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex);
                }
            }
            else return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}

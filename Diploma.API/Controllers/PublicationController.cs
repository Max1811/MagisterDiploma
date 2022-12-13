using Diploma.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class PublicationController : Controller
    {


        public PublicationController()
        {

        }

        [HttpPost]
        public async Task AddPublication(PublicationDto model)
        {

        }
    }
}

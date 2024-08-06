using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using training_stuff_api.Models;

namespace training_stuff_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly StuffTrainingPlatformContext context;

        public SectionController(StuffTrainingPlatformContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Section> GetSectionList()
        {
            return context.Section.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Micro.Interfaces.Log;
using Micro.Orchestrator.Dtos.Color;
using Micro.Orchestrator.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Micro.Orchestrator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : ControllerBase
    {
        private readonly EventManager eventManager;

        public ColorController(EventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        [HttpGet]
        [Authorize]
        [Route("")]
        public IEnumerable<Color> GetColors() 
        {
          //  eventManager.Fire(new LogEvent("GetColors Requested"));

            var colors = new List<Color> 
            {
                new Color { Name = "Red", Hex = "#FF0000"},    
                new Color { Name = "Green", Hex = "#00FF00"},    
                new Color { Name = "Red", Hex = "#0000FF"},    
            };

          //  eventManager.Fire(new LogEvent($"GetColors Response: {JsonConvert.SerializeObject(colors)}"));

            return colors;
        }
    }
}

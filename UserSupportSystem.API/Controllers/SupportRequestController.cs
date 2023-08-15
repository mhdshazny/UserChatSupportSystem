using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserSupportSystem.Common.Enums;
using UserSupportSystem.Data.DataEntities;
using UserSupportSystem.Data.DTO;
using UserSupportSystem.Data.Engines.Interfaces;

namespace UserSupportSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupportRequestController : ControllerBase
    {
        private readonly IRequestEngine _requestEngine;

        public SupportRequestController(IRequestEngine requestEngine)
        {
            _requestEngine = requestEngine;
        }
        // GET: SupportRequestController
        [HttpPost]
        public async Task<ActionResult<SupportRequestDTO>> RequestSupport()
        {
            return Ok(await _requestEngine.GetSupportRequestAsync());
        }
    }
}

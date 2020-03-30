using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testurl2.Models;
using testurl2.Services;

namespace testurl2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GtMetricsController : ControllerBase
    {
        private readonly IGtMetricsServices _gtService;
        public GtMetricsController(IGtMetricsServices gtMetrix)
        {
            _gtService = gtMetrix;
        }


        // GET: api/GtMetrics
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GtMetrics/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GtMetrics
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string url, int id)
        {
            try
            {
                GtMetrics results = await Task.Run(() =>
                {
                    return _gtService.PostTest(url, id);

                });
                if (results != null)
                    return Ok(results.Id);
                return NotFound(results.Error);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PostURL", ex.Message);
                return BadRequest(ModelState);
            }


        }

        // PUT: api/GtMetrics/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

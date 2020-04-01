using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testurl3.Models;
using testurl3.Services;

namespace testurl3.Controllers
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
        public IActionResult Get()
        {
            try
            {
                var gtMetrics = _gtService.GetAll();
                if (gtMetrics == null) return NotFound();
                return Ok(gtMetrics);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllMetrics", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET: api/GtMetrics/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var gtmetric = _gtService.Get(id);
                if (gtmetric == null) return NotFound();

                return Ok(gtmetric);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetMetricById", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST: api/GtMetrics/5
        [HttpPost("{id}")]
        public async Task<IActionResult> Post([FromBody] string url, int companyId)
        {
            try
            {
                GtMetrics results = await Task.Run(() =>
                {
                    return _gtService.PostTest(url, companyId);

                });
                if (results != null)
                    return Ok(results.Id);
                return NotFound(results.Error);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PostURL", ex.Message);
                ModelState.AddModelError("PostURLStackTrace", ex.StackTrace);
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
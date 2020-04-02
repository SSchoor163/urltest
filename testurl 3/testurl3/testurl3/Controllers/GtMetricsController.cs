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
        [HttpPost]
        public async Task<IActionResult> Post(GtMetricsToApi metric)
        {
            try
            {
                GtMetrics results = await Task.Run(() =>
                {
                    return _gtService.Test(metric.Url, metric.CompanyId);

                });
                if(results==null)
                    return NotFound(results.Error);
                var AddMetric = _gtService.Add(results);
                return Ok(results.Id);
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PostURL", ex.Message);
                ModelState.AddModelError("PostURLStackTrace", ex.StackTrace);
                return BadRequest(ModelState);
            }


        }

     // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var metric = _gtService.Get(id);
                if (metric == null) return NotFound();
                _gtService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("RemoveGtMetric", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
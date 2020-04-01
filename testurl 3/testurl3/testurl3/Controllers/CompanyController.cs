using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testurl3.Models;
using testurl3.Services;

namespace testurl3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyServices _companyServices;
        //CompanyController(ICompanyServices companyServices)
        //{
        //    _companyServices = companyServices;
        //}

        public CompanyController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        // GET: api/Company
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var companies = _companyServices.GetAll();
                if (companies == null) return NotFound();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllCompanies", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var company = _companyServices.Get(id);
                if (company == null) return NotFound();

                return Ok(company);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetCompanyById", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST: api/Company
        [HttpPost]
        public IActionResult Post([FromBody] Company company)
        {
            try
            {
                var Company = _companyServices.Add(company);
                return Ok(Company);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PostCompany", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Company company)
        {
            try
            {
                company.Id = id;
                var Company = _companyServices.Update(company);
                if (Company == null) return NotFound();
                return Ok(Company);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateCompany", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Company = _companyServices.Get(id);
                if (Company == null) return NotFound();
                _companyServices.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("RemoveCompany", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}

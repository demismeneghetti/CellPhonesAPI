using CellPhonesAPI.Models;
using CellPhonesAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CellPhonesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CellPhonesController : ControllerBase
    {
        private readonly CellPhoneService _cellPhoneService;

        public CellPhonesController(CellPhoneService cellPhoneService)
        {
            _cellPhoneService = cellPhoneService;
        }

        [HttpGet]
        public ActionResult<List<CellPhone>> Get()
        {
            return _cellPhoneService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetCellPhone")]
        [Route("/{id}")]
        public ActionResult<CellPhone> Get(string id)
        {
            var cellPhone = _cellPhoneService.Get(id);

            if (cellPhone == null)
            {
                return NotFound();
            }
            return cellPhone;
        }

        [HttpPost]
        public ActionResult<CellPhone> Create(CellPhone cellPhone)
        {
            _cellPhoneService.Create(cellPhone);

            return CreatedAtRoute("GetCellPhone", new { id = cellPhone.Id.ToString() }, cellPhone);
        }

        [HttpPut("{id:length(24)}")]
        [Route("Update/{id}")]
        public IActionResult Update(string id, CellPhone cellPhoneIn)
        {
            var cellPhone = _cellPhoneService.Get(id);

            if (cellPhone == null)
            {
                return NotFound();
            }

            _cellPhoneService.Update(id, cellPhoneIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [Route("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var cellPhone = _cellPhoneService.Get(id);

            if (cellPhone == null)
            {
                return NotFound();
            }

            _cellPhoneService.Remove(cellPhone.Id);

            return NoContent();
        }
    }
}
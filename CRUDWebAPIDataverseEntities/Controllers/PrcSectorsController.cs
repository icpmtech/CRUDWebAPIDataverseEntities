using CRUDWebAPIDataverseEntities.Entities;
using CRUDWebAPIDataverseEntities.Services.Dataverse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace DataverseWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrcSectorsController : ControllerBase
    {
        private readonly IDataversePrcSectorsService _dataverseService;

        public PrcSectorsController(IDataversePrcSectorsService dataverseService)
        {
            _dataverseService = dataverseService;
        }

        // GET: api/PrcSectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrcSector>>> GetPrcSectors()
        {
            var PrcSectors = await _dataverseService.GetPrcSectorsAsync();
            return Ok(PrcSectors);
        }

        // GET: api/PrcSectors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PrcSector>> GetStudent(Guid id)
        {
            var student = await _dataverseService.GetPrcSectorAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // POST: api/PrcSectors
        [HttpPost]
        public async Task<ActionResult<PrcSector>> CreateStudent(PrcSector prcSector)
        {
            var id = await _dataverseService.CreatePrcSectorAsync(prcSector);
            prcSector.Id = id;

            return CreatedAtAction(nameof(GetStudent), new { id = prcSector.Id }, prcSector);
        }

        // PUT: api/PrcSectors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, PrcSector prcSector)
        {
            if (id != prcSector.Id)
            {
                return BadRequest();
            }

            await _dataverseService.UpdatePrcSectorAsync(prcSector);

            return NoContent();
        }

        // DELETE: api/PrcSectors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            await _dataverseService.DeletePrcSectorAsync(id);

            return NoContent();
        }
    }
}

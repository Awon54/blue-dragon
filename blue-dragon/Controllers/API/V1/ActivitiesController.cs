using AutoMapper;
using blue_dragon.Dto.V1;
using blue_dragon.Models.V1;
using blue_dragon.Service.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blue_dragon.Controllers.API.V1
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IActivityService _activityService;



        public ActivitiesController(IActivityService activityService, IMapper mapper)
        {
            this._mapper = mapper;
            this._activityService = activityService;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            return Ok(await _activityService.GetAllActivity());
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {

            var activity = await _activityService.GetActivityById(id);

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // Patch status: api/Activities/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchActivityStatus(int id, [FromBody] PatchActivityStatusRequest patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var activityFromDb = await _activityService.GetActivityById(id);
            if (activityFromDb == null)
            {
                return NotFound();
            }

            try
            {
                await _activityService.UpdateActivityStatus(activityFromDb, patchDoc.Status);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }


        // POST: api/Activities
        [HttpPost]
        public async Task<ActionResult<Activity>> PostActivity(ActivityRequest activityDto)


        {
            Activity activity = _mapper.Map<Activity>(activityDto);

            activity = await _activityService.CreateActivity(activity);

            return CreatedAtAction("GetActivity", new { id = activity.Id }, activity);
        }


    }
}

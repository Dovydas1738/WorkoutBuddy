using Microsoft.AspNetCore.Mvc;
using WorkoutBuddy.Core.Contracts;
using WorkoutBuddy.Core.Models;
using WorkoutBuddy.Api.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.BearerToken;

namespace WorkoutBuddy.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutTemplateController : ControllerBase
    {
        private readonly IWorkoutTemplateService _workoutTemplateService;
        private readonly IExerciseService _exerciseService;

        public WorkoutTemplateController(IWorkoutTemplateService workoutTemplateService, IExerciseService exerciseService)
        {
            _workoutTemplateService = workoutTemplateService;
            _exerciseService = exerciseService;
        }

        [Authorize]
        [HttpPost("workouttemplates/create")]
        public async Task<IActionResult> CreateWorkoutTemplate([FromBody] CreateWorkoutTemplateRequest request)
        {
            try
            {
                var userId = User.FindFirst("UserId")?.Value;

                if (userId == null)
                {
                    return Unauthorized(new {Message = "User not authenticated."});
                }

                var template = new WorkoutTemplate
                {
                    WorkoutName = request.WorkoutName,
                    UserId = int.Parse(userId),
                    Exercises = request.Exercises.Select(e => new Exercise
                    {
                        Name = e.Name,
                        Sets = e.Sets,
                        MinReps = e.MinReps,
                        MaxReps = e.MaxReps,
                        Weight = e.Weight,
                        CurrentReps = e.CurrentReps,
                    }).ToList()
                };

                await _workoutTemplateService.AddWorkoutTemplateAsync(template);
                return Ok(new {Message = "Template successfully created."});
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        //[HttpGet("workouttemplates/gettemplates")]
        //public async Task<IActionResult> GetAllWorkoutTemplates()
        //{
        //    try
        //    {
        //        var templates = await _workoutTemplateService.GetAllWorkoutTemplatesAsync();
        //        return Ok(templates);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem(detail: ex.Message);
        //    }
        //}

        //[HttpGet("workouttemplates/{id}")]
        //public async Task<IActionResult> GetWorkoutTemplateById(int id)
        //{
        //    try
        //    {
        //        var template = await _workoutTemplateService.GetWorkoutTemplateByIdAsync(id);
        //        if (template == null)
        //        {
        //            return Conflict(new { Message = "Template not found." });
        //        }
        //        return Ok(template);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem(detail: ex.Message);
        //    }
        //}

        //[HttpPut("workouttemplates/{id}")]
        //public async Task<IActionResult> UpdateWorkoutTemplate(int id, [FromBody] WorkoutTemplate updatedTemplate)
        //{
        //    try
        //    {
        //        var result = await _workoutTemplateService.UpdateWorkoutTemplateAsync();

        //        if (!result)
        //        {
        //            return Conflict(new { Message = "Template not found." });
        //        }
        //        return NoContent(new { Message = "Template successfully updated " + result });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem(detail: ex.Message);
        //    }
        //}
    }
}

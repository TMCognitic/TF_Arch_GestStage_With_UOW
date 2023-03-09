using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using TF_Arch_GestStage_With_UOW.Api.Models;
using TF_Arch_GestStage_With_UOW.Dal.Entities;
using TF_Arch_GestStage_With_UOW.Dal.Repositories;

namespace TF_Arch_GestStage_With_UOW.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StageController : ControllerBase
    {
        private readonly IGestStage_UnitOfWork _uow;

        public StageController(IGestStage_UnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IActionResult Get()
        {
            using (_uow)
            {
                try
                {
                    IEnumerable<Stage> stages = _uow.StageRepository.Get().ToList();
                    return Ok(stages);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { Message = ex.Message });
                }
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (_uow)
            {
                try
                {
                    Stage? stages = _uow.StageRepository.Get(id);

                    if(stages is null)
                        return NotFound();

                    return Ok(stages);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { Message = ex.Message });
                }
            }
        }

        [HttpPost]
        public IActionResult Create(CreeStageForm form)
        {
            using (_uow)
            {
                try
                {
                    _uow.StageRepository.Add(new Stage() { Titre = form.Titre });
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(new { Message = ex.Message });
                }
            }
        }
    }
}

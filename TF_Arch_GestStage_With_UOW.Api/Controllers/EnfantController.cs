using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TF_Arch_GestStage_With_UOW.Api.Models;
using TF_Arch_GestStage_With_UOW.Dal.Entities;
using TF_Arch_GestStage_With_UOW.Dal.Repositories;

namespace TF_Arch_GestStage_With_UOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfantController : ControllerBase
    {
        private readonly IGestStage_UnitOfWork _uow;

        public EnfantController(IGestStage_UnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("bystage/{stageId}")]
        public IActionResult GetByStage(int stageId)
        {
            try
            {
                using (_uow)
                {
                    IEnumerable<Enfant> enfants = _uow.EnfantRepository.Get(stageId).ToList();

                    return Ok(enfants);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult AjoutNouvelEnfantAvecStage(CreeEnfantAvecStageForm form)
        {
            using (_uow)
            {
                try
                {

                    Enfant enfant = new Enfant() { Nom = form.Nom, Prenom = form.Prenom };
                    _uow.EnfantRepository.Add(enfant, form.StageId);
                    _uow.Commit();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    _uow.Rollback();
                    return StatusCode(400, new { message = ex.Message });
                }
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TF_Arch_GestStage_With_UOW.Models.Entities;
using TF_Arch_GestStage_With_UOW.Models.Forms;
using TF_Arch_GestStage_With_UOW.Models.Repositories;

namespace TF_Arch_GestStage_With_UOW.Controllers
{
    public class StageController : Controller
    {
        private readonly IStageRepository _stageRepository;
        private readonly IEnfantRepository _enfantRepository;
        private readonly ILogger _logger;

        public StageController(ILogger<StageController> logger, IStageRepository repository, IEnfantRepository enfantRepository)
        {
            _enfantRepository = enfantRepository;
            _logger = logger;
            _stageRepository = repository;
        }

        public IActionResult Index()
        {
            return View(_stageRepository.Get());
        }

        public IActionResult Details(int id)
        {
            try
            {
                Stage stage = _stageRepository.Get(id);
                IEnumerable<Enfant>? enfants = _enfantRepository.Get(id);
                return View(new DisplayStageDetails() { Id = stage.Id, Titre = stage.Titre, Enfants = enfants ?? new Enfant[0] });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
            

        }
    }
}

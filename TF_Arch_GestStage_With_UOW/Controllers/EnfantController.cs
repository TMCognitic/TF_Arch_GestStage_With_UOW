using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TF_Arch_GestStage_With_UOW.Models.Entities;
using TF_Arch_GestStage_With_UOW.Models.Forms;
using TF_Arch_GestStage_With_UOW.Models.Repositories;

namespace TF_Arch_GestStage_With_UOW.Controllers
{
    public class EnfantController : Controller
    {
        private readonly IStageRepository _stageRepository;
        private readonly IEnfantRepository _enfantRepository;
        private readonly ILogger _logger;

        public EnfantController(ILogger<StageController> logger, IStageRepository repository, IEnfantRepository enfantRepository)
        {
            _enfantRepository = enfantRepository;
            _logger = logger;
            _stageRepository = repository;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Inscription");
        }

        public IActionResult Inscription()
        {
            IEnumerable<Stage> stages = _stageRepository.Get()!;
            return View(new InscriptionForm() { Stages = stages });
        }

        [HttpPost]
        public IActionResult Inscription(InscriptionForm form)
        {
            if(!ModelState.IsValid)
            {
                form.Stages = _stageRepository.Get();
                return View(form);
            }

            if(form.StageId == 0)
            {
                ModelState.AddModelError("StageId", "Veuillez sélectionner un stage.");
                form.Stages = _stageRepository.Get();
                return View(form);
            }

            _enfantRepository.Add(new Enfant() { Nom = form.Nom, Prenom = form.Prenom }, form.StageId);

            return RedirectToAction("Details", "Stage", new { id = form.StageId });
        }
    }
}

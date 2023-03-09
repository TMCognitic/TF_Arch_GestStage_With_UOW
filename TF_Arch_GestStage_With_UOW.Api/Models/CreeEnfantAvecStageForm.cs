using System.ComponentModel.DataAnnotations;

namespace TF_Arch_GestStage_With_UOW.Api.Models
{
#nullable disable
    public class CreeEnfantAvecStageForm
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        public int StageId { get; set; }
    }
}

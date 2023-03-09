using System.ComponentModel.DataAnnotations;
using TF_Arch_GestStage_With_UOW.Models.Entities;

namespace TF_Arch_GestStage_With_UOW.Models.Forms
{
#nullable disable
    public class InscriptionForm
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        public int StageId { get; set; }

        public IEnumerable<Stage> Stages { get; set; }
    }
}

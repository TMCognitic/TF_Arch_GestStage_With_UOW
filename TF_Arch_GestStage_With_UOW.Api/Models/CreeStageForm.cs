using System.ComponentModel.DataAnnotations;

namespace TF_Arch_GestStage_With_UOW.Api.Models
{
#nullable disable
    public class CreeStageForm
    {
        [Required]
        public string Titre { get; set; }
    }
}

using TF_Arch_GestStage_With_UOW.Models.Entities;

namespace TF_Arch_GestStage_With_UOW.Models.Forms
{
#nullable disable
    public class DisplayStageDetails
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public IEnumerable<Enfant> Enfants { get; set; }
    }
}

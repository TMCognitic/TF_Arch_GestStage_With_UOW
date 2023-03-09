using TF_Arch_GestStage_With_UOW.Models.Entities;

namespace TF_Arch_GestStage_With_UOW.Models.Repositories
{
    public interface IEnfantRepository
    {
        IEnumerable<Enfant>? Get(int stageId);
        void Add(Enfant enfant, int stageId);
    }
}

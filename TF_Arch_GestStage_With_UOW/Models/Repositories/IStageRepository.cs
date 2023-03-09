using TF_Arch_GestStage_With_UOW.Models.Entities;

namespace TF_Arch_GestStage_With_UOW.Models.Repositories
{
    public interface IStageRepository
    {
        public IEnumerable<Stage>? Get();
        public Stage Get(int id);
    }
}

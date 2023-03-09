using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Arch_GestStage_With_UOW.Dal.Entities;

namespace TF_Arch_GestStage_With_UOW.Dal.Repositories
{
    public interface IStageRepository
    {
        void Add(Stage stage);
        IEnumerable<Stage> Get();
        Stage? Get(int id);
    }
}

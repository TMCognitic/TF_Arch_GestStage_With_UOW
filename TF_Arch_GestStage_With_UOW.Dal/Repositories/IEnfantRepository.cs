using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Arch_GestStage_With_UOW.Dal.Entities;

namespace TF_Arch_GestStage_With_UOW.Dal.Repositories
{
    public interface IEnfantRepository
    {
        void Add(Enfant enfant, int stageId);
        IEnumerable<Enfant> Get(int stageId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Arch_GestStage_With_UOW.Tools.Uow;

namespace TF_Arch_GestStage_With_UOW.Dal.Repositories
{
    public interface IGestStage_UnitOfWork : IUnitOfWork
    {
        IEnfantRepository EnfantRepository { get; }
        IStageRepository StageRepository { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_Arch_GestStage_With_UOW.Tools.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        void Rollback();
    }
}

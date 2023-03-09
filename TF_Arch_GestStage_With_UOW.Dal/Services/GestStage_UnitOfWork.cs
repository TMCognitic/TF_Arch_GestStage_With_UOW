using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Arch_GestStage_With_UOW.Dal.Repositories;
using TF_Arch_GestStage_With_UOW.Tools.Uow;

namespace TF_Arch_GestStage_With_UOW.Dal.Services
{
    public class GestStage_UnitOfWork : UnitOfWork, IGestStage_UnitOfWork
    {
        public GestStage_UnitOfWork(DbProviderFactory factory, string connectionString) 
            : base(factory, connectionString)
        {
            
        }

        public IEnfantRepository EnfantRepository
        {
            get
            {
                return new EnfantRepository(Transaction);
            }
        }

        public IStageRepository StageRepository
        {
            get
            {
                return new StageRepository(Transaction);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Arch_GestStage_With_UOW.Dal.Entities;
using TF_Arch_GestStage_With_UOW.Dal.Mappers;
using TF_Arch_GestStage_With_UOW.Dal.Repositories;
using TF_Arch_GestStage_With_UOW.Tools.Connections;

namespace TF_Arch_GestStage_With_UOW.Dal.Services
{
    internal class EnfantRepository : IEnfantRepository
    {
        private readonly DbTransaction _transaction;

        public EnfantRepository(DbTransaction transaction)
        {
            _transaction = transaction;
        }

        public void Add(Enfant enfant, int stageId)
        {
            DbConnection? connection = _transaction.Connection;

            if (connection is null) 
            {
                throw new NullReferenceException("La connection de la trasaction est null");
            }

            int enfantId = (int)connection.ExecuteScalar("INSERT INTO Enfant (Nom, Prenom) OUTPUT INSERTED.Id VALUES(@Nom, @Prenom)", false, new { enfant.Nom, enfant.Prenom }, _transaction)!;
            int rows = connection.ExecuteNonQuery("INSERT INTO Inscription (EnfantId, StageId) VALUES (@EnfantId, @StageId)", false, new { EnfantId = enfantId, StageId = stageId }, _transaction);
        }

        public IEnumerable<Enfant> Get(int stageId)
        {
            DbConnection connection = _transaction.Connection!;

            if (connection is null)
            {
                throw new NullReferenceException("La connection de la trasaction est null");
            }

            return connection.ExecuteReader("SELECT E.Id, E.Nom, E.Prenom FROM Enfant AS E JOIN INSCRIPTION AS I ON E.Id = I.EnfantId Where I.StageId = @StageId;", false, (dr) => dr.ToEnfant(), new { StageId = stageId }, _transaction);
        }
    }
}

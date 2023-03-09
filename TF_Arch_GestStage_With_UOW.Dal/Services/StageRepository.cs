using System.Data.Common;
using TF_Arch_GestStage_With_UOW.Dal.Entities;
using TF_Arch_GestStage_With_UOW.Dal.Mappers;
using TF_Arch_GestStage_With_UOW.Dal.Repositories;
using TF_Arch_GestStage_With_UOW.Tools.Connections;

namespace TF_Arch_GestStage_With_UOW.Dal.Services
{
    internal class StageRepository : IStageRepository
    {
        private readonly DbTransaction _transaction;

        public StageRepository(DbTransaction transaction)
        {
            _transaction = transaction;
        }

        public void Add(Stage stage)
        {
            DbConnection? connection = _transaction.Connection;

            if (connection is null)
            {
                throw new NullReferenceException("La connection de la trasaction est null");
            }

            connection.ExecuteNonQuery("INSERT INTO Stage (Titre) VALUES (@Titre);", false, new { stage.Titre }, _transaction);
        }

        public IEnumerable<Stage> Get()
        {
            DbConnection? connection = _transaction.Connection;

            if (connection is null)
            {
                throw new NullReferenceException("La connection de la trasaction est null");
            }

            return connection.ExecuteReader("SELECT Id, Titre FROM Stage", false, (dr) => dr.ToStage(), null, _transaction);
        }

        public Stage? Get(int id)
        {
            DbConnection? connection = _transaction.Connection;

            if (connection is null)
            {
                throw new NullReferenceException("La connection de la trasaction est null");
            }

            return connection.ExecuteReader("SELECT Id, Titre FROM Stage WHERE Id = @Id", false, (dr) => dr.ToStage(), new { Id = id }, _transaction).SingleOrDefault();
        }
    }
}

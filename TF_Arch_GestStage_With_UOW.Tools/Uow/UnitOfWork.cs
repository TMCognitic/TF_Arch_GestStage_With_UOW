using System.Data.Common;
using System.Diagnostics;
using System.Net;

namespace TF_Arch_GestStage_With_UOW.Tools.Uow
{
    public abstract class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbConnection? _conn;
        private DbTransaction? _transaction;
        private DbProviderFactory _factory;

        public UnitOfWork(DbProviderFactory factory, string connectionString)
        {
            try
            {
                _factory = factory;
                _conn = _factory.CreateConnection();
                if (_conn is null)
                    throw new InvalidOperationException("The connection created by factory is null.");

                _conn.ConnectionString = connectionString;
                _conn.Open();
                _transaction = _conn.BeginTransaction();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

        }

        protected DbTransaction Transaction
        {
            get { return _transaction!; }
        }

        public void Rollback()
        {

            try
            {
                _transaction!.Rollback();

            }
            catch
            {
                Debug.WriteLine("error on rollback");
            }
            finally
            {
                _transaction!.Dispose();
                _transaction = _conn!.BeginTransaction();
            }

        }



        public bool Commit()
        {
            bool isOk = false;
            try
            {
                _transaction!.Commit();
                isOk = true;
            }
            catch
            {
                _transaction!.Rollback();
            }
            finally
            {
                _transaction!.Dispose();
                _transaction = _conn!.BeginTransaction();
            }
            return isOk;
        }



        public void Dispose()
        {
            if (_transaction != null)
            {
                Commit();
                _transaction.Dispose();
                _transaction = null;
            }

            if (_conn != null)
            {
                _conn.Dispose();
                _conn = null;
            }
        }
    }
}

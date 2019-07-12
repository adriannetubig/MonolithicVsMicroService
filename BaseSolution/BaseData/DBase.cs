﻿using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BaseData
{
    public abstract class DBase
    {
        private IDbConnection _iDbConnection => new SqlConnection(_connectionString);
        protected string _connectionString { get; }
        public DBase(string connectionString)
        {
            _connectionString = connectionString;
        }


        protected async Task Query(DynamicParameters parameters, string storedProcedure)
        {
            using (IDbConnection dbConnection = _iDbConnection)
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();

                var result = await dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                result.ToList();
            }
        }

        protected async Task<int> QueryIdentity(DynamicParameters parameters, string storedProcedure, string outputParameter)
        {
            using (IDbConnection dbConnection = _iDbConnection)
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();

                var result = await dbConnection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>(outputParameter);
            }
        }

        protected async Task<T> QueryModel<T>(DynamicParameters parameters, string storedProcedure) where T : class
        {
            using (IDbConnection dbConnection = _iDbConnection)
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();

                var result = await dbConnection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        protected async Task<List<T>> QueryList<T>(DynamicParameters parameters, string storedProcedure) where T : class
        {
            using (IDbConnection dbConnection = _iDbConnection)
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();

                var result = await dbConnection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}

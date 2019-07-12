using BaseData;
using Dapper;
using MonolithicMvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonolithicMvc.Helper
{
    public class DataService : DBase, IDataService
    {
        public DataService(string connectionString) : base(connectionString) { }

        public async Task Create(Login login, int createdBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Username", login.Username);
            parameter.Add("@Password", login.Password);
            parameter.Add("@CreatedBy", createdBy);

            await Query(parameter, "[dbo].[LoginCreate]");
        }

        public async Task Read()
        {
            DynamicParameters parameter = new DynamicParameters();
            await QueryModel<List<Login>>(parameter, "[dbo].[LoginReadActive]");
        }

        public async Task Read(int loginId)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@LoginId", loginId);
            await QueryModel<Login>(parameter, "[dbo].[LoginRead]");
        }

        public async Task Update(Login login, int updatedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@LoginId", login.LoginId);
            parameter.Add("@Password", login.Password);
            parameter.Add("@UpdatedBy", updatedBy);

            await Query(parameter, "[dbo].[LoginUpdate]");
        }

        public async Task Delete(Login login, int updatedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@LoginId", login.LoginId);
            parameter.Add("@Password", login.Password);
            parameter.Add("@UpdatedBy", updatedBy);

            await Query(parameter, "[dbo].[LoginDelete]");
        }
    }
}

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

        public async Task LoginsCreate(Login login, int createdBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Username", login.Username);
            parameter.Add("@Password", login.Password);
            parameter.Add("@CreatedBy", createdBy);

            await Query(parameter, "[dbo].[LoginCreate]");
        }

        public async Task<List<Login>> LoginsRead()
        {
            DynamicParameters parameter = new DynamicParameters();
            return await QueryList<Login>(parameter, "[dbo].[LoginReadActive]");
        }

        public async Task<Login> LoginsRead(int loginId)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@LoginId", loginId);
            return await QueryModel<Login>(parameter, "[dbo].[LoginRead]");
        }

        public async Task<Login> LoginsRead(string username)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Username", username);
            return await QueryModel<Login>(parameter, "[dbo].[LoginReadByUsername]");
        }

        public async Task LoginsUpdate(Login login, int updatedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@LoginId", login.LoginId);
            parameter.Add("@Password", login.Password);
            parameter.Add("@UpdatedBy", updatedBy);

            await Query(parameter, "[dbo].[LoginUpdate]");
        }

        public async Task LoginsDelete(int loginId, int deletedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@LoginId", loginId); ;
            parameter.Add("@DeletedBy", deletedBy);

            await Query(parameter, "[dbo].[LoginDelete]");
        }
    }
}

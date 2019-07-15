using BaseData;
using CredentialData.Interfaces;
using CredentialEntity;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CredentialData.Services
{
    public class DLogins : DBase, IDLogins
    {
        public DLogins(string connectionString) : base(connectionString) { }

        public async Task Create(ELogin login, int createdBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Username", login.Username);
            parameter.Add("@Password", login.Password);
            parameter.Add("@CreatedBy", createdBy);

            await Query(parameter, "[dbo].[LoginCreate]");
        }

        public async Task<List<ELogin>> Read()
        {
            DynamicParameters parameter = new DynamicParameters();
            return await QueryList<ELogin>(parameter, "[dbo].[LoginReadActive]");
        }

        public async Task<ELogin> Read(int loginId)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@LoginId", loginId);
            return await QueryModel<ELogin>(parameter, "[dbo].[LoginRead]");
        }

        public async Task<ELogin> Read(string username)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Username", username);
            return await QueryModel<ELogin>(parameter, "[dbo].[LoginReadByUsername]");
        }

        public async Task Update(ELogin login, int updatedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@LoginId", login.LoginId);
            parameter.Add("@Password", login.Password);
            parameter.Add("@UpdatedBy", updatedBy);

            await Query(parameter, "[dbo].[LoginUpdate]");
        }

        public async Task Delete(int loginId, int deletedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@LoginId", loginId); ;
            parameter.Add("@DeletedBy", deletedBy);

            await Query(parameter, "[dbo].[LoginDelete]");
        }
    }
}

﻿using CredentialBusiness.Interfaces;
using CredentialData.Interfaces;
using CredentialEntity;
using CredentialModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredentialBusiness.Services
{
    public class BLogin: IBLogin
    {
        private readonly IDLogin _iDLogin; 
        public BLogin(IDLogin iDLogin)
        {
            _iDLogin = iDLogin;
        }

        public async Task Create(Login login, int createdBy)
        {
            login.Password = BCrypt.Net.BCrypt.HashPassword(login.Password);
            await _iDLogin.Create(ELogin(login), createdBy);
        }

        public async Task<List<Login>> Read()
        {
            var eLogins = await _iDLogin.Read();
            return Logins(eLogins);
        }

        public async Task<Login> Read(int loginId)
        {
            var eLogin = await _iDLogin.Read(loginId);
            return Login(eLogin);
        }

        public async Task<Login> Read(Login login)
        {
            var eLogin = await _iDLogin.Read(login.Username);
            if (BCrypt.Net.BCrypt.Verify(login.Password, eLogin.Password))
                return Login(eLogin);
            else
                return null;
        }

        public async Task Update(Login login, int updatedBy)
        {
            //Make sure that only the password is changed
            var eLogin = await _iDLogin.Read(login.LoginId);
            eLogin.Password = BCrypt.Net.BCrypt.HashPassword(login.Password);

            await _iDLogin.Update(ELogin(login), updatedBy);
        }

        public async Task Delete(int loginId, int deletedBy)
        {
            await _iDLogin.Delete(loginId, deletedBy);
        }

        private ELogin ELogin(Login login)
        {
            return new ELogin
            {
                CreatedDate = login.CreatedDate,
                DeletedDate = login.DeletedDate,
                UpdatedDate = login.UpdatedDate,

                CreatedBy = login.CreatedBy,
                DeletedBy = login.DeletedBy,
                LoginId = login.LoginId,
                UpdatedBy = login.UpdatedBy,

                Password = login.Password,
                Username = login.Username,
            };
        }

        private Login Login(ELogin eLogin)
        {
            return new Login
            {
                CreatedDate = eLogin.CreatedDate,
                DeletedDate = eLogin.DeletedDate,
                UpdatedDate = eLogin.UpdatedDate,

                CreatedBy = eLogin.CreatedBy,
                DeletedBy = eLogin.DeletedBy,
                LoginId = eLogin.LoginId,
                UpdatedBy = eLogin.UpdatedBy,

                Password = eLogin.Password,
                Username = eLogin.Username,
            };
        }

        private List<Login> Logins(List<ELogin> eLogins)
        {
            return eLogins.Select(a => new Login
            {
                CreatedDate = a.CreatedDate,
                DeletedDate = a.DeletedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                DeletedBy = a.DeletedBy,
                LoginId = a.LoginId,
                UpdatedBy = a.UpdatedBy,

                Password = a.Password,
                Username = a.Username,
            }).ToList();
        }
    }
}

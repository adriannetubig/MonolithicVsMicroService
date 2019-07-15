using BaseModel;
using CredentialBusiness.Interfaces;
using CredentialModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CredentialBusiness.Services
{
    public class BAuthentications : IBAuthentications
    {
        public JwtTokenValidation _jwtTokenValidation;
        public JwtTokenSettings _jwtTokenSettings;
        public BAuthentications(JwtTokenSettings jwtTokenSettings, JwtTokenValidation jwtTokenValidation)
        {
            _jwtTokenValidation = jwtTokenValidation;
            _jwtTokenSettings = jwtTokenSettings;
        }
        public Authentication Create(Login login)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenValidation.IssuerSigningKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.NameIdentifier, login.LoginId.ToString()),
                new Claim(ClaimTypes.Role, "Manager")
            };

            var authentication = new Authentication
            {
                Expiration = _jwtTokenSettings.Expiration,
                InvalidBefore = DateTime.UtcNow
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtTokenValidation.ValidIssuer,
                audience: _jwtTokenValidation.ValidAudience,
                claims: claims,
                notBefore: authentication.InvalidBefore,
                expires: authentication.Expiration,
                signingCredentials: signinCredentials
            );
            authentication.Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return authentication;
        }
    }
}

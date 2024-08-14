using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Interface;
using api.Model;
using Microsoft.IdentityModel.Tokens;

namespace api.Service
{
    public class TokenService : ITokenService
    {

        //IConfiguration allows you to access configuration settings 
        //from various sources, such as appsettings.json, environment variables etc.
        private readonly IConfiguration _config;

        //SymmetricSecurityKey basically takes the singning key in encoded form and then encrypt it .
        private readonly SymmetricSecurityKey _key;


        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }

        public string CreateToken(AppUser user)
        {
            var Claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                //takes a list of claims (like user email and username) and uses them to create a new identity object. 
                //This identity object is like a digital ID card that contains all the important details about the user and is assigned to the subject.
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"],
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            // JwtSecurityTokenHandler provides methods to create, read, and validate JWTs.
            //By creating a new instance of this class (new JwtSecurityTokenHandler()), we now have an object (tokenHandler) that we can use to work with JWTs.

            var token = tokenHandler.CreateToken(tokenDescriptor);
            //The CreateToken method of the JwtSecurityTokenHandler class takes a SecurityTokenDescriptor object as a parameter. 
            //This descriptor contains all the information needed to generate the token, such as the claims, signing credentials, issuer, and audience

            //here the token looks like this

            //         JwtSecurityToken {
            //             Header {
            //                  alg: "HS256",
            //                  typ: "JWT"
            //             }
            //             Payload {
            //                  iss: "your-issuer",
            //                  aud: "your-audience",
            //                  exp: 1627847487,
            //                  claims:
            //                          [
            //                          { type: "email", value: "user@example.com" },
            //                           { type: "name", value: "John Doe" }
            //                          ]
            //                      }
            //             Signature {
            //                 ...
            //                   //SigningCredentials is used to create a signature for the JWT.
            // }
            //         }


            return tokenHandler.WriteToken(token);
            //This line converts the JWT, which is an object, into a compact string format 
        }
    }
}
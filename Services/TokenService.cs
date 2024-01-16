using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.Models;

namespace WebApi.Services;

public class TokenService
{
    private readonly string _securityKey;
    public TokenService()
    {
        //transferir chave para um secret
        this._securityKey = "aLKvrZDNMteKav5uXPr4RbyBehFVivQj";
    }
    public string GenerateUserToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username",user.UserName!),
            new Claim("id",user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._securityKey));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken
        (
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

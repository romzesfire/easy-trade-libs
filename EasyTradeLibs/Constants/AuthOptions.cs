using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EasyTradeLibs.Constants;

public class AuthOptions
{
    public const string ISSUER = "EasyTradeServer";
    public const string AUDIENCE = "EasyTradeClient";
    const string KEY = "AaBbCc_Key123456";

    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}
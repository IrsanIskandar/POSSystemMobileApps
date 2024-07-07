using Microsoft.IdentityModel.Tokens;
using POSSystem.DataContext.DataContext;
using POSSystem.WebServices.Infrastructure.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace POSSystem.WebServices.Infrastructure.Repository;

public class TokenService : ITokenService
{
	private const double EXPIRY_DURATION_MINUTES = 60;

	public string BuildToken(string key, string issuer, VwListdatastaff user)
	{
		var claims = new[] {
			new Claim("UserId", user.Userid.ToString()),
			new Claim("NIK", user.Personalidentity ?? string.Empty),
			new Claim("Username", user.Username),
			new Claim("Firstname", user.Firstname),
			new Claim("LastName", user.Lastname ?? string.Empty),
			new Claim("EmailAddress", user.Emailaddress),
			new Claim("Lastlogindate", user.Lastlogindate.ToString()),
			new Claim("Isconfirmationaccount", user.Isconfirmationaccount.ToString()),
			new Claim("Fulladdress", user.Fulladdress ?? string.Empty),
			new Claim("Genderid", user.Genderid.ToString() ?? string.Empty),
			new Claim("Gendername", user.Gendername.ToString() ?? string.Empty),
			new Claim("Mobilephone", user.Mobilephone ?? string.Empty),
			new Claim("Password", user.Password ?? string.Empty),
			new Claim("Salt", user.Salt ?? string.Empty),
			new Claim("Isactive", user.Isactive.ToString()),
			new Claim("Isactivedesc", user.Isactivedesc),
			new Claim("Isdeleted", user.Isdeleted.ToString() ?? string.Empty),
			new Claim("Isdeleteddesc", user.Isdeleteddesc.ToString() ?? string.Empty),
			new Claim("Createdby", user.Createdby ?? string.Empty),
			new Claim("Createddate", user.Createddate.Value.ToString()),
			new Claim("Modifiedby", user.Modifiedby ?? string.Empty),
			new Claim("Modifieddate", user.Modifieddate.Value.ToString()),
			new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
		};

		var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
		var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha384Signature);
		var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
			expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);

		return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
	}

	public bool ValidateToken(string key, string issuer, string audience, string token)
	{
		var mySecret = Encoding.UTF8.GetBytes(key);
		var mySecurityKey = new SymmetricSecurityKey(mySecret);
		var tokenHandler = new JwtSecurityTokenHandler();
		try
		{
			tokenHandler.ValidateToken(token,
			new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidIssuer = issuer,
				ValidAudience = issuer,
				IssuerSigningKey = mySecurityKey,
			}, out SecurityToken validatedToken);
		}
		catch
		{
			return false;
		}

		return true;
	}

	public bool IsTokenValid(string key, string issuer, string token)
	{
		var mySecret = Encoding.UTF8.GetBytes(key);
		var mySecurityKey = new SymmetricSecurityKey(mySecret);
		var tokenHandler = new JwtSecurityTokenHandler();
		try
		{
			tokenHandler.ValidateToken(token,
			new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidIssuer = issuer,
				ValidAudience = issuer,
				IssuerSigningKey = mySecurityKey,
			}, out SecurityToken validatedToken);
		}
		catch
		{
			return false;
		}

		return true;
	}

	public VwListdatastaff TokenToObject(IEnumerable<Claim> claims)
	{
		VwListdatastaff obj = new VwListdatastaff();
		if (claims.Count() > 0)
		{
			foreach (var item in claims)
			{
				switch (item.Type)
				{
					case "Userid":
						obj.Userid = int.Parse(item.Value);
						break;
					case "Personalidentity":
						obj.Personalidentity = item.Value;
						break;
					case "Username":
						obj.Username = item.Value;
						break;
					case "Firstname":
						obj.Firstname = item.Value;
						break;
					case "Lastname":
						obj.Lastname = item.Value;
						break;
					case "Emailaddress":
						obj.Emailaddress = item.Value;
						break;
					case "Lastlogindate":
						obj.Lastlogindate = Convert.ToDateTime(item.Value);
						break;
					case "Fulladdress":
						obj.Fulladdress = item.Value;
						break;
					case "Genderid":
						obj.Genderid = item.Value != string.Empty ? Convert.ToInt32(item.Value) : -1;
						break;
					case "Gendername":
						obj.Gendername = item.Value;
						break;
					case "Mobilephone":
						obj.Mobilephone = item.Value;
						break;
					case "Password":
						obj.Password = item.Value;
						break;
					case "Salt":
						obj.Salt = item.Value;
						break;
					case "Isactive":
						obj.Isactive = Convert.ToBoolean(item.Value);
						break;
					case "Isactivedesc":
						obj.Isactivedesc = item.Value;
						break;
					case "Isdeleted":
						obj.Isdeleted = Convert.ToBoolean(item.Value);
						break;
					case "Isdeleteddesc":
						obj.Isdeleteddesc = item.Value;
						break;
					case "Createdby":
						obj.Createdby = item.Value;
						break;
					case "Createddate":
						obj.Createddate = Convert.ToDateTime(item.Value);
						break;
					case "Modifiedby":
						obj.Modifiedby = item.Value;
						break;
					case "Modifieddate":
						obj.Modifieddate = Convert.ToDateTime(item.Value);
						break;
				}
			}
		}

		return obj;
	}
}

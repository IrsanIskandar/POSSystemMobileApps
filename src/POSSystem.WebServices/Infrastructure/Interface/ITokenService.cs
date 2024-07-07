using POSSystem.DataContext.DataContext;
using System.Security.Claims;

namespace POSSystem.WebServices.Infrastructure.Interface;

public interface ITokenService
{
	string BuildToken(string key, string issuer, VwListdatastaff user);
	bool IsTokenValid(string key, string issuer, string token);
	bool ValidateToken(string key, string issuer, string audience, string token);
	VwListdatastaff TokenToObject(IEnumerable<Claim> claims);
}

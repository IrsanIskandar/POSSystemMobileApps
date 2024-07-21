using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSSystem.DataContext.DataContext;
using POSSystem.WebServices.Helpers;
using POSSystem.WebServices.Infrastructure.Interface;
using POSSystem.WebServices.POSDto;
using System.Text;

namespace POSSystem.WebServices.Controllers;

[Route("api/identity/oauth")]
[ApiController]
public class Authentication : ControllerBase
{
    private readonly ILogger<Authentication> _logger;
	private readonly IHttpContextAccessor _contextAccessor;
	private readonly IUserRepository _userRepository;
	private readonly ITokenService _tokenService;

	public Authentication(ILogger<Authentication> logger, IHttpContextAccessor contextAccessor, IUserRepository userRepository, ITokenService tokenService)
	{
		_logger = logger;
		_contextAccessor = contextAccessor;
		_userRepository = userRepository;
		_tokenService = tokenService;
	}

	[HttpPost("sign-in")]
	public IActionResult AuthenticationSystem(LoginDto login)
	{
		try
		{
			byte[] baSalt = Encoding.ASCII.GetBytes(login.Username);
			string buildSalt = Convert.ToBase64String(baSalt);
			string passEncrypt = SandevLibrary.SecurityAlgorithm.AESAlgorithm.EncryptTextWithSalt(login.Password, buildSalt);

			VwListdatastaff getUser = _userRepository.GetUser(login.Username.ToLower(), passEncrypt);
			if (getUser is not null)
			{
				string buildToken = _tokenService.BuildToken(POSHelper.JWT_KEY, POSHelper.JWT_ISSUER, getUser);
				_contextAccessor.HttpContext.Session.SetString("access_token", buildToken);
				ResponseSignin result = new ResponseSignin(buildToken);
				ResponseGlobal response = new ResponseGlobal(200, "Login Successfully.", result);
				return Ok(response);
			}
		}
		catch
		{
			return StatusCode(500);
		}

		return BadRequest();
	}
}

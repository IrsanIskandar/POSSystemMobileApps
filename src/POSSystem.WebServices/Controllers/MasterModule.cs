using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSSystem.DataContext.DataContext;
using POSSystem.DataContext.ViewModels;
using POSSystem.WebServices.Helpers;
using POSSystem.WebServices.Infrastructure.Interface;
using POSSystem.WebServices.Infrastructure.Repository;
using POSSystem.WebServices.POSDto;
using System.Net.Http.Headers;

namespace POSSystem.WebServices.Controllers;

[Route("api/module/master")]
[ApiController]
public class MasterModule : ControllerBase
{
	private readonly ILogger<MasterModule> _logger;
	private readonly IHttpContextAccessor _contextAccessor;
	private readonly IUserRepository _userRepository;
	private readonly ITokenService _tokenService;

	public MasterModule(ILogger<MasterModule> logger, IHttpContextAccessor contextAccessor, IUserRepository userRepository, ITokenService tokenService)
    {
        _logger = logger;
		_contextAccessor = contextAccessor;
		_userRepository = userRepository;
		_tokenService = tokenService;
    }

	[HttpGet("staff-list")]
	public IActionResult GetListStaff()
	{
		try
		{
			var getListStaff = _userRepository.GetListStaff();
			ResponseGlobal response = new ResponseGlobal(200, "Successfully", getListStaff);
			return Ok(response);
		}
		catch
		{
			return StatusCode(500);
		}
	}

	[HttpGet("module-list")]
	public IActionResult GetModuleList()
	{
		try
		{
			var getModuleList = _userRepository.GetModule();
			ResponseGlobal response = new ResponseGlobal(200, "Successfully", getModuleList);
			return Ok(response);
		}
		catch
		{
			return StatusCode(500);
		}
	}

	[HttpPost("create-staff")]
	public IActionResult CreateStaff([FromBody] UserDetailViewModel request)
	{
		try
		{
			string? accsessToken = _contextAccessor.HttpContext?.Request.Headers.Authorization;
			if (!Convert.ToBoolean(_contextAccessor.HttpContext?.User?.Identity?.IsAuthenticated) && string.IsNullOrWhiteSpace(accsessToken))
				return StatusCode(403, "AuthIdentity");

			string? cleanedToken = AuthenticationHeaderValue.Parse(accsessToken).Parameter;
			if (!_tokenService.IsTokenValid(POSHelper.JWT_KEY, POSHelper.JWT_ISSUER, cleanedToken))
				return StatusCode(403, "AuthIdentity");

			VwListdatastaff dataStaff = _tokenService.TokenToObject(_contextAccessor.HttpContext.User.Claims);
			bool result = _userRepository.CreateStaff(request, dataStaff);
			if (result)
			{
				ResponseGlobal response = new ResponseGlobal(201, "User Created.");
				return StatusCode(201, response);
			}
			else return BadRequest();
		}
		catch
		{
			return StatusCode(500);
		}
	}

	[HttpPut("modify-staff")]
	public IActionResult ModifyStaff([FromBody] UserDetailViewModel request)
	{
		try
		{
			string? accsessToken = _contextAccessor.HttpContext?.Request.Headers.Authorization;
			if (!Convert.ToBoolean(_contextAccessor.HttpContext?.User?.Identity?.IsAuthenticated) && string.IsNullOrWhiteSpace(accsessToken))
				return StatusCode(403, "AuthIdentity");

			string? cleanedToken = AuthenticationHeaderValue.Parse(accsessToken).Parameter;
			if (!_tokenService.IsTokenValid(POSHelper.JWT_KEY, POSHelper.JWT_ISSUER, cleanedToken))
				return StatusCode(403, "AuthIdentity");

			VwListdatastaff dataStaff = _tokenService.TokenToObject(_contextAccessor.HttpContext.User.Claims);
			bool result = _userRepository.UpdateStaff(request, dataStaff);
			if (result)
			{
				ResponseGlobal response = new ResponseGlobal(201, "User Updated.");
				return StatusCode(201, response);
			}
			else return BadRequest();
		}
		catch
		{
			return StatusCode(500);
		}
	}

	[HttpDelete("delete-staff/{userId}")]
	public IActionResult DeleteStaff(int userId)
	{
		try
		{
			string? accsessToken = _contextAccessor.HttpContext?.Request.Headers.Authorization;
			if (!Convert.ToBoolean(_contextAccessor.HttpContext?.User?.Identity?.IsAuthenticated) && string.IsNullOrWhiteSpace(accsessToken))
				return StatusCode(403, "AuthIdentity");

			string? cleanedToken = AuthenticationHeaderValue.Parse(accsessToken).Parameter;
			if (!_tokenService.IsTokenValid(POSHelper.JWT_KEY, POSHelper.JWT_ISSUER, cleanedToken))
				return StatusCode(403, "AuthIdentity");

			VwListdatastaff dataStaff = _tokenService.TokenToObject(_contextAccessor.HttpContext.User.Claims);
			bool result = _userRepository.DeleteStaff(userId, dataStaff);
			if (result)
			{
				ResponseGlobal response = new ResponseGlobal(201, "User Deleted.");
				return StatusCode(201, response);
			}
			else return BadRequest();
		}
		catch
		{
			return StatusCode(500);
		}
	}
}

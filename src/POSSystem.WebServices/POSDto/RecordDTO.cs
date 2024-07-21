namespace POSSystem.WebServices.POSDto;

public record LoginDto(string? Username, string? Password);


// REQUEST DTO
public record RequestDataStaff(int? UserId, string? Usename, string? Firstname, string Lastname);

// RESPONSE DTO
public record ResponseGlobal(int StatusCode, string Message, object? Data = null);
public record ResponseSignin(string AccessToken);
public record ResponseCreateUser(string Message);

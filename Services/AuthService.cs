namespace taragonapi.Services;

public interface IAuthService
{
  Task<bool> CredentialsAreValid(string UserName, string Password);
}

public class AuthService : IAuthService
{
  public async Task<bool> CredentialsAreValid(string username, string password)
  {
    if (username == "Admin" && password == "Password")
    {
      return await Task.FromResult(true);
    }
    return await Task.FromResult(false);
  }
}

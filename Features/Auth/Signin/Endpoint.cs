using taragonapi.Services;

namespace taragonapi.Features.Auth.Signin;
public class Endpoint : Endpoint<Request, Response>
{
  private readonly IAuthService _authService;
  public Endpoint(IAuthService authService)
  {
    _authService = authService;
  }
  
  public override void Configure()
  {
    Post("/signin");
    Version(1);
    AllowAnonymous();
  }

  public override async Task HandleAsync(Request r, CancellationToken ct)
  {
    if (await _authService.CredentialsAreValid(r.UserName, r.Password))
    {
      var jwtToken = JWTBearer.CreateToken(
          signingKey: "ASDASDSADSADSADAD!",
          expireAt: DateTime.UtcNow.AddDays(1),
          claims: new[] { ("Username", r.UserName), ("Admin", "001") },
          roles: new[] { "Admin", "Management" },
          permissions: new[] { "ManageInventory", "ManageUsers" });

      await SendAsync(new Response()
      {
        UserName = r.UserName,
        Token = jwtToken
      }, cancellation: ct);
    }
    else
    {
      ThrowError("The supplied credentials are invalid!");
    }
  }
}
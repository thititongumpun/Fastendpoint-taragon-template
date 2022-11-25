namespace taragonapi.Features.Auth.Signup;
public class Endpoint : Endpoint<Request, Response>
{
  public override void Configure()
  {
    Post("/signup");
    Version(1);
    AllowAnonymous();
  }

  public override async Task HandleAsync(Request r, CancellationToken ct)
  {
    await SendAsync(new Response()
    {
      Message = $"hello {r.UserName} {r.Password}! your request has been received!"
    }, cancellation: ct);
  }
}
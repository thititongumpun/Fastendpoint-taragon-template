namespace taragonapi.Features.Auth.Signin;

public class Request
{
  public string UserName { get; set; }
  public string Password { get; set; }
}

public class Validator : Validator<Request>
{
  public Validator()
  {
    RuleFor(x => x.UserName)
        .NotEmpty().WithMessage("a username is required!")
        .MinimumLength(3).WithMessage("username is too short!")
        .MaximumLength(15).WithMessage("username is too long!");

    RuleFor(x => x.Password)
        .NotEmpty().WithMessage("a password is required!")
        .MinimumLength(3).WithMessage("password is too short!")
        .MaximumLength(15).WithMessage("password is too long!");
  }
}

public class Response
{
  public string UserName { get; set; }
  public string Token { get; set; }
}

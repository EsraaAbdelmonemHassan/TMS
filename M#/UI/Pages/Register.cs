using MSharp;

public class RegisterPage : RootPage
{
    public RegisterPage()
    {
        Route("register");

        Layout(Layouts.Login);

        Add<Modules.RegisterForm>();
        MarkupTemplate("<div class=\"login-content\"><div class=\"card login\"><div class=\"card-body\">[#1#]</div></div></div>");

        OnStart(x =>
        {
            x.If("User.Identity.IsAuthenticated").Go<Login.DispatchPage>().RunServerSide();
        });
    }
}

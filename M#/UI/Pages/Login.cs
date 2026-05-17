using MSharp;
using Domain;

public class LoginPage : RootPage
{
    public LoginPage()
    {
        Route("login");

        Layout(Layouts.Login);

        Add<Modules.LoginForm>();
        MarkupTemplate("<div class=\"login-content\"><div class=\"card login\"><div class=\"card-body\">[#1#]</div></div></div>");

        OnStart(x =>
        {
            x.If("Request.IsAjaxPost()").CSharp("return Redirect(Url.CurrentUri().OriginalString);");
            x.If("Request.Query[\"registered\"] == \"1\"").GentleMessage("Your account has been created. Please sign in.");
            x.If("User.Identity.IsAuthenticated").Go<Login.DispatchPage>().RunServerSide();
        });
    }
}
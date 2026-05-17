using MSharp;

namespace Modules
{
    public class RegisterForm : FormModule<Domain.Administrator>
    {
        public RegisterForm()
        {
            SupportsAdd(true)
                .SupportsEdit(false)
                .HeaderText("Create account")
                .IsViewComponent()
                .Using("Olive.Security");

            Field(x => x.FirstName).Mandatory().WatermarkText("First name");
            Field(x => x.LastName).Mandatory().WatermarkText("Last name");
            Field(x => x.Email).Mandatory().WatermarkText("Your email");
            Field(x => x.Password).Mandatory().WatermarkText("Choose a password");
            CustomField().Label("Confirm password")
                .Mandatory()
                .PropertyName("ConfirmPassword")
                .ExtraControlAttributes("type=\"password\"")
                .ViewModelAttributes("[System.ComponentModel.DataAnnotations.Compare(\"Password\",ErrorMessage=\"Password and Confirm password do not match. Please try again.\")]")
                .Control(ControlType.Textbox);

            Button("Create account").ValidateAntiForgeryToken(false).CssClass("w-100 btn-login mb-2")
                .OnClick(x =>
                {
                    x.CSharp("var existing = await Domain.User.FindByEmail(info.Email?.Trim());");
                    x.If("existing != null")
                     .CSharp(@"Notify(""An account with this email already exists. Please sign in or use a different email."", ""error"");
                        return View(info);");

                    x.CSharp(@"var pass = SecurePassword.Create(info.Password.Trim());
                        info.Password = pass.Password;
                        info.Item.Password = pass.Password;
                        info.Item.Salt = pass.Salt;
                        info.Item.IsDeactivated = false;
                        info.Email = info.Email.Trim();");

                    x.SaveInDatabase();
                    x.Go("/login?registered=1");
                });

            Link("Already have an account? Sign in").CssClass("text-info").OnClick(x => x.Go<LoginPage>());

            Link("Back to home").CssClass("text-muted d-block text-center mt-3").OnClick(x => x.Go("/home"));
        }
    }
}

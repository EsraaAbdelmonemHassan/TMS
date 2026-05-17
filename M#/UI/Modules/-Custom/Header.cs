using MSharp;
using Domain;

namespace Modules
{
    public class Header : GenericModule
    {
        public Header()
        {
            IsInUse().IsViewComponent().WrapInForm(false);
            WrapInForm();
            Using("Olive.Security");
            RootCssClass("header-wrapper");
            var burger = Link("Burger")
                .NoText()
                .Icon("fas")
                 .CssClass("menu-toggler burger-icon")

                .ExtraTagAttributes("type=\"button\"");

            var login = Link("Login").Icon(FA.UnlockAlt)
                        .VisibleIf(AppRole.Anonymous)
                        .OnClick(x => x.Go<LoginPage>());

            var logout = Link("Logout")
                         .CssClass("align-bottom logout")
                         .ValidateAntiForgeryToken(false)
                         .VisibleIf(CommonCriterion.IsUserLoggedIn)
                         .OnClick(x =>
                         {
                             x.CSharp("await OAuth.Instance.LogOff();");
                             x.Go<LoginPage>();
                         });
            Markup($@"
            <nav class=""navbar"">
              <div class=""header-left-actions-wrapper"">
                      {burger.Ref}
                      <a class=""logo"" href=""/home"" title=""TMS Home"" name=""Logo"">
                          <img src=""/img/Logo.png"" alt=""TMS – Training Management System"" />
                      </a>
              </div>
              <div class=""header-account-wrapper"">
                    {logout.Ref}
                  </div>
            </nav>");

        }
    }
}
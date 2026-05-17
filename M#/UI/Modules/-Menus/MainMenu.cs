using Domain;
using MSharp;

namespace Modules
{
    public class MainMenu : MenuModule
    {
        public MainMenu()
        {
            SubItemBehaviour(MenuSubItemBehaviour.ExpandCollapse);
            AjaxRedirect().WrapInForm(false);
            Using("Olive.Security");
            IsViewComponent().UlCssClass("nav flex-column");
            RootCssClass("sidebar-menu");

            Link("Products").Go<Admin.ProductsPage>().Icon(FA.ProductHunt);
            Link("Categories").Go<Admin.CategoriesPage>().Icon(FA.Folder);
            Link("Orders").Go<Admin.OrdersPage>().Icon(FA.ShoppingCart);
            Link("Customers").Go<Admin.CustomersPage>().Icon(FA.AddressBook);
            Link("Students").Go<Admin.StudentsPage>().Icon(FA.GraduationCap);
            Link("Courses").Go<Admin.CoursesPage>().Icon(FA.Book);
            Link("Departments").Go<Admin.DepartmentsPage>().Icon(FA.Building);
            Link("Employees").Go<Admin.EmployeesPage>().Icon(FA.Users);

            Link("Logout")
                 .CssClass("align-bottom logout")
                 .ValidateAntiForgeryToken(false)
                 .VisibleIf(CommonCriterion.IsUserLoggedIn)
                 .OnClick(x =>
                 {
                     x.CSharp("await OAuth.Instance.LogOff();");
                     x.Go<LoginPage>();
                 });
        }
    }
}
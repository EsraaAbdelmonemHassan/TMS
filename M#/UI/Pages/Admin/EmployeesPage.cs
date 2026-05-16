using MSharp;

namespace Admin
{
    public class EmployeesPage : SubPage<AdminPage>
    {
        public EmployeesPage()
        {
            Add<Modules.EmployeesList>();
        }
    }
}

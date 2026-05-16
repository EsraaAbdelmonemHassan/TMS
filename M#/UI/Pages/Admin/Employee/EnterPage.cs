using MSharp;

namespace Admin.Employee
{
    public class EnterPage : SubPage<EmployeesPage>
    {
        public EnterPage()
        {
            Add<Modules.EmployeeForm>();
        }
    }
}

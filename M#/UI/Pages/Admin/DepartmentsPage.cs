using MSharp;

namespace Admin
{
    public class DepartmentsPage : SubPage<AdminPage>
    {
        public DepartmentsPage()
        {
            Add<Modules.DepartmentsList>();
        }
    }
}

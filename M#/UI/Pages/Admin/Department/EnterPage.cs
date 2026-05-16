using MSharp;

namespace Admin.Department
{
    public class EnterPage : SubPage<DepartmentsPage>
    {
        public EnterPage()
        {
            Add<Modules.DepartmentForm>();
        }
    }
}

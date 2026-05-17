using MSharp;
using Domain;

namespace Modules
{
    public class EmployeesList : ListModule<Employee>
    {
        public EmployeesList()
        {
            HeaderText("Employees");
            
            Search(x => x.FirstName);
            Search(x => x.LastName);
            Search(x => x.Department);
            
            Column(x => x.FirstName);
            Column(x => x.LastName);
            Column(x => x.Department);
            
            Button("New Employee").Icon(FA.Plus)
                .OnClick(x => x.Go<Admin.Employee.EnterPage>().SendReturnUrl());

            ButtonColumn("Edit").Icon(FA.Edit)
                .OnClick(x => x.Go<Admin.Employee.EnterPage>().Send("item", "item.ID").SendReturnUrl());

            ButtonColumn("Delete").Icon(FA.Trash)
                .OnClick(x =>
                {
                    x.DeleteItem();
                    x.Reload();
                });
        }
    }
}

using MSharp;
using Domain;

namespace Modules
{
    public class DepartmentsList : ListModule<Department>
    {
        public DepartmentsList()
        {
            HeaderText("Departments");
            
            Search(x => x.Name);
            
            Column(x => x.Name);
            Column(x => x.Description);
            
            Button("New Department").Icon(FA.Plus)
                .OnClick(x => x.Go<Admin.Department.EnterPage>().SendReturnUrl());

            ButtonColumn("Edit").Icon(FA.Edit)
                .OnClick(x => x.Go<Admin.Department.EnterPage>().Send("item", "item.ID").SendReturnUrl());

            ButtonColumn("Delete").Icon(FA.Trash)
                .OnClick(x =>
                {
                    x.DeleteItem();
                    x.Reload();
                });
        }
    }
}

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
            
            Button("New Department").Icon(fa.plus)
                .OnClick(x => x.Go<Admin.Department.EnterPage>().SendReturnUrl());

            ButtonColumn("Edit").Icon(fa.edit)
                .OnClick(x => x.Go<Admin.Department.EnterPage>().Send("item", "item.ID").SendReturnUrl());

            ButtonColumn("Delete").Icon(fa.trash)
                .OnClick(x =>
                {
                    x.DeleteItem();
                    x.Reload();
                });
        }
    }
}

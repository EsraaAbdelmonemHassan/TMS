using MSharp;
using Domain;

namespace Modules
{
    public class DepartmentForm : FormModule<Department>
    {
        public DepartmentForm()
        {
            HeaderText("Department details");

            Field(x => x.Name);
            Field(x => x.Description);

            Button("Save").IsDefault().Icon(FA.Check)
                .OnClick(x =>
                {
                    x.SaveInDatabase();
                    x.ReturnToPreviousPage();
                });

            Button("Cancel").Icon(FA.Times)
                .OnClick(x => x.ReturnToPreviousPage());
        }
    }
}

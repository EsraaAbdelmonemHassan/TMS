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

            Button("Save").IsDefault().Icon(fa.check)
                .OnClick(x =>
                {
                    x.SaveInDatabase();
                    x.ReturnToPreviousPage();
                });

            Button("Cancel").Icon(fa.times)
                .OnClick(x => x.ReturnToPreviousPage());
        }
    }
}

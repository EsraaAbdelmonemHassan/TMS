using MSharp;
using Domain;

namespace Modules
{
    public class EmployeeForm : FormModule<Employee>
    {
        public EmployeeForm()
        {
            HeaderText("Employee details");

            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.Department).Control(ControlType.DropdownList);

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

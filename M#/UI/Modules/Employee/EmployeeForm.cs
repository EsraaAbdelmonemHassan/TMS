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

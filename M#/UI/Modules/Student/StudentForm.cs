using Domain;
using MSharp;

namespace Modules
{
    public class StudentForm : FormModule<Student>
    {
        public StudentForm()
        {
            HeaderText("Student details");

            Field(x => x.FirstName).Mandatory();
            Field(x => x.LastName).Mandatory();

            Button("Cancel").Icon(FA.Times).OnClick(x => x.ReturnToPreviousPage());

            Button("Save").IsDefault().Icon(FA.Check)
                .OnClick(x =>
                {
                    x.SaveInDatabase();
                    x.ReturnToPreviousPage();
                });
        }
    }
}

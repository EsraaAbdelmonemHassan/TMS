using Domain;
using MSharp;

namespace Modules
{
    public class CourseForm : FormModule<Course>
    {
        public CourseForm()
        {
            HeaderText("Course details");

            Field(x => x.Name).Mandatory();
            Field(x => x.Code).Mandatory();

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

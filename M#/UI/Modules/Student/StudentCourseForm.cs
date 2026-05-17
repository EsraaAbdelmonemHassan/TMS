using Domain;
using MSharp;

namespace Modules
{
    public class StudentCourseForm : FormModule<StudentCourse>
    {
        public StudentCourseForm()
        {
            HeaderText("Course registration");

            ViewModelProperty<Student>("Student").FromRequestParam("item");

            Field(x => x.Course).Mandatory().Control(ControlType.DropdownList);

            Button("Cancel").CausesValidation(false).Icon(FA.Times)
                .OnClick(x => x.CloseModal());

            Button("Save").IsDefault().Icon(FA.Check)
                .OnClick(x =>
                {
                    x.CSharp("info.Item.Student = info.Student;");
                    x.SaveInDatabase();
                    x.CloseModal(Refresh.Ajax);
                });
        }
    }
}

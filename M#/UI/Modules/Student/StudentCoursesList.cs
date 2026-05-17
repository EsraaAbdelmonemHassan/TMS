using Domain;
using MSharp;

namespace Modules
{
    public class StudentCoursesList : ListModule<StudentCourse>
    {
        public StudentCoursesList()
        {
            HeaderText("Registered courses");
            PageSize(20);

            ViewModelProperty<Student>("Student").FromRequestParam("item");
            SourceCriteria("item.Student == info.Student");

            Column(x => x.Course);

            Button("Register course")
                .Icon(FA.Plus)
                .OnClick(x => x.PopUp<Admin.Student.StudentCourse.EnterPage>()
                    .Send("item", "info.Student.ID")
                    .SendReturnUrl(false));

            ButtonColumn("Unregister")
                .Style(ButtonStyle.Link)
                .Icon(FA.Remove)
                .OnClick(x =>
                {
                    x.DeleteItem();
                    x.Reload();
                });
        }
    }
}

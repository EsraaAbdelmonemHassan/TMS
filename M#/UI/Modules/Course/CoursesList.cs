using Domain;
using MSharp;

namespace Modules
{
    public class CoursesList : ListModule<Course>
    {
        public CoursesList()
        {
            HeaderText("Courses")
                .Sortable()
                .PageSize(10);

            Search(GeneralSearch.AllFields).Label("Search");
            Search(x => x.Code).Label("Code");

            var search = SearchButton("Search").Icon(FA.Search).OnClick(x => x.Reload());
            Search(x => x.Name).Label("Course name").AfterInput(search.Ref);

            Column(x => x.Name);
            Column(x => x.Code);

            ButtonColumn("Edit")
                .Style(ButtonStyle.Link)
                .Icon(FA.Edit)
                .OnClick(x => x.Go<Admin.Course.EnterPage>().Send("item", "item.ID").SendReturnUrl());

            ButtonColumn("Delete")
                .Style(ButtonStyle.Link)
                .ConfirmQuestion("Delete this course? Enrolments referencing it may be affected.")
                .Icon(FA.Remove)
                .OnClick(x =>
                {
                    x.DeleteItem();
                    x.Reload();
                });

            Button("New course").Icon(FA.Plus)
                .OnClick(x => x.Go<Admin.Course.EnterPage>().SendReturnUrl());
        }
    }
}

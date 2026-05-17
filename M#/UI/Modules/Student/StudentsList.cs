using Domain;
using MSharp;

namespace Modules
{
    public class StudentsList : ListModule<Student>
    {
        public StudentsList()
        {
            HeaderText("Students")
                .Sortable()
                .PageSize(10);

            Search(GeneralSearch.AllFields).Label("Search");

            var search = SearchButton("Search").Icon(FA.Search).OnClick(x => x.Reload());
            Search(x => x.FirstName).AfterInput(search.Ref);

            Column(x => x.FirstName);
            Column(x => x.LastName);
            Column(x => x.Name);

            ButtonColumn("Edit")
                .Style(ButtonStyle.Link)
                .Icon(FA.Edit)
                .OnClick(x => x.Go<Admin.Student.EnterPage>().Send("item", "item.ID").SendReturnUrl());

            Button("New student").Icon(FA.Plus)
                .OnClick(x => x.Go<Admin.Student.EnterPage>().SendReturnUrl());
        }
    }
}

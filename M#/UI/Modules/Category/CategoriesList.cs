using Domain;
using MSharp;

namespace Modules
{
    public class CategoriesList : ListModule<Category>
    {
        public CategoriesList()
        {
            HeaderText("Categories")
                .Sortable()
                .PageSize(10)
                .ShowFooterRow();

            Search(x => x.Name).Label("Category name");

            var search = SearchButton("Search").Icon(FA.Search).OnClick(x => x.Reload());
            Search(GeneralSearch.AllFields).Label("General search").AfterInput(search.Ref);

            Column(x => x.Name);
            Column(x => x.Parent);
            Column(x => x.SortOrder);
            Column(x => x.IsActive);

            ButtonColumn("Edit")
                .Style(ButtonStyle.Link)
                .Icon(FA.Edit)
                .OnClick(x => x.Go<Admin.Category.EnterPage>().Send("item", "item.ID").SendReturnUrl());

            ButtonColumn("Delete")
                .Style(ButtonStyle.Link)
                .ConfirmQuestion("Deleting this category will delete all associated products. Do you want to continue?")
                .Icon(FA.Remove)
                .OnClick(x =>
                {
                    x.DeleteItem();
                    x.Reload();
                });

            Button("New category").Icon(FA.Plus)
                .OnClick(x => x.Go<Admin.Category.EnterPage>().SendReturnUrl());
        }
    }
}

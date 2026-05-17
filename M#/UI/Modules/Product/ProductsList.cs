using Domain;
using MSharp;

namespace Modules
{
    public class ProductsList : ListModule<Product>
    {
        public ProductsList()
        {
            HeaderText("All Available Products")
                .Sortable()
                .PageSize(10)
                .ShowFooterRow()
                .ShowHeaderRow()
                .PagerPosition(PagerAt.Bottom)
                .UseDatabasePaging(false);

            var search = SearchButton("Search now")
                .Icon(FA.Search)
                .OnClick(x => x.Reload());

            Search(GeneralSearch.AllFields).Label("Search all fields").AfterInput(search.Ref);
            Search(x => x.Name).Label("Product name");
            Search(x => x.Category).Label("Category");

            LinkColumn(x => x.Name)
                .HeaderText("Product name")
                .OnClick(x => x.Go<Admin.Product.ViewPage>().Send("item", "item.ID").SendReturnUrl());

            Column(x => x.Code);
            Column(x => x.Category);
            Column(x => x.Price).DisplayFormat("{0:C}");
            Column(x => x.Quantity);
            Column(x => x.IsActive);

            ButtonColumn("Edit")
                .Style(ButtonStyle.Link)
                .Icon(FA.Edit)
                .OnClick(x => x.PopUp<Admin.Product.EnterPage>().Send("item", "item.ID").SendReturnUrl(false));

            ButtonColumn("Delete")
                .Style(ButtonStyle.Link)
                .ConfirmQuestion("Do you want to delete this product?")
                .Icon(FA.Remove)
                .OnClick(x =>
                {
                    x.DeleteItem();
                    x.Reload();
                });

            Button("Add product")
                .Icon(FA.Plus)
                .OnClick(x => x.PopUp<Admin.Product.EnterPage>().SendReturnUrl(false));

            Button("Export CSV")
                .Icon(FA.Download)
                .OnClick(x => x.Go("/export/products"));
        }
    }
}

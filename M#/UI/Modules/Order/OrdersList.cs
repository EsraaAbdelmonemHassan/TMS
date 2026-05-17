using Domain;
using MSharp;

namespace Modules
{
    public class OrdersList : ListModule<Order>
    {
        public OrdersList()
        {
            HeaderText("Orders")
                .Sortable()
                .PageSize(10)
                .ShowFooterRow();

            Search(x => x.Customer).Label("Customer");
            Search(x => x.Status).Label("Status");

            var search = SearchButton("Search").Icon(FA.Search).OnClick(x => x.Reload());
            Search(GeneralSearch.AllFields).AfterInput(search.Ref);

            Column(x => x.OrderDate).DisplayFormat("{0:dd/MM/yyyy}");
            Column(x => x.Customer).DisplayExpression(cs("item.Customer?.Name ?? \"Not specified\"")).NeedsMerging();
            Column(x => x.TotalAmount).DisplayFormat("{0:C}");
            Column(x => x.Status);
            Column(x => x.IsApproved);

            ButtonColumn("Edit")
                .Style(ButtonStyle.Link)
                .Icon(FA.Edit)
                .OnClick(x => x.Go<Admin.Order.EnterPage>().Send("item", "item.ID").SendReturnUrl());

            ButtonColumn("Delete")
                .Style(ButtonStyle.Link)
                .ConfirmQuestion("Deleting this order will delete all items. Continue?")
                .Icon(FA.Remove)
                .OnClick(x =>
                {
                    x.DeleteItem();
                    x.Reload();
                });

            Button("New order").Icon(FA.Plus)
                .OnClick(x => x.Go<Admin.Order.EnterPage>().SendReturnUrl());
        }
    }
}

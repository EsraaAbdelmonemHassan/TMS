using Domain;
using MSharp;

namespace Modules
{
    public class OrderItemsList : ListModule<OrderItem>
    {
        public OrderItemsList()
        {
            HeaderText("Order items");
            PageSize(20);

            ViewModelProperty<Order>("Order").FromRequestParam("item");
            SourceCriteria("item.Order == info.Order");

            Column(x => x.Product);
            Column(x => x.Quantity);
            Column(x => x.UnitPrice).DisplayFormat("{0:C}");
            Column(x => x.TotalPrice).DisplayFormat("{0:C}");

            Button("Add item")
                .Icon(FA.Plus)
                .OnClick(x => x.PopUp<Admin.Order.OrderItem.EnterPage>()
                    .Send("item", "info.Order.ID")
                    .SendReturnUrl(false));

            ButtonColumn("Delete")
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

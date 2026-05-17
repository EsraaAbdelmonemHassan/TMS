using Domain;
using MSharp;

namespace Modules
{
    public class OrderItemForm : FormModule<OrderItem>
    {
        public OrderItemForm()
        {
            HeaderText("Order item");

            ViewModelProperty<Order>("Order").FromRequestParam("item");

            Field(x => x.Product).Mandatory().Control(ControlType.DropdownList);
            Field(x => x.Quantity).Mandatory();
            Field(x => x.UnitPrice).Mandatory();

            Button("Cancel").CausesValidation(false).Icon(FA.Times)
                .OnClick(x => x.CloseModal());

            Button("Save").IsDefault().Icon(FA.Check)
                .OnClick(x =>
                {
                    x.CSharp("info.Item.Order = info.Order;");
                    x.SaveInDatabase();
                    x.GentleMessage("Item added successfully.");
                    x.CloseModal(Refresh.Ajax);
                });
        }
    }
}

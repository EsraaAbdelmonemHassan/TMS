using Domain;
using MSharp;

namespace Modules
{
    public class OrderForm : FormModule<Order>
    {
        public OrderForm()
        {
            HeaderText("Order details");

            Field(x => x.OrderDate).Mandatory();
            Field(x => x.Customer).Control(ControlType.DropdownList);
            Field(x => x.Status);
            Field(x => x.IsApproved).Control(ControlType.CheckBox);
            Field(x => x.StartDate);
            Field(x => x.EndDate);
            Field(x => x.TotalAmount);

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

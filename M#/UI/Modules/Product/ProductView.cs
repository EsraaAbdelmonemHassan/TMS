using Domain;
using MSharp;

namespace Modules
{
    public class ProductView : ViewModule<Product>
    {
        public ProductView()
        {
            HeaderText("View product");

            Field(x => x.Name);
            Field(x => x.Code);
            Field(x => x.Description);
            Field(x => x.Category);
            Field(x => x.Price).DisplayFormat("{0:C}");
            Field(x => x.Quantity);
            Field(x => x.Image);
            Field(x => x.Manual);

            Button("Back").OnClick(x => x.ReturnToPreviousPage());

            Button("Edit").Icon(FA.Edit)
                .OnClick(x => x.PopUp<Admin.Product.EnterPage>().Send("item", "item.ID").SendReturnUrl(false));
        }
    }
}

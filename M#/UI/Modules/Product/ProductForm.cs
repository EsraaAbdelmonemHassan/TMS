using Domain;
using MSharp;

namespace Modules
{
    public class ProductForm : FormModule<Product>
    {
        public ProductForm()
        {
            HeaderText("Product details");

            Field(x => x.Name).Mandatory();
            Field(x => x.Code).Mandatory();
            Field(x => x.Description);
            Field(x => x.Category).Control(ControlType.DropdownList).Label("Category");
            Field(x => x.Price)
                .HeaderText("Price including tax");
            Field(x => x.Quantity);
            Field(x => x.IsActive).Control(ControlType.CheckBox);
            Field(x => x.AvailableFrom);
            Field(x => x.AvailableTo);
            Field(x => x.Image);
            Field(x => x.Manual);

            Button("Cancel").CausesValidation(false).Icon(FA.Times)
                .OnClick(x => x.CloseModal());

            Button("Save").IsDefault().Icon(FA.Check)
                .OnClick(x =>
                {
                    x.SaveInDatabase();
                    x.GentleMessage("Saved successfully.");
                    x.CloseModal(Refresh.Ajax);
                });
        }
    }
}

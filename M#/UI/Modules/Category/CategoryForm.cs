using Domain;
using MSharp;

namespace Modules
{
    public class CategoryForm : FormModule<Category>
    {
        public CategoryForm()
        {
            HeaderText("Category details");

            Field(x => x.Name).Mandatory();
            Field(x => x.Description);
            Field(x => x.Parent).Control(ControlType.DropdownList);
            Field(x => x.SortOrder);
            Field(x => x.IsActive).Control(ControlType.CheckBox);

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

using Domain;
using MSharp;

namespace Modules
{
    public class CustomerForm : FormModule<Customer>
    {
        public CustomerForm()
        {
            HeaderText("Customer details");

            Field(x => x.FirstName).Mandatory();
            Field(x => x.LastName).Mandatory();
            Field(x => x.Email).Mandatory();
            Field(x => x.PhoneNumber);
            Field(x => x.CustomerCode).Mandatory();
            Field(x => x.CreditLimit);

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

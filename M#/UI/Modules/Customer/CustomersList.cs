using Domain;
using MSharp;

namespace Modules
{
    public class CustomersList : ListModule<Customer>
    {
        public CustomersList()
        {
            HeaderText("Customers")
                .Sortable()
                .PageSize(10);

            Search(GeneralSearch.AllFields).Label("Search");
            Search(x => x.CustomerCode);

            Column(x => x.Name);
            Column(x => x.Email);
            Column(x => x.CustomerCode);
            Column(x => x.CreditLimit).DisplayFormat("{0:C}");

            ButtonColumn("Edit")
                .Style(ButtonStyle.Link)
                .Icon(FA.Edit)
                .OnClick(x => x.Go<Admin.Customer.EnterPage>().Send("item", "item.ID").SendReturnUrl());

            Button("New customer").Icon(FA.Plus)
                .OnClick(x => x.Go<Admin.Customer.EnterPage>().SendReturnUrl());
        }
    }
}

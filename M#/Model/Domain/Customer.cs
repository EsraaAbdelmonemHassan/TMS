using MSharp;

namespace Domain
{
    public class Customer : Person
    {
        public Customer()
        {
            String("CustomerCode", 50).Mandatory().Unique();
            Money("CreditLimit").Mandatory();
        }
    }
}

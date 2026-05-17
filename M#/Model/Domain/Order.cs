using MSharp;

namespace Domain
{
    public class Order : EntityType
    {
        public Order()
        {
            DateTime("OrderDate").Mandatory().Default(cs("LocalTime.Now"));
            Associate<Customer>("Customer").Mandatory();
            Money("TotalAmount").Mandatory();
            Bool("IsApproved").Mandatory();
            String("Status", 50);
            DateTime("StartDate");
            DateTime("EndDate");
        }
    }
}

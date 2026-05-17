using MSharp;

namespace Domain
{
    public class OrderItem : EntityType
    {
        public OrderItem()
        {
            Associate<Order>("Order").Mandatory().OnDelete(CascadeAction.CascadeDelete);
            Associate<Product>("Product").Mandatory();
            Int("Quantity").Mandatory();
            Money("UnitPrice").Mandatory();
            Money("TotalPrice").Calculated().Getter("Quantity * UnitPrice");
        }
    }
}

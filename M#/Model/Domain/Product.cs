using MSharp;

namespace Domain
{
    public class Product : EntityType
    {
        public Product()
        {
            String("Name", 250).Mandatory();
            String("Code", 50).Mandatory();
            BigString("Description");
            Money("Price").Mandatory();
            Int("Quantity").Mandatory();
            Bool("IsActive").Mandatory();
            DateTime("CreatedDate").Mandatory().Default(cs("LocalTime.Now"));
            DateTime("AvailableFrom");
            DateTime("AvailableTo");
            String("Image", 500);
            String("Manual", 500);

            Associate<Category>("Category").Mandatory().OnDelete(CascadeAction.CascadeDelete);

            String("SearchText").Calculated().Getter("Name + \" \" + Code + \" \" + (Description ?? \"\")");
        }
    }
}

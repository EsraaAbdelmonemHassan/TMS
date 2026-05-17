using MSharp;

namespace Domain
{
    public class Category : EntityType
    {
        public Category()
        {
            String("Name", 200).Mandatory();
            String("Description", 1000);
            Int("SortOrder").Mandatory();
            Bool("IsActive").Mandatory();

            Associate<Category>("Parent");
        }
    }
}

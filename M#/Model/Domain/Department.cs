using MSharp;

namespace Domain
{
    public class Department : EntityType
    {
        public Department()
        {
            String("Name").Mandatory();
            String("Description");
        }
    }
}

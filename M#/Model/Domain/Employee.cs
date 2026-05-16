using MSharp;

namespace Domain
{
    public class Employee : EntityType
    {
        public Employee()
        {
            String("First name").Mandatory();
            String("Last name").Mandatory();
            Associate<Department>("Department").Mandatory();
        }
    }
}

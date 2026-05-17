using MSharp;

namespace Domain
{
    public class Employee : Person
    {
        public Employee()
        {
            String("EmployeeNumber", 50).Mandatory();
            String("Position", 100);
            Associate<Department>("Department").Mandatory();
        }
    }
}

using MSharp;

namespace Domain
{
    public class Student : EntityType
    {
        public Student()
        {
            String("FirstName", 100).Mandatory();
            String("LastName", 100).Mandatory();
            String("Name").Calculated().Getter("FirstName + \" \" + LastName");
        }
    }
}

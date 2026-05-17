using MSharp;

namespace Domain
{
    public abstract class Person : EntityType
    {
        public Person()
        {
            Abstract();

            String("FirstName", 100).Mandatory();
            String("LastName", 100).Mandatory();
            String("Name").Calculated().Getter("FirstName + \" \" + LastName");
            String("Email", 250).Mandatory();
            String("PhoneNumber", 50);
            DateTime("CreatedDate").Mandatory().Default(cs("LocalTime.Now"));
        }
    }
}

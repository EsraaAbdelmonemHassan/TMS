using MSharp;

namespace Domain
{
    public class ApplicationEventLog : EntityType
    {
        public ApplicationEventLog()
        {
            DateTime("Timestamp").Mandatory().Default(cs("LocalTime.Now"));
            String("UserName", 250);
            String("EventType", 100).Mandatory();
            String("Description", 2000);
            String("EntityName", 200);
            Guid("EntityId");
        }
    }
}

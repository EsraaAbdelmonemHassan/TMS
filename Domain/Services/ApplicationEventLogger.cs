namespace Domain
{
    using System;
    using System.Threading.Tasks;
    using Olive;
    using Olive.Entities;

    public static class ApplicationEventLogger
    {
        static IDatabase Database => Context.Current.Database();

        public static async Task LogAsync(string entityName, string eventType, Guid? entityId, string description)
        {
            var entry = new ApplicationEventLog
            {
                Timestamp = LocalTime.Now,
                UserName = Context.Current.User()?.Identity?.Name,
                EventType = eventType,
                EntityName = entityName,
                EntityId = entityId,
                Description = description
            };

            await Database.Save(entry);
        }
    }
}

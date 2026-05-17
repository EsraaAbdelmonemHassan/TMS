using MSharp;

namespace Domain
{
    public class Course : EntityType
    {
        public Course()
        {
            String("Name", 200).Mandatory();
            String("Code", 50).Mandatory();
        }
    }
}

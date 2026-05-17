using MSharp;

namespace Domain
{
    public class StudentCourse : EntityType
    {
        public StudentCourse()
        {
            Associate<Student>("Student").Mandatory();
            Associate<Course>("Course").Mandatory();
        }
    }
}

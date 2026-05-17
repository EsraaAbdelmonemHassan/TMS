namespace Domain
{
    using System.Threading.Tasks;
    using Olive;
    using Olive.Entities;

    partial class StudentCourse
    {
        public override async Task Validate()
        {
            if (StudentId != null && CourseId != null)
            {
                var duplicate = await Database.Of<StudentCourse>()
                    .Where(x => x.StudentId == StudentId && x.CourseId == CourseId && x.ID != ID)
                    .FirstOrDefault();

                if (duplicate != null)
                    throw new ValidationException("Student is already registered for this course.");
            }

            await base.Validate();
        }
    }
}

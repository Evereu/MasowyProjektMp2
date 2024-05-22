

namespace MP2v2
{
    public class CourseMember
    {

        //wiele

        public Member Member { get; set;}
        public Course Course { get; set;}
        public DateTime EnrollmentDate { get; set;}
        public DateTime? CompletionDate { get; set;}


        public CourseMember(Member member, Course course, DateTime enrollmentDate, DateTime? completionDate = null)
        {
            Member = member;
            Course = course;
            EnrollmentDate = enrollmentDate;    
            CompletionDate = completionDate;
        }




    }
}

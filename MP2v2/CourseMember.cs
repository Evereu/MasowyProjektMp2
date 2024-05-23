

namespace MP2v2
{
    public class CourseMember
    {

        //wiele
        //MP2 asocjacja zwykła/Asocjacja z atrybutem
        public Member? Member { get; set;}
        public Course? Course { get; set;}
        public DateTime EnrollmentDate { get; set;}
        public DateTime? CompletionDate { get; set;}

        //MP2 asocjacja zwykła/Asocjacja z atrybutem
        public CourseMember(Member member, Course course, DateTime enrollmentDate, DateTime? completionDate = null)
        {
            Member = member;
            Course = course;
            EnrollmentDate = enrollmentDate;    
            CompletionDate = completionDate;

            member.AddMemberToCourse(this);
            course.AddCourseToMember(this);

        }
        //MP2 asocjacja zwykła/Asocjacja z atrybutem
        public void RemoveMemberCourse()
        {
            if (Member != null)
            {
                Member.RemoveMemberFromCourse(this);
                Member = null;
            }

            if (Course != null)
            {
                Course.RemoveCourseFromMember(this);
                Course = null;
            }
        }
    }
}



namespace MP2v2
{
    public class Member
    {
        //jeden

        public string name { get; set; }

        //MP2 asocjacja zwykła/Asocjacja z atrybutem
        private List<CourseMember> memberCourses = new List<CourseMember>();

        public Member(string name)
        {
            this.name = name;
        }


        public void AddCourse(Course course, DateTime enrollmentDate, DateTime? completionDate = null)
        {
            var courseMember = new CourseMember(this, course, enrollmentDate, completionDate);
            if (!memberCourses.Contains(courseMember))
            {
                memberCourses.Add(courseMember);
                course.AddCourseToMember(courseMember);
            }
        }


        public void AddMemberToCourse(CourseMember member) //MP2 asocjacja zwykła/Asocjacja z atrybutem
        {
            if (!memberCourses.Contains(member))
            {
                memberCourses.Add(member);

                member.Member = this;
            }
        }

        public void RemoveMemberFromCourse(CourseMember member) 
        {
            if (memberCourses.Contains(member))
            {
                memberCourses.Remove(member);

                member.Member = null;
            }
        }



    }
}

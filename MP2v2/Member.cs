

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

        
        public void AddMemberToCourse(CourseMember courseMember)
        {
            if (!memberCourses.Contains(courseMember))
            {
                memberCourses.Add(courseMember);

                courseMember.Member = this;
            }
        }

        public void RemoveMemberFromCourse(CourseMember courseMember)
        {
            if (memberCourses.Contains(courseMember))
            {
                memberCourses.Remove(courseMember);

                courseMember.Member = null;
            }
        }



    }
}

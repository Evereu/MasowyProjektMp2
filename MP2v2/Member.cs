

namespace MP2v2
{
    public class Member
    {
        private string Name { get; set; }

        private string Surname { get; set; }

        //MP2 asocjacja zwykła/Asocjacja z atrybutem
        private List<CourseMember> MemberCourses = new List<CourseMember>();

        public Member(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        //MP2 asocjacja zwykła/Asocjacja z atrybutem
        public void AddMemberToCourse(CourseMember courseMember)
        {
            if (!MemberCourses.Contains(courseMember))
            {
                MemberCourses.Add(courseMember);

                courseMember.Member = this;

            }
        }

        //MP2 asocjacja zwykła/Asocjacja z atrybutem
        public void RemoveMemberFromCourse(CourseMember courseMember)
        {
            if (MemberCourses.Contains(courseMember))
            {
                MemberCourses.Remove(courseMember);

                courseMember.RemoveMemberCourse();

            }
        }
    }
}

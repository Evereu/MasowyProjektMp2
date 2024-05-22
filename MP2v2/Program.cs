namespace MP2v2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var startDate = DateTime.Now;


            Member member1 = new Member("Jan", "Kowalski");
            Member member2 = new Member("Kamil", "Ściana");

            Creator creator1 = new Creator(1, "Michal", "B");
            Creator creator2 = new Creator(2, "John", "S");

            Course course1 = new Course(1, "Finanse dla Menedżerów");
            Course course2 = new Course(2, "Rachunek różniczkowy i całkowy");
            Course course3 = new Course(3, "Programowanie w języku C#");

            Category programowanie = new Category("Programowanie");
            Category matematyka = new Category("Matematyka");
            Category finanse = new Category("Finanse");

            course1.AddCategory(finanse);
            course2.AddCategory(matematyka);
            course3.AddCategory(programowanie);

            creator1.AddCourseToCreatorQualif(course1);
            creator1.AddCourseToCreatorQualif(course2);

           CourseMember courseMember = new CourseMember(member1, course1, startDate);

            member1.RemoveMemberFromCourse(courseMember);


            Video.createVideo("movie1", course1);

        }
    }
}

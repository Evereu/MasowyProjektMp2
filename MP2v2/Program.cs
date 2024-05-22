namespace MP2v2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Member member1 = new Member("Jan", "Kowalski");
            Member member2 = new Member("Kamil", "Ściana");

            Creator creator1 = new Creator(1, "Michal", "B");

            Course course1 = new Course(1, "Finanse dla Menedżerów");
            Course course2 = new Course(2, "Rachunek różniczkowy i całkowy");
            Course course3 = new Course(3, "Programowanie w języku C#");

            Category programowanie = new Category("Programowanie");
            Category matematyka = new Category("Matematyka");
            Category finanse = new Category("Finanse");

            

            course1.AddCategory(finanse);
            course2.AddCategory(matematyka);
            course3.AddCategory(programowanie);





        }
    }
}

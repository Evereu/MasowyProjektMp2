namespace MP2v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var member1 = new Member("John Doe");
            var course1 = new Course(1, "C# Programming");

            member1.AddCourse(course1, DateTime.Now);

            Console.WriteLine(member1);
            Console.WriteLine(course1);
        }
    }
}

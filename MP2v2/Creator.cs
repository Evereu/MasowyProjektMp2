namespace MP2v2
{
    public class Creator
    {
        private int CreatorId { get; set; }
        private string Name { get; set; }

        private string Surname { get; set; }

        //MP2 asocjacja kwalifikowana identyfikator, kurs nullowalne znakiem zapytania bo 0, 1
        private Dictionary<int, Course?> CreatorsCourseQualif = new Dictionary<int, Course?>();


        //Zamienić asocjacje kwalifikowaną z Creatora do Course jako miejsce na słownik i przechowywanie tej asocjacji 



        public Creator(int creatorId, string name, string surname)
        {
            CreatorId = creatorId;
            Name = name;
            Surname = surname;
        }


        //MP2 Asocjacja kwalifikowana
        //W creatorze przechowujemy jego kursy
        public void AddCourseToCreatorQualif(Course course)
        {
            if (!CreatorsCourseQualif.ContainsKey(course.CourseId))
            {
                CreatorsCourseQualif.Add(course.CourseId, course);

                //MP2 Informacja zwrotna, asocjacja kwalifikowana
                course.CreatorsQualif.Add(this);
            }
        }

        //MP2 Asocjacja kwalifikowana
        public void RemoveCourseFromCreatorQualif(Course course)
        {
            if (CreatorsCourseQualif.ContainsKey(course.CourseId))
            {
                CreatorsCourseQualif.Remove(course.CourseId);

                //MP2 usuwanie informacji zwrotej, asocjacja kwalifikowana
                course.CreatorsQualif.Remove(this);
            }
        }

        //MP2 Asocjacja kwalifikowana
        public Course showCourseQualif(int id)
        {
            if (!CreatorsCourseQualif.ContainsKey(id))
            {
                throw new Exception("Brak odpowiadającego kursu");
            }
            return CreatorsCourseQualif[id];
        }
    }
}

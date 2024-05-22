namespace MP2v2
{
    public class Creator
    {
        public int CreatorId { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public List<Course> CourseQualif = new List<Course>();   //MP2 Asocjacja kwalfikowana lista do informacji zwrotnej

        public Creator(int creatorId, string name, string surname)
        {
            CreatorId = creatorId;
            Name = name;
            Surname = surname;
        }
    }
}

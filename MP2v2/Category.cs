namespace MP2v2
{
    public class Category
    {
        public string Name { get; set; }

        public Course Course { get; set; }


        public Category(string name)
        {
            Name = name;
        }

        //MP2 zwykła asocjacja
        public void AddCourseToCategory(Course course)
        {
            Course = course;

            course.AddCategory(this);
        }

        //MP2 zwykła asocjacja
        public void RemoveCourseFromCategory(Course course)
        {
            Course = null;

            course.RemoveCategory(this);
        }
    }
}

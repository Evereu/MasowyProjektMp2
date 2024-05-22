using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP2v2
{
    public class Course
    {

        //Aktor

        public int CourseId { get; set; }
        private string Title { get; set; }

        private List<CourseMember> memberCourses = new List<CourseMember>(); //MP2 asocjacja zwykła/Asocjacja z atrybutem
      
        private List<Video> VideosParts = new List<Video>(); //MP2 kopozycja
        
        private static HashSet<Video> AllVideos = new HashSet<Video>(); //MP2 kopozycja  zakazanie współdzielenia części. MP2 kompozycja

        public List<Category> Categories = new List<Category>(); //MP2 zwykła asocjacja


        //MP2 asocjacja kwalifikowana identyfikator, kurs nullowalne znakiem zapytania bo 0, 1
        private Dictionary<int, Creator?> CreatorsCourseQualif = new Dictionary<int, Creator?>();


        public Course(int courseId, string title) 
        { 
            CourseId = courseId;
            Title = title;
        }


        //MP2 Asocjacja kwalifikowana
        //W creatorze przechowujemy jego kursy przez referencje 
        public void AddCourseToCreatorQualif(Creator creator)
        {
            if (!CreatorsCourseQualif.ContainsKey(creator.CreatorId))
            {
                CreatorsCourseQualif.Add(creator.CreatorId, creator);

                //MP2 Informacja zwrotna, asocjacja kwalifikowana
                creator.CourseQualif.Add(this);
            }
        }

        //MP2 Asocjacja kwalifikowana przez referencje 
        public void RemoveCourseFromCreatorQualif(Creator creator)
        {
            if (CreatorsCourseQualif.ContainsKey(creator.CreatorId))
            {
                CreatorsCourseQualif.Remove(creator.CreatorId);

                //MP2 usuwanie informacji zwrotej, asocjacja kwalifikowana
                creator.CourseQualif.Remove(this);
            }
        }

        //MP2 Asocjacja kwalifikowana
        public Creator showCourseQualif(int id)
        {
            if (!CreatorsCourseQualif.ContainsKey(id))
            {
                throw new Exception("Brak odpowiadającego kursu");
            }
            return CreatorsCourseQualif[id];
        }


        public void AddCategory(Category category) //MP2 zwykła asocjacja
        {
            if (!Categories.Contains(category))
            {
                Categories.Add(category);

                //Połączenie zwrotne
                category.AddCourseToCategory(this);
            }
        }
      
        public void RemoveCategory(Category category)   //MP2 zwykła asocjacja
        {
            if (Categories.Contains(category))
            {
                Categories.Remove(category);

                //Połączenie zwrotne
                category.RemoveCourseFromCategory(this);
            }
        }


        public void AddVideoPart(Video video)   //MP2 kopozycja
        {
            if (!VideosParts.Contains(video))
            {
                if (AllVideos.Contains(video))
                {
                    throw new Exception("Takie wideo w kursie już istnieje");
                }
            }
            VideosParts.Add(video);
            AllVideos.Add(video);
        }

        public void RemoveVideoPart(Video video) //MP2 kopozycja
        {
            if (VideosParts.Contains(video))
            {
                VideosParts.Remove(video);
                AllVideos.Remove(video);
            }
            else
            {
                throw new Exception("Nie znaleziono takiego video");
            }
        }


        public void AddCourseToMember(CourseMember courseMember) //MP2 asocjacja zwykła/Asocjacja z atrybutem
        {
            if (!memberCourses.Contains(courseMember))
            {
                memberCourses.Add(courseMember);

                courseMember.Course = this;
            }
        }

        public void RemoveCourseFromMember(CourseMember courseMember) //MP2 asocjacja zwykła/Asocjacja z atrybutem
        {
            if (memberCourses.Contains(courseMember))
            {
                memberCourses.Remove(courseMember);

                courseMember.Course = null;
            }
        }
    }
}

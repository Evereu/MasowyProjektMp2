﻿namespace MP2v2
{
    public class Course
    {
        public int CourseId { get; set; }
        private string Title { get; set; }

        private List<CourseMember> memberCourses = new List<CourseMember>(); //MP2 asocjacja zwykła/Asocjacja z atrybutem

        public List<Creator> CreatorsQualif = new List<Creator>();   //MP2 Asocjacja kwalfikowana lista do informacji zwrotnej

        private List<Video> VideosParts = new List<Video>(); //MP2 kopozycja

        private static HashSet<Video> AllVideos = new HashSet<Video>(); //MP2 kopozycja  zakazanie współdzielenia części. MP2 kompozycja

        public List<Category> Categories = new List<Category>(); //MP2 zwykła asocjacja

        public Course(int courseId, string title)
        {
            CourseId = courseId;
            Title = title;
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

                courseMember.RemoveMemberCourse();
            }
        }
    }
}

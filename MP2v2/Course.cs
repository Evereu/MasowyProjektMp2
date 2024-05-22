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

        //whole

        public int CourseId { get; set; }
        private string Title { get; set; }


        private List<CourseMember> memberCourses = new List<CourseMember>(); //MP2 asocjacja zwykła/Asocjacja z atrybutem


        //MP2 Asocjacja kwalfikowana lista do informacji zwrotnej
        public List<Creator> CreatorsQualif = new List<Creator>();


        private List<Video> VideosParts = new List<Video>(); //MP2 kopozycja

        //zakazanie współdzielenia części. MP2 kompozycja
        private static HashSet<Video> AllVideos = new HashSet<Video>(); //MP2 kopozycja


        public Course(int courseId, string title) 
        { 
            CourseId = courseId;
            Title = title;
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


        public void AddCourseToMember(CourseMember member) //MP2 asocjacja zwykła/Asocjacja z atrybutem
        {
            if (!memberCourses.Contains(member))
            {
                memberCourses.Add(member);

                member.Course = this;
            }
        }

        public void RemoveCourseFromMember(CourseMember member) //MP2 asocjacja zwykła/Asocjacja z atrybutem
        {
            if (memberCourses.Contains(member))
            {
                memberCourses.Remove(member);

                member.Course = null;
            }
        }
    }
}

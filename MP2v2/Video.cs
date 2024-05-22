using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP2v2
{
    public class Video
    {
        //part

        //MP2 kompozycja

        private string Name { get; set; }

        public Course Course { get; set; }  

        //Konstruktor klasy. Zwróćmy uwagę na to, że jest prywatny. Dzięki temu tylko metody z tej samej klasy mogą tworzyć jej instancje.

        private Video(string name, Course course)
        {
            Name = name;
            Course = course;
        }

        //MP2 kompozycja
        public static Video createVideo(string name, Course course)
        {
            if(course == null)
            {
                throw new ArgumentNullException("Podana część nie istnieje");
            }

            Video video = new Video(name, course);
            course.AddVideoPart(video);

            return video;
        }
    }
}

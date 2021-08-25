using PP_ShapeInfo.Models;
using System.Collections.Generic;

namespace PP_ShapeInfo.Models
{
    public class Presentation
    {
        private IEnumerable<Slide> enumerable;

        public Presentation(ICollection<Slide> slides)
        {
            Slides = slides;
        }

        public Presentation(IEnumerable<Slide> enumerable)
        {
            this.enumerable = enumerable;
        }

        public ICollection<Slide> Slides { get; }
    }
}

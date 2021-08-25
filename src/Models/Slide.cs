using PP_ShapeInfo.Models;
using System.Collections.Generic;

namespace PP_ShapeInfo.Models
{
    public class Slide
    {
        public Slide(ICollection<Shape> slideShapes)
        {
            SlideShapes = slideShapes;
        }

        public ICollection<Shape> SlideShapes { get; }
    }
}

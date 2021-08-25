using PP_ShapeInfo.Models;
using System.Collections.Generic;

namespace Models.PP_ShapeInfo.Models
{
    public class PP_Slide
    {
        public PP_Slide(ICollection<PP_Shape> slideShapes)
        {
            SlideShapes = slideShapes;
        }

        public ICollection<PP_Shape> SlideShapes { get; }
    }
}

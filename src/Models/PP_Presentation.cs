using Models.PP_ShapeInfo.Models;
using System.Collections.Generic;

namespace PP_ShapeInfo.Models
{
    public class PP_Presentation
    {
        public PP_Presentation(ICollection<PP_Slide> slides)
        {
            Slides = slides;
        }

        public ICollection<PP_Slide> Slides { get; }
    }
}

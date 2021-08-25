using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using Models.PP_ShapeInfo.Models;
using PP_ShapeInfo.Models;
using System.Collections.Generic;
using System.IO;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace PP_ShapeInfo.Services
{
    class PP_ApplicationService
    {

        internal PP_ApplicationService()
        {
            PPApp = new Application();
            PPPres = PPApp.Presentations;
        }

        public Application PPApp { get; }

        public Presentations PPPres { get; }

        public PP_Presentation ExtractPresentationInfo(FileInfo fileInfo)
        {
            Presentation presentation = PPPres.Open(fileInfo.FullName, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);
            var slides = GetSlides(presentation);
            return new PP_Presentation(slides);
        }

        private static ICollection<PP_Slide> GetSlides(Presentation presentation)
        {
            var slides = new List<PP_Slide>();
            foreach (Slide slide in presentation.Slides)
            {
                var slideShapes = GetSlideShapes(slide);
                slides.Add(new PP_Slide(slideShapes));
            }
            return slides;
        }

        private static List<PP_Shape> GetSlideShapes(Slide slide)
        {
            var slideShapes = new List<PP_Shape>();
            foreach (PowerPoint.Shape shape in slide.Shapes)
            {
                switch (shape.Type)
                {
                    case MsoShapeType.msoGroup:
                        var groupShapes = new List<PP_Shape>();
                        foreach (PowerPoint.Shape groupShape in shape.GroupItems)
                        {
                            groupShapes.Add(new PP_Shape(groupShape.Type));
                        }
                        slideShapes.Add(new PP_Shape(shape.Type, groupShapes));
                        break;
                    default:
                        slideShapes.Add(new PP_Shape(shape.Type));
                        break;

                }

            }

            return slideShapes;
        }
    }
}

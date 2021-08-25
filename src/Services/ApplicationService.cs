using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using PP_ShapeInfo.Models;
using System.Collections.Generic;
using System.IO;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace PP_ShapeInfo.Services
{
    public interface IApplicationService
    {
        Models.Presentation ExtractPresentationInfo(string fileName);
    }

    public class ApplicationService : IApplicationService
    {

        public ApplicationService()
        {
            PPApp = new PowerPoint.Application();
            PPPres = PPApp.Presentations;
        }

        private Application PPApp { get; }

        private Presentations PPPres { get; }

        public Models.Presentation ExtractPresentationInfo(string fileName)
        {
            PowerPoint.Presentation presentation = PPPres.Open(fileName, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);
            var slides = GetSlides(presentation);
            presentation.Close();

            return new Models.Presentation(slides);
        }

        private static ICollection<Models.Slide> GetSlides(PowerPoint.Presentation presentation)
        {
            var slides = new List<Models.Slide>();
            foreach (PowerPoint.Slide slide in presentation.Slides)
            {
                var slideShapes = GetSlideShapes(slide);
                slides.Add(new Models.Slide(slideShapes));
            }
            return slides;
        }

        private static List<Models.Shape> GetSlideShapes(PowerPoint.Slide slide)
        {
            var slideShapes = new List<Models.Shape>();
            foreach (PowerPoint.Shape shape in slide.Shapes)
            {
                switch (shape.Type)
                {
                    case MsoShapeType.msoGroup:
                        var groupShapes = new List<Models.Shape>();
                        foreach (PowerPoint.Shape groupShape in shape.GroupItems)
                        {
                            groupShapes.Add(new Models.Shape((ShapeType)(int)groupShape.Type));
                        }
                        slideShapes.Add(new Models.Shape((ShapeType)(int)shape.Type, groupShapes));
                        break;
                    default:
                        slideShapes.Add(new Models.Shape((ShapeType)(int) shape.Type));
                        break;

                }

            }

            return slideShapes;
        }
    }
}

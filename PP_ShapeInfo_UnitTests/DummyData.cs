using PP_ShapeInfo.Models;
using System.Collections.Generic;

namespace PP_ShapeInfo_UnitTests
{
    static class DummyData
    {
        public static IReadOnlyCollection<Shape> GroupShapes = new List<Shape>()
        {
            new Shape(ShapeType.InkComment),
            new Shape(ShapeType.TextBox)
        };

        public static ICollection<Shape> SlideShapes = new List<Shape>()
        {
            new Shape(ShapeType.AutoShape),
            new Shape(ShapeType.Group, GroupShapes)
        };

        public static ICollection<Slide> Slides = new List<Slide>()
        {
            new Slide(SlideShapes),
            new Slide(new List<Shape>()
            {
                new Shape(ShapeType.TextBox),
                new Shape(ShapeType.TextBox)
            })
        };
    }
}

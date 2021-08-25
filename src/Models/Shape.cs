using Microsoft.Office.Core;
using System.Collections.Generic;

namespace PP_ShapeInfo.Models
{
    public class Shape
    {
        public Shape(ShapeType type)
        {
            Type = type;
        }

        public Shape(ShapeType type, IReadOnlyCollection<Shape> groupItems)
        {
            Type = type;
            GroupItems = groupItems;
        }

        public IReadOnlyCollection<Shape> GroupItems { get; }

        public ShapeType Type { get; }
    }
}

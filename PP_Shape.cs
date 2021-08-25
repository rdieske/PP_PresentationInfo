using Microsoft.Office.Core;
using System.Collections.Generic;

namespace PP_ShapeInfo
{
    public class PP_Shape
    {
        public PP_Shape(MsoShapeType type)
        {
            Type = type;
        }

        public PP_Shape(MsoShapeType type, IReadOnlyCollection<PP_Shape> groupItems)
        {
            Type = type;
            GroupItems = groupItems;
        }

        public IReadOnlyCollection<PP_Shape> GroupItems { get; }

        public MsoShapeType Type { get; }
    }
}

using PP_ShapeInfo.Models;
using System.Collections.Generic;
using Xunit;

namespace PP_ShapeInfo_UnitTests.Models
{
    public class Shape_Tests
    {
        [Theory]
        [InlineData(ShapeType.Callout)]
        [InlineData(ShapeType.SmartArt)]
        [InlineData(ShapeType.Group)]
        [InlineData(ShapeType.TextBox)]
        public void Shape_PassShapeType_ShouldConstructCorrect(ShapeType shapeType)
        {
            var sut = new Shape(shapeType);

            Assert.Equal(shapeType, sut.Type);
        }

        [Fact]
        public void Shape_PassShapeTypeAndGroupItems_ShouldConstructCorrect()
        {
            var sut = new Shape(ShapeType.Group, DummyData.GroupShapes);

            Assert.Equal(ShapeType.Group, sut.Type);
            Assert.Equal(DummyData.GroupShapes, sut.GroupItems);
        }
    }
}

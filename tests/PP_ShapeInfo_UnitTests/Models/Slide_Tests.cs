using PP_ShapeInfo.Models;
using System.Collections.Generic;
using Xunit;

namespace PP_ShapeInfo_UnitTests.Models
{
    public class Slide_Tests
    {
        [Fact]
        public void Slide_PassSlideShapes_ShouldConstructWithSlideShapes()
        {
            var sut = new Slide(DummyData.SlideShapes);

            Assert.Equal(DummyData.SlideShapes, sut.SlideShapes);
        }
    }
}

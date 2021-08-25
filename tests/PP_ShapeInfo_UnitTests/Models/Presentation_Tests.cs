using PP_ShapeInfo.Models;
using System.Collections.Generic;
using Xunit;

namespace PP_ShapeInfo_UnitTests.Models
{
    public class Presentation_Tests
    {
        [Fact]
        public void Presentation_PassSlids_ShouldConstructWithSlides()
        {
            var sut = new Slide(DummyData.SlideShapes);

            Assert.Equal(DummyData.SlideShapes, sut.SlideShapes);
        }
    }
}

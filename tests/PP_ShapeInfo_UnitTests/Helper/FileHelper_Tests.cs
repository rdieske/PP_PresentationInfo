using NSubstitute;
using PP_ShapeInfo.Helper;
using Xunit;

namespace PP_ShapeInfo_UnitTests
{
    public class FileHelper_Tests
    {
        [Theory]
        [InlineData("xls", false)]
        [InlineData("pdf", false)]
        [InlineData("ppt", true)]
        [InlineData("pptx", true)]
        public void IsSupportedFileExtension_PassExtensions_ShouldReturnExpectedValue(string extension, bool expectedValue)
        {
            var sut = new FileHelper();

            var returnValue = sut.IsSupportedPresentationFile(extension);

            Assert.Equal(expectedValue, returnValue);
        }
    }
}

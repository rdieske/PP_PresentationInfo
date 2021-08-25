using NSubstitute;
using PP_ShapeInfo;
using PP_ShapeInfo.Models;
using PP_ShapeInfo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PP_ShapeInfo_UnitTests
{
    public class FileHandler_Tests
    {
        public FileHandler_Tests()
        {
            ApplicationService = Substitute.For<IApplicationService>();
        }

        public IApplicationService ApplicationService { get; }

        [Fact]
        public void HandleFileOpen_PassNull_ShouldReturnEmptyPresentationCollection()
        {
            var sut = new FileHandler(ApplicationService);

            var presentations = sut.HandleFileOpen(null);

            Assert.Empty(presentations);
        }

        [Fact]
        public void HandleFileOpen_PassEmptyArray_ShouldReturnEmptyPresentationCollection()
        {
            var sut = new FileHandler(ApplicationService);

            var presentations = sut.HandleFileOpen(Array.Empty<string>());

            Assert.Empty(presentations);
        }

        [Fact]
        public void HandleFileOpen_PassListOfPresentationPathes_ShouldReturnPresentationCollection()
        {
            var filePathes = new string[]
            {
                "C:\\AnyPath\\presentation.ppt",
                "C:\\AnyPath\\Subfolder\\presentation.pptx",
            };

            var sut = new FileHandler(ApplicationService);
            var expectedPresentations = new List<Presentation>()
            {
                new Presentation(Enumerable.Empty<Slide>()),
                new Presentation(Enumerable.Empty<Slide>()),
            };

            ApplicationService.ExtractPresentationInfo("C:\\AnyPath\\presentation.ppt").Returns(expectedPresentations[0]);
            ApplicationService.ExtractPresentationInfo("C:\\AnyPath\\Subfolder\\presentation.pptx").Returns(expectedPresentations[1]);
            var presentations = sut.HandleFileOpen(filePathes);

            Assert.Equal(presentations, expectedPresentations);
        }
    }
}
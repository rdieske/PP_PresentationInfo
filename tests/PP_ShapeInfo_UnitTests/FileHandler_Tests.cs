using NSubstitute;
using PP_ShapeInfo;
using PP_ShapeInfo.Helper;
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
            FileHelper = Substitute.For<IFileHelper>();
        }

        public IApplicationService ApplicationService { get; }
        IFileHelper FileHelper { get; }

        [Fact]
        public void HandleFileOpen_PassNull_ShouldReturnEmptyPresentationCollection()
        {
            var sut = new FileHandler(ApplicationService, FileHelper);

            var presentations = sut.HandleFileOpen(null);

            Assert.Empty(presentations);
        }

        [Fact]
        public void HandleFileOpen_PassEmptyArray_ShouldReturnEmptyPresentationCollection()
        {
            var sut = new FileHandler(ApplicationService, FileHelper);

            var presentations = sut.HandleFileOpen(Array.Empty<string>());

            Assert.Empty(presentations);
        }

        [Fact]
        public void HandleFileOpen_PassListOfPresentationPathes_ShouldReturnExpectedPresentationCollection()
        {
            var filePathes = new string[]
            {
                "C:\\AnyPath\\presentation.ppt",
                "C:\\AnyPath\\Subfolder\\presentation.xls",
                "C:\\AnyPath\\Subfolder\\presentation.pptx",
                "C:\\AnyPath\\Subfolder\\presentation.pdf",
            };

            var sut = new FileHandler(ApplicationService, FileHelper);
            var expectedPresentations = new List<Presentation>()
            {
                new Presentation(Enumerable.Empty<Slide>()),
                new Presentation(Enumerable.Empty<Slide>()),
            };
            FileHelper.IsSupportedPresentationFile(Arg.Any<string>()).ReturnsForAnyArgs(false);
            FileHelper.IsSupportedPresentationFile("ppt").Returns(true);
            FileHelper.IsSupportedPresentationFile("pptx").Returns(true);

            ApplicationService.ExtractPresentationInfo("C:\\AnyPath\\presentation.ppt").Returns(expectedPresentations[0]);
            ApplicationService.ExtractPresentationInfo("C:\\AnyPath\\Subfolder\\presentation.pptx").Returns(expectedPresentations[1]);

            var presentations = sut.HandleFileOpen(filePathes);

            Assert.Equal(expectedPresentations, presentations);
        }
    }
}
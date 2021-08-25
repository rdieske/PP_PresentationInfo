using System;

namespace PP_ShapeInfo.Helper
{
    public interface IFileHelper
    {
        bool IsSupportedPresentationFile(string extension);
    }

    public class FileHelper : IFileHelper
    {
        public bool IsSupportedPresentationFile(string extension)
        {
            return Enum.TryParse<SupportedFileExtensions>(extension, out _);
        }
    }
}

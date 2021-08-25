using System;

namespace PP_ShapeInfo.Helper
{
    public static class PresentationHelper
    {
        public static bool IsSupportedPresentationFile(string extension)
        {
            return Enum.TryParse<SupportedFileExtensions>(extension, out _);
        }
    }
}

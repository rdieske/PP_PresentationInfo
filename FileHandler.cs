using System;
using System.Collections.Generic;
using System.IO;

namespace PP_ShapeInfo
{
    internal class FileHandler
    {
        PP_ApplicationService PPApplicationService = new PP_ApplicationService();

        internal void HandleFileOpen(string[] files)
        {
            var presentationInfo = new List<PP_Presentation>();
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                if (IsSupportedFileExtension(fileInfo.Extension.TrimStart('.')))
                {
                    presentationInfo.Add(PPApplicationService.ExtractPresentationInfo(fileInfo));
                }
            }
        }

        private static bool IsSupportedFileExtension(string extension)
        {
            return Enum.TryParse<SupportedFileExtensions>(extension, out _);
        }

     
    }
}

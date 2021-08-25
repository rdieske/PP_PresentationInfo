using PP_ShapeInfo.Helper;
using PP_ShapeInfo.Models;
using PP_ShapeInfo.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace PP_ShapeInfo
{
    public class FileHandler
    {
        public FileHandler(IApplicationService applicationservice, IFileHelper fileHelper)
        {
            ApplicationService = applicationservice;
            FileHelper = fileHelper;
        }

        IApplicationService ApplicationService { get; }
        IFileHelper FileHelper { get; }

        public ICollection<Presentation> HandleFileOpen(string[] files)
        {
            var presentationInfo = new List<Presentation>();
            foreach (var file in files ?? Array.Empty<string>())
            {
                var fileInfo = new FileInfo(file);
                if (FileHelper.IsSupportedPresentationFile(fileInfo.Extension.TrimStart('.')))
                {
                    presentationInfo.Add(ApplicationService.ExtractPresentationInfo(fileInfo.FullName));
                }
            }
            return presentationInfo;
        }

    }
}

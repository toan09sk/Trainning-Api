
namespace WindowExplore.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Interfaces;
    using ViewModel;
    using AutoMapper;

    public class ManagementService : IManagementService
    {
        private readonly IMapper mapper;
        private readonly string Path = @"D:\Test\";
        public ManagementService(IMapper mapperInstance)
        {
            mapper = mapperInstance;
        }
        public IEnumerable<FileViewModel> GetAllFiles()
        {
            DirectoryInfo info = new DirectoryInfo(Path);
            FileInfo[] files = info.GetFiles("*", SearchOption.AllDirectories).OrderBy(p => p.CreationTime).ToArray();
            var filesDisplay = files.AsQueryable().Select(x => mapper.Map<FileViewModel>(x));
            return filesDisplay;
        }

        public bool RemoveFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }

            return false;
        }
    }
}
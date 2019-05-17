
namespace WindowExplore.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModel;

    public interface IManagementService
    {
        IEnumerable<FileViewModel> GetAllFiles();

        bool RemoveFile(string path);
    }
}

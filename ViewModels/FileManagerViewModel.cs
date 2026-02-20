using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace once.ViewModels
{
    public partial class FileManagerViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<FileItem> files;

        public FileManagerViewModel()
        {
            Files = new ObservableCollection<FileItem>
            {
                new FileItem { Name = "File1.mp4", Size = "500MB" },
                new FileItem { Name = "File2.mp4", Size = "1.2GB" },
                new FileItem { Name = "File3.mp4", Size = "800MB" },
                new FileItem { Name = "File1.mp4", Size = "500MB" },
                new FileItem { Name = "File2.mp4", Size = "1.2GB" },
                new FileItem { Name = "File3.mp4", Size = "800MB" },
                new FileItem { Name = "File1.mp4", Size = "500MB" },
                new FileItem { Name = "File2.mp4", Size = "1.2GB" },
                new FileItem { Name = "File3.mp4", Size = "800MB" },
                new FileItem { Name = "File1.mp4", Size = "500MB" },
                new FileItem { Name = "File2.mp4", Size = "1.2GB" },
                new FileItem { Name = "File3.mp4", Size = "800MB" },
                new FileItem { Name = "File1.mp4", Size = "500MB" },
                new FileItem { Name = "File2.mp4", Size = "1.2GB" },
                new FileItem { Name = "File3.mp4", Size = "800MB" }
            };
        }
    }

    public class FileItem
    {
        public string Name { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
    }
}
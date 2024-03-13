using day2.Contracts;
using day2.Models;

namespace day2.Services
{
    public class DirectoriesRepository : IDirectoriesRepository
    {
        public Task<bool> DeleteFilesAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetDirectoriesAsync(string dirName)
        {
            return Task.FromResult(Directory.GetDirectories(dirName).ToList());
        }

        public async Task<List<MyFile>> GetFilesAsync(string dirName)
        {
            await Task.Delay(1000);
            var fileNames = Directory.GetFiles(dirName);

            List<MyFile> files = new();
            //var v  = new List<MyFile>();
            // List<MyFile> v1 = new List<MyFile>();
            MyFile myFile;
            foreach (var file in fileNames)
            {
                var info = new FileInfo(file);
                myFile = new MyFile
                {
                    Extension = info.Extension,
                    ModificationDate = info.LastWriteTime,
                    Path = info.Name,
                    Size = info.Length
                };
                files.Add(myFile);
            }

            return files;

        }
    }
}

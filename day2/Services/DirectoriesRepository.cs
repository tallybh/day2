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
            throw new NotImplementedException();
        }

        public Task<List<MyFile>> GetFilesAsync(string dirName)
        {
            throw new NotImplementedException();
        }
    }
}

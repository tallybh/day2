using day2.Models;

namespace day2.Contracts
{
    public interface IDirectoriesRepository
    {
        Task<List<string>> GetDirectoriesAsync(string dirName);

        Task<List<MyFile>> GetFilesAsync(string dirName);

        Task<bool> DeleteFilesAsync(string fileName);
    }
}

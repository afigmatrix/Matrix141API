using Matrix1141EF.Data.Entity;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Interface
{
    public interface ILibraryRepository
    {
        Task Create(Library library);
        Task<Library> GetLibraryById(int id);
        Task<int> Submit();
    }
}

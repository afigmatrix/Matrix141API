using Matrix1141EF.Model.DTO;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Interface
{
    public interface ILibraryService
    {
        Task Create(LibraryCreateDto model);
        Task<LibraryGetByIdDto>GetLibraryById(int id);
    }
}

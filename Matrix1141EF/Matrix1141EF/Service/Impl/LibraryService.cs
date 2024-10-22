using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Repository.Interface;
using Matrix1141EF.Service.Interface;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Impl
{
    public class LibraryService : ILibraryService
    {
        private readonly IMapper mapper;
        private readonly ILibraryRepository libraryRepository;

        public LibraryService(IMapper mapper, ILibraryRepository libraryRepository)
        {
            this.mapper = mapper;
            this.libraryRepository = libraryRepository;
        }
        public async Task Create(LibraryCreateDto model)
        {
            var libraryEntity = mapper.Map<Library>(model);
            await libraryRepository.Create(libraryEntity);
            _ = await libraryRepository.Submit();
        }

        public async Task<LibraryGetByIdDto> GetLibraryById(int id)
        {
            var libraryEntity = await libraryRepository.GetLibraryById(id);
            var libraryDto = mapper.Map<LibraryGetByIdDto>(libraryEntity);
            return libraryDto;
        }
    }
}

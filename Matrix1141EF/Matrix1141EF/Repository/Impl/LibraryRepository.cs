using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Impl
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly AppDbContext context;

        public LibraryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task Create(Library library)
        {
            await context.Libraries.AddAsync(library);
        }

        public async Task<Library> GetLibraryById(int id)
        {
            return await context.Libraries.FindAsync(id);
        }

        public async Task<int> Submit()
        {
            return await context.SaveChangesAsync();
        }
    }
}

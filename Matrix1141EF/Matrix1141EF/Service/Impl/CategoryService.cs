using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Repository.Interface;
using Matrix1141EF.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Impl
{
    public class CategoryService : ICategoryService
    {
        public IMapper Mapper { get; set; }
        public ICategoryRepository categoryRepository { get; set; }
        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            Mapper = mapper;
            categoryRepository = categoryRepository;
        }
        public async Task CreateCategory(CategoryCreateDTO categoryCreateDTO)
        {
           
        }

        

       


       


























        public Task CreateProduct(CategoryCreateDTO categoryCreateDTO)
        {
            throw new System.NotImplementedException();
        }

        Task<ProductGetDTO> ICategoryService.GetProductByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateProduct(ProductCreateDTO productCreateDTO)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ProductGetDTO>> GetAllProducts()
        {
                var Result = await categoryRepository.GetAllCategories();
                var ResultGetDTO = Mapper.Map<List<CategoryGetDTO>>(Result);
                return ResultGetDTO;
        }

        public async Task DeleteProductByID(int id)
        {
                await categoryRepository.DeleteByID(id);
        }
    }
}

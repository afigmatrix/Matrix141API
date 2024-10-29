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
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(IMapper mapper,ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }
        public async Task CreateCategory(CategoryCreateDTO categoryCreateDTO)
        {
            var categoryEntity = mapper.Map<Category>(categoryCreateDTO);
            await categoryRepository.CreateCategory(categoryEntity);
        }


        public async Task<List<CategoryGetDTO>> GetAllCategories()
        {
            var categoryEntity=await categoryRepository.GetAllCategories();
            var resultCategories=mapper.Map<List<CategoryGetDTO>>(categoryEntity);
            return resultCategories;
        }


        public async Task DeleteCategory(string id)
        {
            await categoryRepository.DeleteCategory(id);
        }

        public async Task UpdateCategory(string id, CategoryUpdateDTO categoryUpdateDTO)
        {
            var categoryEntity=await categoryRepository.GetById(id);
            mapper.Map(categoryUpdateDTO,categoryEntity);
            await categoryRepository.UpdateCategory(categoryEntity);
        }

        public async Task<CategoryGetDTO> GetByID(string id)
        {
            var categoryEntity=await categoryRepository.GetById(id);
            var resultEntity=mapper.Map<CategoryGetDTO>(categoryEntity);
            return resultEntity;
        }
    }
}

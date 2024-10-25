using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Repository.Impl;
using Matrix1141EF.Repository.Interface;
using Matrix1141EF.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Impl
{
    public class ProductService : IProductService
    {
        public IMapper Mapper { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public ProductService(IMapper mapper,IProductRepository productRepository)
        {
            Mapper = mapper;
            ProductRepository = productRepository;
        }
        public async Task CreateProduct(ProductCreateDTO productCreateDTO)
        {
            var ProductEntity=Mapper.Map<Product>(productCreateDTO);
            await ProductRepository.ProductCreate(ProductEntity);
        }

        public async Task<List<ProductGetDTO>> GetAllProducts()
        {
            var Result = await ProductRepository.GetAllProducts();
            var ResultGetDTO = Mapper.Map<List<ProductGetDTO>>(Result);
            return ResultGetDTO;
        }

        public async Task<UserGetDTO> GetProductByID(int id)
        {
            var Result = await ProductRepository.GetByID(id);
            var MappedProduct = Mapper.Map<UserGetDTO>(Result);
            return MappedProduct;
        }

    
        public async Task DeleteProductByID(int id)
        {
            await ProductRepository.DeleteByID(id);
        }


















       

        public async Task<Product> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var ProductEntity = await ProductRepository.UpdateProduct(updateProductDTO.Name);

            if (ProductEntity == null)
            {
                return null;
            }
            ProductEntity.ProductName = updateProductDTO.Name;
            ProductEntity.ManufactureDate=updateProductDTO.ManufactireDate;
            return ProductEntity;
        }

        Task<ProductGetDTO> IProductService.GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(ProductCreateDTO productCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task CreateProduct(CategoryCreateDTO categoryCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryCreateDTO>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryGetDTO> GetCategoryByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(ProductCreateDTO productCreateDTO)
        {
            throw new NotImplementedException();
        }
    }
}

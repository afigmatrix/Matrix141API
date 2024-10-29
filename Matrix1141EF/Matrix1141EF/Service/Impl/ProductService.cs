using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Repository.Impl;
using Matrix1141EF.Repository.Interface;
using Matrix1141EF.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Impl
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductService(IMapper mapper,IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }


        public async Task CreateProduct(ProductCreateDTO productCreateDTO)
        {
            var productEntity = mapper.Map<Product>(productCreateDTO);
            await productRepository.CreateProduct(productEntity);
        }


        public async Task<List<ProductGetDTO>> GetAllProducts()
        {
            var productEntity = await productRepository.GetAllProducts();
            var resultProducts = mapper.Map<List<ProductGetDTO>>(productEntity);
            return resultProducts;
        }


        public async Task DeleteProduct(string id)
        {
            await productRepository.DeleteProduct(id);
        }

        public async Task UpdateProduct(string id, ProductUpdateDTO productUpdateDTO)
        {
            var productEntity = await productRepository.GetById(id);
            mapper.Map(productUpdateDTO, productEntity);
            await productRepository.UpdateProduct(productEntity);
        }

        public async Task<ProductGetDTO> GetByID(string id)
        {
            var productEntity = await productRepository.GetById(id);
            var resultEntity = mapper.Map<ProductGetDTO>(productEntity);
            return resultEntity;
        }

        public async Task CreateProductWithCategory(int categoryID, ProductCreateDTO productCreateDTO)
        {
            var productEntity=mapper.Map<Product>(productCreateDTO);
            await productRepository.CreateProductWithCategory(categoryID, productEntity);
        }
    }
}

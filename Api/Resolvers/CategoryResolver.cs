using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace Api.Resolvers
{

    [ExtendObjectType(Name = "Category")]
    public class CategoryResolver
    {
        public Task<Category> GetCategoryAsync(
          [Parent] Product product,
          [Service] ICategoryRepository categoryRepository) => categoryRepository.FindByCategoryId(product.CategoryId);
        public Task<Category> GetParentCategoryAsync(
         [Parent] Category category,
         [Service] ICategoryRepository categoryRepository) => categoryRepository.FindByCategoryId(category.ParentCategory);
    }
}


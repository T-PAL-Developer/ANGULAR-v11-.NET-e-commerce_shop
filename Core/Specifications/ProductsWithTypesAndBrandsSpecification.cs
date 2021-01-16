using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
  public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
  {
    public ProductsWithTypesAndBrandsSpecification(string sort, int? brandId, int? typeId)
    //filtering by BrandId and TypeId
    : base(x =>
      (!brandId.HasValue || x.ProductBrandId == brandId) &&
      (!typeId.HasValue || x.ProductTypeId == typeId)
    )
    {
      AddInclude(x => x.ProductType);
      AddInclude(x => x.ProductBrand);
      AddOrderBy(x => x.Name); //Alphabetic order (default)

      if (!string.IsNullOrEmpty(sort))// 3 statment by Price Ascending, Descending and by Name
      {
        switch (sort)
        {
          case "priceAsc":
            AddOrderBy(p => p.Price);
            break;
          case "priceDesc":
            AddOrderByDescending(p => p.Price);
            break;
          default:
            AddOrderBy(p => p.Name);
            break;
        }
      }
    }

    public ProductsWithTypesAndBrandsSpecification(int id)
    : base(x => x.Id == id)
    {
      AddInclude(x => x.ProductType);
      AddInclude(x => x.ProductBrand);
    }
  }
}
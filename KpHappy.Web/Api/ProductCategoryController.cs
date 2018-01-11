using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using KpHappy.Model.Models;
using KpHappy.Service;
using KpHappy.Web.Infrastructure.Core;
using KpHappy.Web.Models;

namespace KpHappy.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request, int page, int pageSize = 2)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var listCategory = _productCategoryService.GetAll();
                totalRow = listCategory.Count();

                var query = listCategory.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
    }
}
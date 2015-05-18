﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Core.BusinessLayer;
using NorthwindWebApi2.Models;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Controllers
{
    public class CategorySaleFor1997Controller : ApiController
    {
        protected ISalesUow Uow;

        public CategorySaleFor1997Controller(IUowService service)
        {
            Uow = service.GetSalesUow();
        }

        protected override void Dispose(Boolean disposing)
        {
            if (Uow != null)
            {
                Uow.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET: api/CategorySaleFor1997
        public HttpResponseMessage Get()
        {
            var result = new ApiResult();

            try
            {
                var list = Uow.CategorySaleFor1997Repository
                    .GetAll()
                    .ToList();

                result.Model = list;
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}

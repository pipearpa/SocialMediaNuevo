﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialMedia.Core.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessExeptions))
            {
                var exception = (BusinessExeptions)context.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad request", 
                    Detail = exception.Message

                };

                var json = new
                {
                    errors = new[] { validation }

                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;

            }
        }
    }
}

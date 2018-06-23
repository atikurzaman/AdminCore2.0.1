using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Application.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected string GetIpAddress()
        {
            return Request.HttpContext.Connection.RemoteIpAddress.ToString();
        }
        protected string GetMacAddress()
        {
            return Request.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        protected Int64 CreatedBy = 1;

        protected Int64 ModifiedBy = 1;

        protected DateTime CreatedDate = DateTime.Now;

        protected DateTime ModifiedDate = DateTime.Now;
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CouponController : ControllerBase
    {       
       

        public CouponController()
        {

        }

        [HttpGet]
        public void Get()
        {
           
        }
    }
}

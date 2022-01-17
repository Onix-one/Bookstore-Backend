using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.BLL.Interfaces;
using Bookstore.BLL.Services;

namespace Bookstore.Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class TypeOfBookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICustomerService _customerService;

        public TypeOfBookController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }
    }
}

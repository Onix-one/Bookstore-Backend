using AutoMapper;
using Bookstore.BLL.Services;
using Microsoft.AspNetCore.Mvc;

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

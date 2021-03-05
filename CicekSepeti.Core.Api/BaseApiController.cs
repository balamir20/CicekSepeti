using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace CicekSepeti.Core.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract  class BaseApiController : ControllerBase
    {
        public BaseApiController(IMapper mapper)
        {
            Mapper = mapper;
        }
        protected IMapper Mapper { get; }

    }
}

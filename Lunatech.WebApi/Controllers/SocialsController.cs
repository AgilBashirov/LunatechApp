using AutoMapper;
using Lunatech.Application.Services;
using Lunatech.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatech.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SocialsController : ControllerBase
    {
        private readonly IRepositoryService<Social> _projectCategoryService;
        private readonly IMapper _mapper;
        public SocialsController(IRepositoryService<Social> projectCategoryService, IMapper mapper)
        {
            _projectCategoryService = projectCategoryService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<List<Domain.Entities.Social>>> Get(int langId)
        {
            return await _projectCategoryService.GetAllAsync(langId);
        }
    }
}

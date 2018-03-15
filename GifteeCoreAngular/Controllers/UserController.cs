using AutoMapper;
using GifteeCoreAngular.Controllers.Resources;
using GifteeCoreAngular.Core;
using GifteeCoreAngular.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifteeCoreAngular.Controllers
{
    [Route("/api/users")]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserController(IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetUsers()
        {
            var users = await userRepository.GetAllUsersAsync(includeRelatedGiftees: true);
            var userList = users.ToList();

            return mapper.Map<List<User>, List<UserResource>>(userList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await userRepository.GetUserAsync(id, includeRelatedGiftees: true);

            if (user == null)
            {
                return NotFound();
            }

            var result = mapper.Map<User, UserResource>(user);
            return Ok(result);
        }
    }
}

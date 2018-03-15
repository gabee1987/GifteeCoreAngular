using AutoMapper;
using GifteeCoreAngular.Controllers.Resources;
using GifteeCoreAngular.Core;
using GifteeCoreAngular.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GifteeCoreAngular.Controllers
{
    [Route("/api/giftees")]
    public class GifteeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IGifteeRepository gifteeRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public GifteeController(IMapper mapper, IGifteeRepository gifteeRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.gifteeRepository = gifteeRepository;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGiftee([FromBody] GifteeResource gifteeResource)
        {
            //throw new Exception();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //Check if user is exist
            var user = await userRepository.GetUserAsync(gifteeResource.UserId, includeRelatedGiftees: false);

            if (user == null)
            {
                ModelState.AddModelError("UserId", "Invalid UserId");
                return BadRequest(ModelState);
            }

            var giftee = mapper.Map<GifteeResource, Giftee>(gifteeResource);
            //giftee.User = user;

            gifteeRepository.AddGiftee(giftee);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Giftee, GifteeResource>(giftee);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGiftee(int id, [FromBody] GifteeResource gifteeResource)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var giftee = await gifteeRepository.GetGifteeAsync(id, includeRelatedUser: false);

            if (giftee == null)
            {
                return NotFound();
            }

            mapper.Map<GifteeResource, Giftee>(gifteeResource, giftee);

            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Giftee, GifteeResource>(giftee);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiftee(int id)
        {
            var giftee = await gifteeRepository.GetGifteeAsync(id, includeRelatedUser: false);

            if (giftee == null)
            {
                return NotFound();
            }

            gifteeRepository.RemoveGiftee(giftee);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGiftee(int id)
        {
            var giftee = await gifteeRepository.GetGifteeAsync(id, includeRelatedUser: true);

            if (giftee == null)
            {
                return NotFound();
            }


            var result = mapper.Map<Giftee, GifteeResource>(giftee);
            return Ok(result);
        }
    }
}

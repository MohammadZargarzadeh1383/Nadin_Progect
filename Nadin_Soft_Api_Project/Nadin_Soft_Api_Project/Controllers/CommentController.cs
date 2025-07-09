using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nadin_Soft_Api_Project.Application.Interfaces.Repositories;
using Nadin_Soft_Api_Project.Application.Models.Dto.CommentDto;
using Nadin_Soft_Api_Project.Application.Models.Dto.UserDto;
using Nadin_Soft_Api_Project.Domain.Entities.Comment;
using Nadin_Soft_Api_Project.Domain.Entities.User;

namespace Nadin_Soft_Api_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _genericRepository;

        public CommentController(IGenericRepository<Comment> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Comment>> CreateComment(CreateCommentDto CommentDto)
        {
            var comment = new Comment()
            {
                Title = CommentDto.Title,
                Text = CommentDto.Text,
                UserRef = 0,
            };
            var createcomment = await _genericRepository.Create(comment);
            return Ok(createcomment);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ShowCommentDto>>> GetAllComment()
        {
            var getallcomment = await _genericRepository.GetAll().Select(x => new ShowCommentDto
            {
                Id = x.Id,
                Text = x.Text,
                Title = x.Title,
                UserRef = x.UserRef,
                CreatedAt = x.CreatedAt
            }
            ).ToListAsync();
            return Ok(getallcomment);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Comment>> GetUser([FromQuery] int id)
        {
            var comment = await _genericRepository.GetById(id);
            var result = new ShowCommentDto
            {
                Id = id,
                Title = comment.Title,
                Text = comment.Text,
                UserRef = comment.UserRef,
                CreatedAt = comment.CreatedAt,
            };
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<User>> UpdateUser([FromQuery] int id, [FromBody] CreateUserDto userdto)
        {

            var user = await _genericRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                user.FirstName = userdto.FirstName;
                user.LastName = userdto.LastName;
                user.PhoneNumber = userdto.PhoneNumber;
                user.UpdatedAt = DateTime.Now;
                var updateuser = await _genericRepository.Update(user);
                return Ok(updateuser);
            }
            ;
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteUser([FromQuery] int id)
        {
            var comment = await _genericRepository.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            else
            {
                var deletenotion = await _genericRepository.Delete(comment);
                return Ok();
            }
            ;
        }
    }
}


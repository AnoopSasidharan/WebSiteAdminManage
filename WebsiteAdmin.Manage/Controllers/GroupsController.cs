using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebsiteAdmin.Manage.Data.Entities;
using WebsiteAdmin.Manage.Services;

namespace WebsiteAdmin.Manage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;

        public GroupsController(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            var groups = await _dataRepository.GetGroupsAsync();
            return Ok(groups);
        }
        [HttpGet("{Id}", Name ="GetGroupById")]
        public async Task<ActionResult<Group>> GetGroups(int Id)
        {
            var group = await _dataRepository.GetGroupByIdAsync(Id);
            if(group==null)
            {
                return NotFound();
            }
            return Ok(group);
        }
        [HttpPost()]
        public async Task<ActionResult> CreateGroup([FromBody] Group group)
        {
            _dataRepository.AddGroup(group);
            await _dataRepository.SaveRepositoryAsync();
            return CreatedAtRoute("GetGroupById", new { Id = group.Id }, group);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteGroup(int Id)
        {
            var group = await _dataRepository.GetGroupByIdAsync(Id);
            if(group==null)
            {
                return BadRequest();
            }
            _dataRepository.RemoveGroup(group);
            await _dataRepository.SaveRepositoryAsync();
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ShopBridge.API.Repository;
using ShopBridge.API.ViewModel;
using System;
using System.Threading.Tasks;

namespace ShopBridge.API.Controllers.api.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/item")]
    public class ItemController : ControllerBase
    {
        private readonly IRepository<ItemVM> _repository;

        public ItemController(IRepository<ItemVM> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItemVM item)
        {
            return Ok(await _repository.Create(item));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ItemVM item)
        {
            return Ok(await _repository.Update(item));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}

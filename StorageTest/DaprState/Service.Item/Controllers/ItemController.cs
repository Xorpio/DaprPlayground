using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Service.Item
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<Item> create(Item item)
        {
            return await Task.FromResult(item);
        }
    }
}

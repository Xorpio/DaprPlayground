using Backend.Models;
using Bogus;
using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet("Create/{numberOfItems}")]
        public async Task<IList<Item>> CreateItems(int numberOfItems)
        {
            var subItems = new Faker<SubItem>()
                .RuleFor(s => s.Name, f => f.Lorem.Word());
            var itemsGenerator = new Faker<Item>()
                .RuleFor(i => i.Name, f => f.Commerce.ProductName())
                .RuleFor(i => i.SubItem, f => subItems.Generate(f.Random.Number(1, 3)));

            var items = itemsGenerator.Generate(numberOfItems);

            foreach(var item in items)
            {
                var httpClient = DaprClient.CreateInvokeHttpClient("service-item");
                var response = await httpClient.PostAsJsonAsync("create", item);
                response.EnsureSuccessStatusCode();
            }

            return items;
        }
    }
}

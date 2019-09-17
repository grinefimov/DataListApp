using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public DataController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Data>>> GetDataListAsync()
        {
            return await _dbContext.DataItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Data>> GetDataAsync(int id)
        {
            return await _dbContext.DataItems.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> PostDataAsync(Data model)
        {
            await _dbContext.AddAsync(model);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutDataAsync(int id, Data model)
        {
            var exists = await _dbContext.DataItems.AnyAsync(f => f.ID == id);
            if (!exists)
            {
                return NotFound();
            }

            _dbContext.DataItems.Update(model);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDataAsync(int id)
        {
            var entity = await _dbContext.DataItems.FindAsync(id);

            _dbContext.DataItems.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
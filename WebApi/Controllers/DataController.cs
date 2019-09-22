using System.Collections.Generic;
using System.Linq;
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
        private readonly DataContext _context;

        public DataController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Data>>> GetDataListAsync()
        {
            return await _context.DataItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Data>> GetDataAsync(int id)
        {
            Data data = await _context.DataItems.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }

        [HttpPost]
        public async Task<ActionResult<Data>> PostDataAsync(Data item)
        {
            _context.DataItems.Add(item);
            await _context.SaveChangesAsync();

            // https://github.com/Microsoft/aspnet-api-versioning/issues/18
            // return CreatedAtAction(nameof(GetDataAsync), new {id = item.ID}, item);
            return await GetDataAsync(item.ID);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Data>> PutDataAsync(int id, Data item)
        {
            if (id != item.ID)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDataAsync(int id)
        {
            Data dataItem = await _context.DataItems.FindAsync(id);

            if (dataItem == null)
            {
                return NotFound();
            }

            _context.DataItems.Remove(dataItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataItemExists(long id)
        {
            return _context.DataItems.Any(e => e.ID == id);
        }
    }
}
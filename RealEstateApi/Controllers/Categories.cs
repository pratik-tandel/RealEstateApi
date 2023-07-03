using RealEstateApi.Data;
using RealEstateApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    ApiDbContext _dbContext = new ApiDbContext();

    // GET: /api/categories
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_dbContext.Categories);
        // return StatusCode(StatusCodes.Status201Created);
        // return BadRequest();
        // return NotFound();
    }

    // GET: /api/categories/:id
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var category = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(category);
        }
    }

    // GET: /api/categories/SortCategories
    [HttpGet("[action]")]
    public IActionResult SortCategories()
    {
        return Ok(_dbContext.Categories.OrderByDescending(x => x.Name));
    }

    // POST: /api/categories
    [HttpPost]
    public IActionResult Post([FromBody] Category category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
        return StatusCode(StatusCodes.Status201Created);
    }

    // PUT: /api/categories/:id
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Category categoryObj)
    {
        var category = _dbContext.Categories.Find(id);
        if (category == null)
        {
            return NotFound("No record found against this Id: " + id);
        }
        else
        {
            category.Name = categoryObj.Name;
            category.ImageUrl = categoryObj.ImageUrl;
            _dbContext.SaveChanges();
            return Ok("Record updated successfully");
        }
    }

    // DELETE: /api/categories/:id
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var category = _dbContext.Categories.Find(id);
        if (category == null)
        {
            return NotFound("No record found against this Id: " + id);
        }
        else
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return Ok("Record deleted successfully");
        }
    }

}
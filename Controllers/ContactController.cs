using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;
using System.Linq;

namespace ContactManagerApi.Controllers
{
    [Route("api/contacts")]
    public class ContactController : Controller
    {
        private readonly ContactContext _context;

        public ContactController(ContactContext context)
        {
            _context = context;

            if (_context.Contacts.Count() == 0)
            {
                _context.Contacts.Add(new Contact { 
                    Name = "Joe Gledhill",
                    Address = "1230 SE 3rd Ave",
                    City = "Canby",
                    State = "OR",
                    Zip = "97013",
                    Email = "burner_email@hawksoft.com"

                });
                _context.SaveChanges();
            }
        }       

        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.Contacts.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // [HttpPost]
        // public IActionResult Create([FromBody] Contact item)
        // {
        //     if (item == null)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Contacts.Add(item);
        //     _context.SaveChanges();

        //     return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        // }

        // [HttpPut("{id}")]
        // public IActionResult Update(long id, [FromBody] Contact item)
        // {
        //     if (item == null || item.Id != id)
        //     {
        //         return BadRequest();
        //     }

        //     var todo = _context.Contacts.FirstOrDefault(t => t.Id == id);
        //     if (todo == null)
        //     {
        //         return NotFound();
        //     }

        //     todo.IsComplete = item.IsComplete;
        //     todo.Name = item.Name;

        //     _context.Contacts.Update(todo);
        //     _context.SaveChanges();
        //     return new NoContentResult();
        // }

        // [HttpDelete("{id}")]
        // public IActionResult Delete(long id)
        // {
        //     var todo = _context.Contacts.FirstOrDefault(t => t.Id == id);
        //     if (todo == null)
        //     {
        //         return NotFound();
        //     }

        //     //Depending on what we're trying to do, we may want to move this to the model and perform a "soft delete" using a column like deletedAt that's null until the item is deleted.
        //     _context.Contacts.Remove(todo);
        //     _context.SaveChanges();
        //     return new NoContentResult();
        // }
    }
}
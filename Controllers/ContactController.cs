using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;
using System.Linq;

namespace ContactManagerApi.Controllers
{
    [Route("api/contacts")]
    public class ContactController : Controller
    {
        //TODO add search and paging functionality. Also add authorization and tie contacts to the user model so we only return relevant data. 
        //TODO: Move update logic into Contact model so any restrictions and validations can be handled there. Keep this controller skinny
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

        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult GetById(long id)
        {
            var item = _context.Contacts.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contact item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Contacts.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetContact", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Contact item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var contact = _context.Contacts.FirstOrDefault(t => t.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            contact.Name = item.Name;
            contact.Address = item.Address;
            contact.City = item.City;
            contact.State = item.State;
            contact.Zip = item.Zip;
            contact.Email = item.Email;

            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var contact = _context.Contacts.FirstOrDefault(t => t.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            //Depending on what we're trying to do, we may want to move this to the model and perform a "soft delete" using a column like deletedAt that's null until the item is deleted.
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
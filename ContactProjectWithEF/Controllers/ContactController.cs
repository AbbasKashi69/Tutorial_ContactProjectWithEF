using ContactProjectWithEF.Models;
using ContactProjectWithEF.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactProjectWithEF.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ContactController(ApplicationDbContext db)
        {
            _db = db;
        }

        // list of contacts
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contacts = await _db.Contacts
                .Include(d => d.Group)
                .ToListAsync();
            return View(contacts);
        }

        //get create view
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Groups"] = _db.Groups.ToList();
            return View();
        }

        //register contact
        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            //_db.Contacts.Add(contact);
            //_db.SaveChanges();

            await _db.Contacts.AddAsync(contact);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //get edit view
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Groups"] = _db.Groups.ToList();
            var contact = await _db.Contacts.SingleOrDefaultAsync(s=> s.Id == id);
            return View("create", contact);
        }

        //register contact
        [HttpPost]
        public async Task<IActionResult> Edit(Contact contact)
        {
            var oldContact = await _db.Contacts.SingleOrDefaultAsync(d=> d.Id == contact.Id);
            oldContact.FirstName = contact.FirstName;
            oldContact.LastName = contact.LastName;
            oldContact.Phone = contact.Phone;
            oldContact.Mobile = contact.Mobile;

            await _db.SaveChangesAsync();

            return RedirectToAction("index");
        }

        //get details of a contact
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var contact = await _db.Contacts.SingleOrDefaultAsync(s => s.Id == id);
            return View(contact);
        }

        //delete contact
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _db.Contacts.SingleOrDefaultAsync(s => s.Id == id);
            _db.Contacts.Remove(contact);
            await _db.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}

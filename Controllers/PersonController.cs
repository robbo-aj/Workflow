using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Workflow.Infrastructure;
using Workflow.Interfaces;
using Workflow.Models;

namespace Workflow.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: Person
        public ActionResult Index()
        {
            SetBaseUrl(this.HttpContext);

            var people = _personService.GetPeople();
            return View(people);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            SetBaseUrl(this.HttpContext);

            var person = _personService.GetPerson(id);
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            SetBaseUrl(this.HttpContext);

            var person = new PersonViewModel();
            return View(person);
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonViewModel person)
        {
            SetBaseUrl(this.HttpContext);

            try
            {
                _personService.AddPerson(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(person);
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            SetBaseUrl(this.HttpContext);

            var referrer = this.Request.Headers["Referer"].ToString();

            var person = _personService.GetPerson(id);
            return View(person);
        }

        // POST: Person/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonViewModel person)
        {
            SetBaseUrl(this.HttpContext);

            if (person.FirstName == "Peter")
                ModelState.AddModelError("PETE", "Pete is not allowed to be updated");
            
            // Get the serialised hobby data and set it as a property of the person
            var hobbies = JsonConvert.DeserializeObject<List<HobbyViewModel>>(person.SerialisedHobbies);
            person.Hobbies = hobbies;

            if (!ModelState.IsValid)
            {
                return View(person);
            }
            else
            {
                _personService.UpdatePerson(person);
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            SetBaseUrl(this.HttpContext);

            var person = _personService.GetPerson(id);
            return View(person);
        }

        // POST: Person/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PersonViewModel person)
        {
            SetBaseUrl(this.HttpContext);

            try
            {
                _personService.DeletePerson(person.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(person);
            }
        }
    }
}
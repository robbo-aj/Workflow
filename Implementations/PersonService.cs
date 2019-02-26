using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Interfaces;
using Workflow.Models;

namespace Workflow.Implementations
{
    public class PersonService : IPersonService
    {
        List<PersonViewModel> _people;
        Guid _id = Guid.NewGuid();

        public void AddPerson(PersonViewModel person)
        {
            _people.Add(person);
        }

        public void DeletePerson(int id)
        {
            _people.RemoveAll(p => p.Id == id);
        }

        public List<PersonViewModel> GetPeople()
        {
            return _people.OrderBy(p => p.LastName).ToList();
        }

        public PersonViewModel GetPerson(int id)
        {
            var person = _people.Find(p => p.Id == id);
            return person;
        }

        public void Initialise()
        {
            _people = new List<PersonViewModel>
            {
                new PersonViewModel
                {
                    Id = 1,
                    FirstName = "Andy",
                    LastName = "Robinson",
                    Nickname = "Robbo",
                    Age = 21,
                    Hobbies = new List<HobbyViewModel>
                    {
                        new HobbyViewModel
                        {
                            Id = 1,
                            Name = "Golf",
                            Started = new DateTime(1988, 7, 1)
                        },
                        new HobbyViewModel
                        {
                            Id = 1,
                            Name = "Fixing Pete's code",
                            Started = new DateTime(2018, 7, 1)
                        },

                    }
                },
                new PersonViewModel
                {
                    Id = 2,
                    FirstName = "Peter",
                    LastName = "Liu",
                    Nickname = "Odd Job",
                    Age = 209,
                    Hobbies = new List<HobbyViewModel>
                    {
                        new HobbyViewModel
                        {
                            Id = 1,
                            Name = "Robot Dog Walking",
                            Started = new DateTime(1999, 5, 1)
                        },
                        new HobbyViewModel
                        {
                            Id = 2,
                            Name = "Scaring Project Managers",
                            Started = new DateTime(2019, 1, 1)
                        }
                    }
                },
                new PersonViewModel
                {
                    Id = 3,
                    FirstName = "Matt",
                    LastName = "Young",
                    Nickname = "Youngo",
                    Age = 38,
                    Hobbies = new List<HobbyViewModel>()
                    {
                        new HobbyViewModel
                        {
                            Id = 1,
                            Name = "Commuting",
                            Started = new DateTime(2007, 5, 1)
                        },
                        new HobbyViewModel
                        {
                            Id = 2,
                            Name = "Killing virtual people",
                            Started = new DateTime(2012, 6, 1)
                        }
                    }
                }
            };
        }

        public void UpdatePerson(PersonViewModel person)
        {
            var existingPerson = _people.Find(p => p.Id == person.Id);
            if(existingPerson != null)
            {
                _people.Remove(existingPerson);
                _people.Add(person);
            }
        }
    }
}

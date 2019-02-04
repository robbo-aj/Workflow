using System;
using System.Collections.Generic;
using Workflow.Models;

namespace Workflow.Interfaces
{
    public interface IPersonService
    {
        List<PersonViewModel> GetPeople();
        PersonViewModel GetPerson(int id);
        void AddPerson(PersonViewModel person);
        void UpdatePerson(PersonViewModel person);
        void DeletePerson(int id);
        void Initialise();
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Net2024_DemoEntity.Contexts;
using TF_Net2024_DemoEntity.Entities;

namespace TF_Net2024_DemoEntity.Repositories
{
    public class PersonRepository
    {

        public IEnumerable<Person> GetAll()
        {
            using (DemoContext context = new DemoContext())
            {
                return context.Persons;
            }
        }

        public Person? GetOne(Func<Person, bool> predicate)
        {
            using (DemoContext context = new DemoContext())
            {
                return context.Persons.Include(p=>p.BankAccount).SingleOrDefault(predicate);
            }
        }

        public IEnumerable<Person> GetMany(Func<Person, bool> predicate)
        {
            using (DemoContext context = new DemoContext())
            {
                return context.Persons.Where(predicate);
            }
        }

        public Person Insert(Person person)
        {
            using (DemoContext context = new DemoContext())
            {
                Person result = context.Persons.Add(person).Entity;
                context.SaveChanges();
                return result;
            }
        }

        public Person Update(int id, Person person)
        {
            using (DemoContext context = new DemoContext())
            {
                Person? existingPerson = context.Persons.SingleOrDefault(p => p.Id == id);
                if (existingPerson is null)
                {
                    throw new Exception("This person doesnt exist");
                }
                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.Pseudo = person.Pseudo;
                existingPerson.Email = person.Email;

                context.SaveChanges();

                return existingPerson;
            }
        }

        public void Delete(int id)
        {
            using (DemoContext context = new DemoContext())
            {
                Person? existingPerson = context.Persons.SingleOrDefault(p => p.Id == id);

                if(existingPerson is null)
                {
                    throw new Exception("This person doesnt exist");
                }

                context.Persons.Remove(existingPerson);
                context.SaveChanges();
            }
        }
    }
}

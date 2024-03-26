using TF_Net2024_DemoEntity.Entities;
using TF_Net2024_DemoEntity.Repositories;

PersonRepository personRepository = new PersonRepository();

BankAccountRepository bankAccountRepository = new BankAccountRepository();

bankAccountRepository.Delete("BE12345678910112");

personRepository.Delete(3);

//Person? p1 = personRepository.GetOne(p => p.Id == 1);

//p1 = personRepository.GetOne(p => p.Pseudo == "Bambino");

//Person person = new Person()
//{
//    FirstName="Test",
//    LastName="Test",
//    Pseudo="Test",
//    Email="Test",
//};

//personRepository.Update(1, person);

//Person p1 = personRepository.GetOne(p => p.Id == 1);

//Console.WriteLine(p1);

Person p2 = new Person
{
    LastName = "Babidi",
    Email = "Test"
};
p2 = personRepository.Insert(p2);
Console.WriteLine(p2);


BankAccount ba1 = new BankAccount() { 
    AccountNumber = "BE12345678910112",
    BankName = "AuBonBénéfice",
    TitularId = p2.Id
};

bankAccountRepository.Insert(ba1);

ba1 = bankAccountRepository.GetById(ba1.AccountNumber);

Console.WriteLine($"{ba1.AccountNumber} ({ba1.BankName}) : {ba1.Amount} Euros");
Console.WriteLine($"{ba1.Titular.LastName} {ba1.Titular.FirstName}");

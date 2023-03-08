using OCPLibrary;

public class Program
{
    static void Main(string[] args)
    {
        List<PersonModel> applicants = new List<PersonModel>
        {   
            new PersonModel { FirstName="Tim" ,LastName="Cook" },
            new PersonModel { FirstName="Elon" ,LastName="Musk" },
            new PersonModel { FirstName="Bill" ,LastName="Gates" },
        };

        List<EmployeeModel> employees = new List<EmployeeModel>();
        Accounts accountProcessor = new Accounts();

        foreach(var person in applicants)
        {
            employees.Add(accountProcessor.Create(person));
        }

        foreach (var emp in employees)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.EmailAddress} IsManager {emp.IsManager} IsExecutive {emp.IsExecutive}");
        }
        
        Console.ReadLine();
    }


}
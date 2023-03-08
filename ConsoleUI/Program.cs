using OCPLibrary;

public class Program
{
    static void Main(string[] args)
    {
        List<IApplicantModel> applicants = new List<IApplicantModel>
        {   
            new PersonModel { FirstName="Tim" ,LastName="Cook" },
            new ManagerModel { FirstName="Elon" ,LastName="Musk" },
            new ExecutiveModel { FirstName="Bill" ,LastName="Gates" },
        };

        List<EmployeeModel> employees = new List<EmployeeModel>();
       

        foreach(var person in applicants)
        {
            employees.Add(person.AccountProcessor.Create(person));
        }

        foreach (var emp in employees)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.EmailAddress} IsManager {emp.IsManager} IsExecutive {emp.IsExecutive}");
        }
        
        Console.ReadLine();
    }


}
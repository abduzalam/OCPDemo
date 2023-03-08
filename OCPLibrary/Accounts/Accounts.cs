using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCPLibrary.Applicants;

namespace OCPLibrary.Accounts
{
    public class Accounts : IAccounts
    {
        public EmployeeModel Create(IApplicantModel person)
        {
            EmployeeModel output = new EmployeeModel();

            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            output.EmailAddress = $" {person.FirstName.Substring(0, 1)}{person.LastName}@abcd.com ";

            return output;
        }
    }
}

using OCPLibrary.Applicants;

namespace OCPLibrary
{
    public interface IAccounts
    {
        EmployeeModel Create(IApplicantModel person);

    }
}

namespace Dit.Lms.Api
{
    public class LoanServiceFactory
    {
        public static ILoanService CreateLoanService()
        {
            return new LoanService();
        }
    }
}

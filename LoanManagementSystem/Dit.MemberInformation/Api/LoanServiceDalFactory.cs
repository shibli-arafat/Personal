
namespace Dit.Lms.Api
{
    internal class LoanServiceDalFactory
    {
        internal static ILoanServiceDal CreateLoanServiceDal()
        {
            return new LoanServiceDal();
        }
    }
}

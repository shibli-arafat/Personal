using System;
namespace Dit.Lms.Api
{
    public interface ILoanService
    {
        User Login(string userName, string password);
        User SaveUser(User user);
        void DeleteUser(int userId);
        User GetUser(int userId);
        UserCollection GetUsers();

        Member SaveMember(Member member);
        void DeleteMember(int id);
        Member GetMember(int id);
        Member GetMemberByMemberId(int memberId);
        MemberCollection GetMembers(string keyword);

        MonthlyDeposit SaveMonthlyDeposit(MonthlyDeposit deposit, double depositCharge);
        void DeleteMonthlyDeposit(int depositId);
        MonthlyDeposit GetMonthlyDeposit(int depositId);
        MonthlyDeposit GetLatestMonthlyDeposit(int memberId);
        MonthlyDepositCollection GetMonthlyDeposits(int memberId, int yearFrom);

        Expense SaveExpense(Expense expense);
        void DeleteExpense(int expenseId);
        Expense GetExpense(int expenseId);
        ExpenseCollection GetExpenses(DateTime dateFrom, DateTime dateTo, int expenseHeadId);

        Income SaveIncome(Income income);
        void DeleteIncome(int incomeId);
        Income GetIncome(int incomeId);
        IncomeCollection GetIncomes(DateTime dateFrom, DateTime dateTo, int incomeHeadId);

        ExpenseHead SaveExpenseHead(ExpenseHead expenseHead);
        void DeleteExpenseHead(int expenseHeadId);
        ExpenseHead GetExpenseHead(int expenseHeadId);
        ExpenseHeadCollection GetExpenseHeads();

        IncomeHead SaveIncomeHead(IncomeHead incomeHead);
        void DeleteIncomeHead(int incomeHeadId);
        IncomeHead GetIncomeHead(int incomeHeadId);
        IncomeHeadCollection GetIncomeHeads();

        LoanDisbursement SaveLoanDisbursement(LoanDisbursement disbursement);
        void DeleteLoanDisbursement(int disbursementId);
        LoanDisbursement GetLoanDisbursement(int disbursementId);
        LoanDisbursementCollection GetLoanDisbursements();

        LoanRepayment SaveLoanRepayment(LoanRepayment repayment);
        void DeleteLoanRepayment(int repaymentId);
        LoanRepayment GetLoanRepayment(int repaymentId);
        LoanRepaymentCollection GetLoanRepayments();

        void SaveSystemConfig(SystemConfig sysConfig);
        SystemConfig GetSystemConfig(int sysConfigId);
        void SaveConfigDetail(SystemConfigDetail configDetail);
        void DeleteSysConfigDetail(int configDetailId);
        SystemConfigDetailCollection GetConfigDetails(int sysConfigId);

        void BackupDatabase(string backupDir);
        void RestoreDatabase(string backupPath);

        bool MonthlyDepositExists(int p);

        void UpdateAllInitialBalance(int updateBy);
    }
}

using System;
namespace Dit.Lms.Api
{
    internal interface ILoanServiceDal
    {
        int SaveUser(User user);
        void DeleteUser(int userId);
        User GetUser(int userId);
        bool IsDuplicateUser(int id, string loginName);
        User GetUser(string loginName);
        UserCollection GetUsers();

        int SaveMember(Member member);
        void DeleteMember(int memberId);
        Member GetMember(int memberId);
        bool IsDuplicateMember(int id, int memberId);
        Member GetMemberByMemberId(int memberId);
        MemberCollection GetMembers(string keyword);

        int SaveMonthlyDeposit(MonthlyDeposit deposit, double depositCharge);
        void DeleteMonthlyDeposit(int depositId);
        bool IsDuplicateMonthlyDeposit(int memberId, int month, int year);
        MonthlyDeposit GetMonthlyDeposit(int depositId);
        MonthlyDeposit GetLatestMonthlyDeposit(int memberId);
        MonthlyDepositCollection GetMonthlyDeposits(int memberId, int yearFrom);

        int SaveExpense(Expense expense);
        void DeleteExpense(int expenseId);
        Expense GetExpense(int expenseId);
        ExpenseCollection GetExpenses(DateTime dateFrom, DateTime dateTo, int expenseHeadId);

        int SaveIncome(Income income);
        void DeleteIncome(int incomeId);
        void DeleteDepositIncome(DateTime date);
        Income GetIncome(int incomeId);
        IncomeCollection GetIncomes(DateTime dateFrom, DateTime dateTo, int incomeHeadId);

        int SaveExpenseHead(ExpenseHead expenseHead);
        void DeleteExpenseHead(int expenseHeadId);
        bool IsDuplicateExpenseHead(int id, string expenseHead);
        ExpenseHead GetExpenseHead(int expenseHeadId);
        ExpenseHeadCollection GetExpenseHeads();

        int SaveIncomeHead(IncomeHead incomeHead);
        void DeleteIncomeHead(int incomeHeadId);
        bool IsDuplicateIncomeHead(int id, string incomeHead);
        IncomeHead GetIncomeHead(int incomeHeadId);
        IncomeHeadCollection GetIncomeHeads();

        int SaveLoanDisbursement(LoanDisbursement disbursement);
        void DeleteLoanDisbursement(int disbursementId);
        LoanDisbursement GetLoanDisbursement(int disbursementId);
        LoanDisbursementCollection GetLoanDisbursements();

        int SaveLoanRepayment(LoanRepayment repayment);
        void DeleteLoanRepayment(int repaymentId);
        bool IsDuplicateLoanRepayment(int memberId, int month, int year);
        LoanRepayment GetLoanRepayment(int repaymentId);
        LoanRepaymentCollection GetLoanRepayments();

        int SaveSystemConfig(SystemConfig sysConfig);
        SystemConfig GetSystemConfig(int sysConfigId);
        bool IsDuplicateSysConfigDetail(int configDetailId, int sysConfigId, int fiscalYear);
        int SaveConfigDetail(SystemConfigDetail configDetail);
        void DeleteSysConfigDetail(int configDetailId);
        SystemConfigDetailCollection GetConfigDetails(int sysConfigId);

        void BackupDatabase(string backupPath);
        void RestoreDatabase(string backupPath);

        bool MonthlyDepositExists(int memberId);

        void UpdateAllInitialBalance(int updateBy);
    }
}

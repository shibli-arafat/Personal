using System;
using System.Configuration;
using Dit.Common;

namespace Dit.Lms.Api
{
    internal class LoanServiceDal : ILoanServiceDal
    {
        private DatabaseHelper _DbHelper;

        public LoanServiceDal()
        {
            _DbHelper = new DatabaseHelper(ConfigurationManager.AppSettings["LoanManagement"]);
        }

        User ILoanServiceDal.GetUser(string loginName)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@LoginName", loginName));
            return _DbHelper.ExecuteQuery<User>("UserGetByLoginName", parameters).Data;
        }

        int ILoanServiceDal.SaveUser(User user)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@UserXml", SerializeHelper.Serialize(user)));
            parameters.Add(new DataParam("@Id", user.Id, true));
            QueryResult<User> result = _DbHelper.ExecuteNonQuery<User>("UserSave", parameters);
            return Convert.ToInt32(parameters[1].Value);
        }

        void ILoanServiceDal.DeleteUser(int userId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", userId));
            _DbHelper.ExecuteNonQuery<User>("UserDelete", parameters);
        }

        User ILoanServiceDal.GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        UserCollection ILoanServiceDal.GetUsers()
        {
            return _DbHelper.ExecuteQuery<UserCollection>("UserGetAll", null).Data;
        }

        int ILoanServiceDal.SaveMember(Member member)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@MemberXml", SerializeHelper.Serialize(member)));
            parameters.Add(new DataParam("@Id", member.Id, true));
            QueryResult<Member> result = _DbHelper.ExecuteNonQuery<Member>("MemberSave", parameters);
            return Convert.ToInt32(parameters[1].Value);
        }

        void ILoanServiceDal.DeleteMember(int memberId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", memberId));
            _DbHelper.ExecuteNonQuery<Member>("MemberDelete", parameters);
        }

        Member ILoanServiceDal.GetMember(int id)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", id));
            return _DbHelper.ExecuteQuery<Member>("MemberGet", parameters).Data;
        }

        Member ILoanServiceDal.GetMemberByMemberId(int memberId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@MemberId", memberId));
            return _DbHelper.ExecuteQuery<Member>("MemberGetByMemberId", parameters).Data;
        }

        MemberCollection ILoanServiceDal.GetMembers(string keyword)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Keyword", keyword));
            return _DbHelper.ExecuteQuery<MemberCollection>("MemberGetAll", parameters).Data;
        }

        MonthlyDepositCollection ILoanServiceDal.GetMonthlyDeposits(int memberId, int yearFrom)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@MemberId", memberId));
            parameters.Add(new DataParam("@YearFrom", yearFrom));
            QueryListResult<MonthlyDepositCollection> deposits = _DbHelper.ExecuteListQuery<MonthlyDepositCollection>("MonthlyDepositGetAll", parameters);
            return deposits.Data;
        }

        int ILoanServiceDal.SaveMonthlyDeposit(MonthlyDeposit deposit, double depositCharge)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@MonthlyDepositXml", SerializeHelper.Serialize(deposit)));
            parameters.Add(new DataParam("@DepositCharge", depositCharge));
            parameters.Add(new DataParam("@Id", deposit.Id, true));
            QueryResult<MonthlyDeposit> result = _DbHelper.ExecuteNonQuery<MonthlyDeposit>("MonthlyDepositSave", parameters);
            return Convert.ToInt32(parameters[1].Value);
        }

        void ILoanServiceDal.DeleteMonthlyDeposit(int depositId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", depositId));
            _DbHelper.ExecuteNonQuery<Member>("MonthlyDepositDelete", parameters);
        }

        MonthlyDeposit ILoanServiceDal.GetMonthlyDeposit(int depositId)
        {
            throw new NotImplementedException();
        }

        MonthlyDeposit ILoanServiceDal.GetLatestMonthlyDeposit(int memberId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@MemberId", memberId));
            QueryResult<MonthlyDeposit> result = _DbHelper.ExecuteQuery<MonthlyDeposit>("MonthlyDepositGetLatest", parameters);
            return result.Data;
        }

        int ILoanServiceDal.SaveExpense(Expense expense)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@ExpenseXml", SerializeHelper.Serialize(expense)));
            parameters.Add(new DataParam("@Id", expense.Id, true));
            QueryResult<Expense> result = _DbHelper.ExecuteNonQuery<Expense>("ExpenseSave", parameters);
            return Convert.ToInt32(parameters[1].Value);
        }

        void ILoanServiceDal.DeleteExpense(int expenseId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", expenseId));
            _DbHelper.ExecuteNonQuery<Expense>("ExpenseDelete", parameters);
        }

        Expense ILoanServiceDal.GetExpense(int expenseId)
        {
            throw new NotImplementedException();
        }

        ExpenseCollection ILoanServiceDal.GetExpenses(DateTime dateFrom, DateTime dateTo, int expenseHeadId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@DateFrom", dateFrom));
            parameters.Add(new DataParam("@DateTo", dateTo));
            parameters.Add(new DataParam("@ExpenseHeadId", expenseHeadId));
            return _DbHelper.ExecuteQuery<ExpenseCollection>("ExpenseGetAll", parameters).Data;
        }

        int ILoanServiceDal.SaveIncome(Income income)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@IncomeXml", SerializeHelper.Serialize(income)));
            parameters.Add(new DataParam("@Id", income.Id, true));
            QueryResult<Income> result = _DbHelper.ExecuteNonQuery<Income>("IncomeSave", parameters);
            return Convert.ToInt32(parameters[1].Value);
        }

        void ILoanServiceDal.DeleteIncome(int incomeId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", incomeId));
            _DbHelper.ExecuteNonQuery<Income>("IncomeDelete", parameters);
        }

        Income ILoanServiceDal.GetIncome(int incomeId)
        {
            throw new NotImplementedException();
        }

        IncomeCollection ILoanServiceDal.GetIncomes(DateTime dateFrom, DateTime dateTo, int incomeHeadId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@DateFrom", dateFrom));
            parameters.Add(new DataParam("@DateTo", dateTo));
            parameters.Add(new DataParam("@IncomeHeadId", incomeHeadId));
            return _DbHelper.ExecuteQuery<IncomeCollection>("IncomeGetAll", parameters).Data;
        }

        int ILoanServiceDal.SaveExpenseHead(ExpenseHead expenseHead)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@ExpenseHeadXml", SerializeHelper.Serialize(expenseHead)));
            parameters.Add(new DataParam("@Id", expenseHead.Id, true));
            QueryResult<ExpenseHead> result = _DbHelper.ExecuteNonQuery<ExpenseHead>("ExpenseHeadSave", parameters);
            return Convert.ToInt32(parameters[1].Value);
        }

        void ILoanServiceDal.DeleteExpenseHead(int expenseHeadId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", expenseHeadId));
            _DbHelper.ExecuteNonQuery<ExpenseHead>("ExpenseHeadDelete", parameters);
        }

        ExpenseHead ILoanServiceDal.GetExpenseHead(int expenseHeadId)
        {
            throw new NotImplementedException();
        }

        ExpenseHeadCollection ILoanServiceDal.GetExpenseHeads()
        {
            return _DbHelper.ExecuteListQuery<ExpenseHeadCollection>("ExpenseHeadGetAll", null).Data;
        }

        int ILoanServiceDal.SaveIncomeHead(IncomeHead incomeHead)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@IncomeHeadXml", SerializeHelper.Serialize(incomeHead)));
            parameters.Add(new DataParam("@Id", incomeHead.Id, true));
            QueryResult<IncomeHead> result = _DbHelper.ExecuteNonQuery<IncomeHead>("IncomeHeadSave", parameters);
            return Convert.ToInt32(parameters[1].Value);
        }

        void ILoanServiceDal.DeleteIncomeHead(int incomeHeadId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", incomeHeadId));
            _DbHelper.ExecuteNonQuery<IncomeHead>("IncomeHeadDelete", parameters);
        }

        IncomeHead ILoanServiceDal.GetIncomeHead(int incomeHeadId)
        {
            throw new NotImplementedException();
        }

        IncomeHeadCollection ILoanServiceDal.GetIncomeHeads()
        {
            return _DbHelper.ExecuteListQuery<IncomeHeadCollection>("IncomeHeadGetAll", null).Data;
        }

        int ILoanServiceDal.SaveLoanDisbursement(LoanDisbursement disbursement)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@LoanDisbursmentXml", SerializeHelper.Serialize(disbursement)));
            parameters.Add(new DataParam("@Id", disbursement.Id, true));
            QueryResult<LoanDisbursement> result = _DbHelper.ExecuteNonQuery<LoanDisbursement>("LoanDisbursementSave", parameters);
            return Convert.ToInt32(parameters[1].Value);
        }

        void ILoanServiceDal.DeleteLoanDisbursement(int disbursementId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", disbursementId));
            _DbHelper.ExecuteNonQuery<IncomeHead>("LoanDisbursementDelete", parameters);
        }

        LoanDisbursement ILoanServiceDal.GetLoanDisbursement(int disbursementId)
        {
            throw new NotImplementedException();
        }

        LoanDisbursementCollection ILoanServiceDal.GetLoanDisbursements()
        {
            QueryListResult<LoanDisbursementCollection> disbursements = _DbHelper.ExecuteListQuery<LoanDisbursementCollection>("LoanDisbursementGetAll", null);
            return disbursements.Data;
        }

        int ILoanServiceDal.SaveLoanRepayment(LoanRepayment repayment)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@LoanRepaymentXml", SerializeHelper.Serialize(repayment)));
            parameters.Add(new DataParam("@Id", repayment.Id, true));
            QueryResult<LoanRepayment> result = _DbHelper.ExecuteNonQuery<LoanRepayment>("LoanRepaymentSave", parameters);
            return Convert.ToInt32(parameters[1].Value);
        }

        void ILoanServiceDal.DeleteLoanRepayment(int repaymentId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", repaymentId));
            _DbHelper.ExecuteNonQuery<IncomeHead>("LoanRepaymentDelete", parameters);
        }

        LoanRepayment ILoanServiceDal.GetLoanRepayment(int repaymentId)
        {
            throw new NotImplementedException();
        }

        LoanRepaymentCollection ILoanServiceDal.GetLoanRepayments()
        {
            return _DbHelper.ExecuteQuery<LoanRepaymentCollection>("LoanRepaymentGetAll", null).Data;
        }

        void ILoanServiceDal.BackupDatabase(string backupPath)
        {
            _DbHelper.BackupDatabase("LoanManagementSystem", "LoanManagementSystem", backupPath);
        }

        void ILoanServiceDal.RestoreDatabase(string backupPath)
        {
            _DbHelper.RestoreDatabase("LoanManagementSystem", backupPath);
        }

        bool ILoanServiceDal.IsDuplicateMember(int id, int memberId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", id));
            parameters.Add(new DataParam("@MemberId", memberId));
            return _DbHelper.IsDuplicate("MemberDuplicateCheck", parameters);
        }

        bool ILoanServiceDal.IsDuplicateUser(int id, string loginName)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", id));
            parameters.Add(new DataParam("@LoginName", loginName));
            return _DbHelper.IsDuplicate("UserDuplicateCheck", parameters);
        }

        bool ILoanServiceDal.IsDuplicateMonthlyDeposit(int memberId, int month, int year)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@MemberId", memberId));
            parameters.Add(new DataParam("@Month", month));
            parameters.Add(new DataParam("@Year", year));
            return _DbHelper.IsDuplicate("MonthlyDepositDuplicateCheck", parameters);
        }

        bool ILoanServiceDal.IsDuplicateExpenseHead(int id, string expenseHead)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", id));
            parameters.Add(new DataParam("@ExpenseHead", expenseHead));
            return _DbHelper.IsDuplicate("ExpenseHeadDuplicateCheck", parameters);
        }

        bool ILoanServiceDal.IsDuplicateIncomeHead(int id, string incomeHead)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", id));
            parameters.Add(new DataParam("@IncomeHead", incomeHead));
            return _DbHelper.IsDuplicate("IncomeHeadDuplicateCheck", parameters);
        }

        bool ILoanServiceDal.IsDuplicateLoanRepayment(int memberId, int month, int year)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@MemberId", memberId));
            parameters.Add(new DataParam("@Month", month));
            parameters.Add(new DataParam("@Year", year));
            return _DbHelper.IsDuplicate("LoanRepaymentDuplicateCheck", parameters);
        }

        int ILoanServiceDal.SaveSystemConfig(SystemConfig sysConfig)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam(@"SysConfigXml", SerializeHelper.Serialize(sysConfig)));
            parameters.Add(new DataParam("@Id", sysConfig.Id, true));
            _DbHelper.ExecuteNonQuery<SystemConfig>("SystemConfigSave", parameters);
            return Convert.ToInt32(parameters[1].Value);
        }

        SystemConfig ILoanServiceDal.GetSystemConfig(int sysConfigId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam(@"Id", sysConfigId));
            SystemConfig sysConfig = _DbHelper.ExecuteQuery<SystemConfig>("SystemConfigGet", parameters).Data;
            if (sysConfig == null) throw new DataNotFoundException(string.Format("System config data with ID {0} not found", sysConfigId));
            return sysConfig;
        }

        int ILoanServiceDal.SaveConfigDetail(SystemConfigDetail configDetail)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@ConfigDetailXml", SerializeHelper.Serialize(configDetail)));
            parameters.Add(new DataParam("@Id", configDetail.Id, true));
            _DbHelper.ExecuteNonQuery<SystemConfigDetail>("SystemConfigDetailSave", parameters);
            return Convert.ToInt32(parameters[1].Value);
        }

        SystemConfigDetailCollection ILoanServiceDal.GetConfigDetails(int sysConfigId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@SystemConfigId", sysConfigId));
            return _DbHelper.ExecuteListQuery<SystemConfigDetailCollection>("SystemConfigDetailGetAll", parameters).Data;
        }


        bool ILoanServiceDal.IsDuplicateSysConfigDetail(int configDetailId, int sysConfigId, int fiscalYear)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", configDetailId));
            parameters.Add(new DataParam("@SystemConfigId", sysConfigId));
            parameters.Add(new DataParam("@FiscalYear", fiscalYear));
            return _DbHelper.IsDuplicate("SystemConfigDetailDuplicateCheck", parameters);
        }

        void ILoanServiceDal.DeleteSysConfigDetail(int configDetailId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@Id", configDetailId));
            _DbHelper.ExecuteNonQuery<SystemConfigDetail>("SystemConfigDetailDelete", parameters);
        }


        void ILoanServiceDal.DeleteDepositIncome(DateTime date)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@IncomeOn", date));
            _DbHelper.ExecuteNonQuery<Income>("DeleteDepositIncome", parameters);
        }

        bool ILoanServiceDal.MonthlyDepositExists(int memberId)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@MemberId", memberId));
            int count = _DbHelper.ExecuteScaler<int>("MonthlyDepositExists", parameters);
            return count != 0;
        }

        void ILoanServiceDal.UpdateAllInitialBalance(int updateBy)
        {
            DataParamCollection parameters = new DataParamCollection();
            parameters.Add(new DataParam("@UpdatedBy", updateBy));
            //_DbHelper.ExecuteNonQuery<int>("InitialBalanceAllUpdate", parameters);
        }
    }
}

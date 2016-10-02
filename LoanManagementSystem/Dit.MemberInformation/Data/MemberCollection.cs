using System.Collections.Generic;

namespace Dit.Lms.Api
{
    public class MemberCollection : List<Member>
    {
        public void Update(Member member)
        {
            this.RemoveAll(x => x.Id == member.Id);
            if (member.IsActive) this.Insert(0, member);
        }

        public bool Exists(int memberId)
        {
            return this.Exists(x => x.Id == memberId);
        }

        public List<Member> GetByMemberId(int memberId)
        {
            return this.FindAll(x => x.MemberId == memberId);
        }

        public MemberReportDataCollection ToReportData()
        {
            MemberReportDataCollection reportData = new MemberReportDataCollection();
            foreach (Member member in this)
            {
                reportData.Add(member.ToReportData());
            }
            return reportData;
        }
    }
}

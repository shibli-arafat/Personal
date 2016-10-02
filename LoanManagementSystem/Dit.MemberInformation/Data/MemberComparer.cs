using System.Collections.Generic;

namespace Dit.Lms.Api
{
    public class MemberComparer : IComparer<Member>
    {
        int IComparer<Member>.Compare(Member x, Member y)
        {
            return x.MemberId.CompareTo(y.MemberId);
        }
    }
}

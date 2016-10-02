using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class AllowanceSettingBol
    {
        private AllowanceSettingDal _Dal;

        public AllowanceSettingBol()
        {
            _Dal = new AllowanceSettingDal();
        }

        public AllowanceSetting SaveAllowanceSetting(AllowanceSetting allowanceSetting)
        {
            allowanceSetting.Id = _Dal.SaveAllowanceSetting(allowanceSetting);
            return allowanceSetting;
        }

        public AllowanceSetting GetAllowanceSetting(int id)
        {
            return _Dal.GetAllowanceSetting(id);
        }
    }
}

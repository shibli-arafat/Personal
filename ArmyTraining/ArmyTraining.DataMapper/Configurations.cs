
namespace ArmyTraining.DataMapper
{
    public class Configurations
    {
        public static void Init(string connectionstring)
        {
            ConnectionString = connectionstring;
        }

        internal static string ConnectionString;
    }
}


namespace ArmyTraining.Presenter
{
    public class Configurations
    {
        public static void InitConfig(string connectionString)
        {
            Internal.ConfigurationSettings.Init(connectionString);
        }
    }
}

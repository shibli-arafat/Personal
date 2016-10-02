
namespace ArmyTraining.Internal
{
    public class ConfigurationSettings
    {
        public static void Init(string connectionStrin)
        {
            DataMapper.Configurations.Init(connectionStrin);
        }
    }
}

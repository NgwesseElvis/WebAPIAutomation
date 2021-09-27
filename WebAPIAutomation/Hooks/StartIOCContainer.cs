using NUnit.Framework;
using WebAPIAutomation.IOC;

namespace WebAPIAutomation.Hooks
{
    public class StartIOCContainer
    {
        [OneTimeSetUp]
        public void InjectDependencies()
        {
            ResolveDependency.RegisterAndResolveDependencies();
        }
    }
}

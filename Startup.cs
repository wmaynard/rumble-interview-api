using RCL.Logging;
using Rumble.Platform.Common.Utilities;
using Rumble.Platform.Common.Web;

namespace Rumble.Platform.Interview;

public class Startup : PlatformStartup
{
	public void ConfigureServices(IServiceCollection services) => base.ConfigureServices(services, Owner.Will, 30_000, 60_000, 90_000, webServerEnabled: true);
}
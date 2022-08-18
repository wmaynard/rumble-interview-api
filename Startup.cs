using RCL.Logging;
using Rumble.Platform.Common.Enums;
using Rumble.Platform.Common.Utilities;
using Rumble.Platform.Common.Web;

namespace Rumble.Platform.Interview;

public class Startup : PlatformStartup
{
	protected override PlatformOptions Configure(PlatformOptions options) => options
		.SetProjectOwner(Owner.Will)
		.SetRegistrationName("Interview")
		.SetPerformanceThresholds(warnMS: 30_000, errorMS: 60_000, criticalMS: 90_000)
		.DisableServices(CommonService.Config)
		.EnableWebServer();
}
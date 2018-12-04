using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DPHGallery.Startup))]
namespace DPHGallery
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}

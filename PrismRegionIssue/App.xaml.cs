using System.Windows;

namespace PrismRegionIssue {

	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application {

		protected override void OnStartup( StartupEventArgs args ) {
			log4net.Config.XmlConfigurator.Configure();
			base.OnStartup( args );
			var bootstrapper = new MyBootstrapper();
			bootstrapper.Run();
		}

	}

}

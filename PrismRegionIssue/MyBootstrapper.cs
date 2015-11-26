using System.Configuration;
using System.Windows;
using log4net;
using MahApps.Metro.Controls;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace PrismRegionIssue {

	public class MyBootstrapper : UnityBootstrapper {

		private readonly static ILog _log = LogManager.GetLogger( typeof( MyBootstrapper ) );

		protected override void ConfigureModuleCatalog() {
			if ( _log.IsDebugEnabled ) _log.DebugFormat( "ConfigureModuleCatalog" );
			var moduleCatalog = (ModuleCatalog) ModuleCatalog;
			moduleCatalog.AddModule( typeof( MyModule ) );
		}

		protected override RegionAdapterMappings ConfigureRegionAdapterMappings() {
			var mappings = base.ConfigureRegionAdapterMappings();
			mappings.RegisterMapping( typeof( WindowCommands ), Container.Resolve<WindowCommandsRegionAdapter>() );
			return mappings;
		}

		protected override void ConfigureContainer() {
			if ( _log.IsDebugEnabled ) _log.DebugFormat( "ConfigureContainer" );
			base.ConfigureContainer();
			var configurationSection = (UnityConfigurationSection) ConfigurationManager.GetSection( "unity" );
			configurationSection?.Configure( this.Container );
		}

		protected override DependencyObject CreateShell() {
			if ( _log.IsDebugEnabled ) _log.DebugFormat( "CreateShell" );
			return this.Container.Resolve<Shell>();
		}

		protected override void InitializeShell() {
			if ( _log.IsDebugEnabled ) _log.DebugFormat( "InitializeShell" );
			base.InitializeShell();
			Application.Current.MainWindow = (Window) this.Shell;
			Application.Current.MainWindow.Show();
		}

	}

}

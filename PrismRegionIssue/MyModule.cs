using log4net;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace PrismRegionIssue {

	public class MyModule : IModule {

		private readonly static ILog    _log    = LogManager.GetLogger( typeof( MyModule ) );

		private readonly IUnityContainer _container;
		private readonly IRegionManager _regionManager;

		public MyModule( IRegionManager regionManager, IUnityContainer container ) {
			if ( _log.IsDebugEnabled ) _log.DebugFormat( "MyModule.ctor" );
			_regionManager = regionManager;
			_container = container;
		}

		public void Initialize() {
			if ( _log.IsDebugEnabled ) _log.DebugFormat( "Initialize" );
			// Register ViewB with the container.  It won't be shown in a region until navigated to.
			_container.RegisterType( typeof( object ), typeof( ViewB ), ViewB.ViewName );
			// Register the luancher view and ViewA on startup.
			_regionManager.RegisterViewWithRegion( RegionNames.MainRegion, typeof( LauncherView ) );
			_regionManager.RegisterViewWithRegion( RegionNames.WindowCommands, typeof( ViewA ) );
		}

	}

}

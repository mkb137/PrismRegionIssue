using System.Collections.Specialized;
using System.Windows;
using log4net;
using MahApps.Metro.Controls;
using Prism.Regions;

namespace PrismRegionIssue {

	public class WindowCommandsRegionAdapter : RegionAdapterBase<WindowCommands> {

		private readonly static ILog _log = LogManager.GetLogger( typeof( WindowCommandsRegionAdapter ) );

		private readonly IRegionManager _regionManager;

		public WindowCommandsRegionAdapter( IRegionBehaviorFactory regionBehaviorFactory, IRegionManager regionManager ) : base( regionBehaviorFactory ) {
			if ( _log.IsDebugEnabled ) _log.DebugFormat( "MyRegionControlAdapter.ctor" );
			this._regionManager = regionManager;
		}

		protected override void Adapt( IRegion region, WindowCommands target ) {
#if DEBUGx
			// This will make it work
			RegionManager.SetRegionManager( target, this._regionManager );
#endif

			if ( _log.IsDebugEnabled ) _log.DebugFormat( "Adapt" );
			region.Views.CollectionChanged += ( sender, args ) => {
				switch ( args.Action ) {
					case NotifyCollectionChangedAction.Remove:
						foreach ( FrameworkElement oldItem in args.OldItems ) {
							if ( _log.IsDebugEnabled ) _log.DebugFormat( " - removing item '{0}'", oldItem );
							target.Items.Remove( oldItem );
						}
						break;
					case NotifyCollectionChangedAction.Add:
						foreach ( FrameworkElement newItem in args.NewItems ) {
							if ( _log.IsDebugEnabled ) _log.DebugFormat( " - adding item '{0}'", newItem );
							target.Items.Add( newItem );
						}
						break;
				}
			};
		}

		protected override IRegion CreateRegion() {
			return new AllActiveRegion();
		}

	}

}

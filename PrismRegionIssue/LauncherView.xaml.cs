using System;
using System.Windows;
using Prism.Regions;

namespace PrismRegionIssue {

	/// <summary>
	/// Interaction logic for LauncherView.xaml
	/// </summary>
	public partial class LauncherView {

		private readonly IRegionManager _regionManager;

		public LauncherView() {
			_regionManager = null;
			InitializeComponent();
		}

		public LauncherView( IRegionManager regionManager ) {
			_regionManager = regionManager;
			InitializeComponent();
		}

		private void OnButtonClick( object sender, RoutedEventArgs e ) {
			_regionManager.RequestNavigate( RegionNames.WindowCommands, new Uri( ViewB.ViewName, UriKind.Relative ) );
		}

	}

}

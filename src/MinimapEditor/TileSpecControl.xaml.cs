using MinimapEditor.Viewmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MinimapEditor;

/// <summary>
/// Interaction logic for TileSpecControl.xaml
/// </summary>
public partial class TileSpecControl : UserControl
{
    private TileSpecViewmodel? vm => this.DataContext as TileSpecViewmodel;
    public TileSpecControl()
    {
        InitializeComponent();
    }
    private int id = -1;
    private int idO = -1;
    private void Unselect(object sender, RoutedEventArgs e)
    {
        if(vm != null && !vm.SetBaseTile7123)
        {
            vm.user_st = false;
            id = BaseTileList.SelectedIndex;
            BaseTileList.SelectedIndex = -1;
            vm.user_st = true;
        }
        else
        {
            BaseTileList.SelectedIndex = id;
        }
    }

    private void UnselectO(object sender, RoutedEventArgs e)
    {
        if (vm != null && !vm.SetOverlay1367)
        {
            vm.user_st = false;
            idO = OverlayTileList.SelectedIndex;
            OverlayTileList.SelectedIndex = -1;
            vm.user_st = true;
        }
        else
        {
            OverlayTileList.SelectedIndex = idO;
        }
    }

    private void Resize(object sender, SizeChangedEventArgs e)
    {
        BaseTileList.MaxWidth = e.NewSize.Width - 50;
        OverlayTileList.MaxWidth = e.NewSize.Width - 50;
    }
}

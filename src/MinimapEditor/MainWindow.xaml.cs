using MinimapEditor.Viewmodels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;

namespace MinimapEditor;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly StartupViewmodel startupVM;

    public MainWindow()
    {
        InitializeComponent();
        startupVM = new()
        {
            DialogManager = new DialogManager(this),
        };
        DataContext = startupVM;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        startupVM.OnAppExiting(e);
        base.OnClosing(e);
    }

    private void ContentControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is StartupViewmodel.TabItemViewmodel tabVM
            && tabVM.Viewmodel2249 is MapEditorViewmodel
            && sender is ContentControl cc)
        {
            // This is needed so that the keyboard shortcuts on the map editor control work immediately
            Dispatcher.BeginInvoke(() =>
            {
                var mapEditors = VisualTreeBFS.MakeSimpleFilter<MapEditorControl>().DoBFS(cc).ToList();
                if (mapEditors.Count == 1)
                {
                    mapEditors[0].Focusable = true;
                    mapEditors[0].Focus();
                }
                else
                {
                    Util.SoftAssertFail();
                }
            });
        }
    }

    private void RecalculateSize(object sender, SizeChangedEventArgs e)
    {
        startupVM.RecalculateSize(sender, e);
    }

    private static bool debugResetLatch = false;
    private void SaveCmndatAs_Click(object sender, RoutedEventArgs e)
    {
        var viewmodel = DataContext as StartupViewmodel;
        if (viewmodel == null)
        {
            return;
        }

        if (!debugResetLatch && System.Diagnostics.Debugger.IsAttached)
        {
            // Because I don't want to forget that this functionality exists,
            // reset the flag every time I run with the debugger attached.
            Properties.Settings.Default.DontShowBackupWarningAgain = false;
            debugResetLatch = true;
        }

        bool doSaveAs;
        if (Properties.Settings.Default.DontShowBackupWarningAgain)
        {
            doSaveAs = true;
        }
        else
        {
            var popup = new SaveBackupWarningDialog();
            popup.Owner = this.VisualAncestors().OfType<Window>().FirstOrDefault();
            popup.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            doSaveAs = popup.ShowDialog().GetValueOrDefault(false);
            if (doSaveAs && popup.DontShowWarningAgain)
            {
                Properties.Settings.Default.DontShowBackupWarningAgain = true;
            }
        }

        if (doSaveAs)
        {
            viewmodel.SaveCmndatAs();
        }
    }
}

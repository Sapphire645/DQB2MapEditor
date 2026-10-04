using LibDQB.DQB2Minimap;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;
using System.Windows.Media;

namespace MinimapEditor.Viewmodels;

public sealed class TileSpecViewmodel : ViewmodelBase
{
    private bool _setBaseTile = true;
    public bool SetBaseTile7123
    {
        get => _setBaseTile;
        set => ChangeProperty(ref _setBaseTile, value);
    }

    public bool user_st = true;

    private BaseTileModel? _selectedBaseTile;
    public BaseTileModel? SelectedBaseTile6495
    {
        get => _selectedBaseTile;
        set {
            if(user_st)
                SetBaseTileInvert = false;
            ChangeProperty(ref _selectedBaseTile, value);
        }

    }

    public bool SetBaseTileInvert
    {
        get => !_setBaseTile;
        set
        {
            ChangeProperty(ref _setBaseTile, !value);
        }
    }

    public required IReadOnlyList<BaseTileModel> BaseTileChoices2327 { get; init; }

    private bool _setOverlay = true;
    public bool SetOverlay1367
    {
        get => _setOverlay;
        set => ChangeProperty(ref _setOverlay, value);
    }

    public bool SetOverlayInvert
    {
        get => !_setOverlay;
        set
        {
            ChangeProperty(ref _setOverlay, !value);
        }
    }

    private OverlayModel? _selectedOverlay;
    public OverlayModel? SelectedOverlay8725
    {
        get => _selectedOverlay;
        set
        {
            if (user_st)
                SetOverlayInvert = false;
            ChangeProperty(ref _selectedOverlay, value);
        }
    }

    public required IReadOnlyList<OverlayModel> OverlayChoices4299 { get; init; }

    public NullableBooleanModel Visibility5366 { get; } = new();


    public required ImageSource Visible { get; init; }
    public required ImageSource Opaque { get; init; }

}

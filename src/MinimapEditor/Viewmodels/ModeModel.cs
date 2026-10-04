using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MinimapEditor.Viewmodels;

public sealed class ModeModel : ViewmodelBase
{
    public ModeModel Clone()
    {
        var clone = new ModeModel();
        clone._mode = this._mode;
        return clone;
    }

    enum Mode
    {
        Pan,
        Select,
        RectSelect,
        Modify,
        Paste,
        WriteText,
    };

    private Mode _mode = Mode.Pan;

    private void Set(bool value, Mode mode)
    {
        if (value)
        {
            ChangeProperty(ref _mode, mode, AllProperties);
        }
        else if (mode == _mode)
        {
            ChangeProperty(ref _mode, Mode.Pan, AllProperties);
        }
    }




    private BitmapImage _toolSheet = new BitmapImage(new Uri("pack://application:,,,/" + "Images/toolsheet.png"));

    private const int TOOL_SIZE = 80;
    public CroppedBitmap toolImage(byte tool, bool active)
    {
        if (tool == 5) tool = 2;
        return new CroppedBitmap(_toolSheet,
            new Int32Rect(TOOL_SIZE * tool, active ? TOOL_SIZE : 0, TOOL_SIZE, TOOL_SIZE));
    }

    public CroppedBitmap Tool1 => toolImage(0, IsSelectMode5073);
    public CroppedBitmap Tool2 => toolImage(1, IsRectSelectMode2843);
    public CroppedBitmap Tool3 => toolImage(3, IsPasteMode4735);
    public CroppedBitmap Tool4 => toolImage(4, IsModifyMode6812);

    public CroppedBitmap ToolE => toolImage(2, false);
    public bool IsPanMode8931
    {
        get => _mode == Mode.Pan;
        set => Set(value, Mode.Pan);
    }

    public bool IsSelectMode5073
    {
        get => _mode == Mode.Select;
        set => Set(value, Mode.Select);
    }

    public bool IsRectSelectMode2843
    {
        get => _mode == Mode.RectSelect;
        set => Set(value, Mode.RectSelect);
    }

    public bool IsModifyMode6812
    {
        get => _mode == Mode.Modify;
        set => Set(value, Mode.Modify);
    }

    public bool IsPasteMode4735
    {
        get => _mode == Mode.Paste;
        set => Set(value, Mode.Paste);
    }

    public bool IsWriteTextMode2099
    {
        get => _mode == Mode.WriteText;
        set => Set(value, Mode.WriteText);
    }

    public bool IsAnySelectMode4440 => IsSelectMode5073 || IsRectSelectMode2843;

    public bool IsSpecialMode8897 => IsWriteTextMode2099;

    public Visibility VisibilityStandard5734 => IsSpecialMode8897 ? Visibility.Collapsed : Visibility.Visible;
    public Visibility VisibilityWriteText3657 => IsWriteTextMode2099 ? Visibility.Visible : Visibility.Collapsed;
}

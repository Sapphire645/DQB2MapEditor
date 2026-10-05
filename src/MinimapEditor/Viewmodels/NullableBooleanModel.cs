using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace MinimapEditor.Viewmodels;

public sealed class NullableBooleanModel : ViewmodelBase
{
    private bool? val = null;

    public bool IsNull3392
    {
        get => val == null;
        set { if (value) ChangeProperty(ref val, null, AllProperties); }
    }

    public bool IsTrue9880
    {
        get => val == true;
        set { if (value) ChangeProperty(ref val, true, AllProperties); }
    }

    public bool IsFalse9122
    {
        get => val == false;
        set { if (value) ChangeProperty(ref val, false, AllProperties); }
    }

    public bool? Value() => val;

    public required ImageSource OpaqueD { get; init; }

    public required ImageSource VisibleD { get; init; }

    public ImageSource SelectedOpacity => IsFalse9122 ? VisibleD : OpaqueD;

    public String SelectedValue => IsFalse9122 ? "F" : IsTrue9880 ? "T" : "";
}

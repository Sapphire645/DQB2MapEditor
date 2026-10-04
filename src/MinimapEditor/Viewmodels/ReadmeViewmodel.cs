using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MinimapEditor.Viewmodels;

sealed class ReadmeViewmodel : ViewmodelBase
{
    public int myHeight  => _myHeight;
    private int _myHeight = 200;

    public void RecalculateSize(int height)
    {
        ChangeProperty(ref _myHeight, height);
    }
}

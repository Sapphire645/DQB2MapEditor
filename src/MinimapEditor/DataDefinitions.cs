using LibDQB.DQB2Minimap;
using MinimapEditor.Tiling;
using MinimapEditor.Viewmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace MinimapEditor;

public sealed class DataDefinitions
{
    public interface ITilesheet
    {
        ImageSource GetBaseTileImage(BaseTileId baseTileId);
        ImageSource GetOverlayImage(OverlayId overlayId);

        ImageSource GetVisibilityDisplay(byte visible);
    }

    public IReadOnlyList<BaseTileModel> BaseTiles { get; }
    public IReadOnlyList<OverlayModel> Overlays { get; }

    public (ImageSource, ImageSource, ImageSource, ImageSource) Discovered { get; }
    public DataDefinitions(ITilesheet tilesheet)
    {
        BaseTiles = BuildBaseTiles(tilesheet).ToList();
        Overlays = BuildOverlays(tilesheet).ToList();
        Discovered = (tilesheet.GetVisibilityDisplay(0), tilesheet.GetVisibilityDisplay(1), tilesheet.GetVisibilityDisplay(2), tilesheet.GetVisibilityDisplay(3));
    }

    private static IEnumerable<BaseTileModel> BuildBaseTiles(ITilesheet tilesheet)
    {
        return Enumerable.Range(0, 26).Select(tileId => new BaseTileModel
        {
            ImageSource = tilesheet.GetBaseTileImage(new BaseTileId(tileId)),
            BaseTileId = new BaseTileId(tileId),
            Name = tileId.ToString("D2"),
        });
    }

    private static IEnumerable<OverlayModel> BuildOverlays(ITilesheet tilesheet)
    {
        int[] validOverlays = [0, 1, 2, 3, 6, 7, 8, 9, 10];
        return validOverlays.Select(i => new OverlayModel
        {
            OverlayId = new OverlayId(i),
            ImageSource = tilesheet.GetOverlayImage(new OverlayId(i)),
            Name = i.ToString("D2"),
        });
    }
}

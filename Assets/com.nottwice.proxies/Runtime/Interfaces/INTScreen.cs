using System.Collections.Generic;
using UnityEngine;

namespace NotTwice.Proxies.Runtime.Interfaces
{
    /// <summary>
    /// Interface contract outlining methods to be defined for unity screen operations
    /// </summary>
    public interface INTScreen
    {
        bool AutorotateToLandscapeLeft { get; set; }
        bool AutorotateToLandscapeRight { get; set; }
        bool AutorotateToPortrait { get; set; }
        bool AutorotateToPortraitUpsideDown { get; set; }
        float Brightness { get; set; }
        Resolution CurrentResolution { get; }
        Rect[] Cutouts { get; }
        float Dpi { get; }
        bool FullScreen { get; set; }
        FullScreenMode FullScreenMode { get; set; }
        int Height { get; }
        DisplayInfo MainWindowDisplayInfo { get; }
        Vector2Int MainWindowPosition { get; }
        ScreenOrientation Orientation { get; }
        Resolution[] Resolutions { get; }
        Rect SafeArea { get; }
        int SleepTimeout { get; set; }
        int Width { get; }

        void GetDisplayLayout(List<DisplayInfo> displayLayout);
        AsyncOperation MoveMainWindowTo(in DisplayInfo display, Vector2Int position);
        void SetResolution(int width, int height, bool fullscreen);
        void SetResolution(int width, int height, bool fullscreen, int preferredRefreshRate);
        void SetResolution(int width, int height, FullScreenMode fullscreenMode);
    }
}

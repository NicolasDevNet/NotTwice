using NotTwice.Proxies.Runtime.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace NotTwice.Proxies.Runtime
{
    /// <summary>
    /// Proxy acting as a flat pass for <see cref="Screen"/> static methods.
    /// </summary>
    public class NTScreenProxy : INTScreen
	{
        /// <summary>
        /// Enables auto-rotation to landscape left
        /// </summary>
        public bool AutorotateToLandscapeLeft
        {
            get
            {
                return Screen.autorotateToLandscapeLeft;
            }
            set
            {
                Screen.autorotateToLandscapeLeft = value;
            }
        }

        /// <summary>
        /// Enables auto-rotation to landscape right.
        /// </summary>
        public bool AutorotateToLandscapeRight
        {
            get
            {
                return Screen.autorotateToLandscapeRight;
            }
            set
            {
                Screen.autorotateToLandscapeRight = value;
            }
        }

        /// <summary>
        /// Enables auto-rotation to portrait.
        /// </summary>
        public bool AutorotateToPortrait
        {
            get
            {
                return Screen.autorotateToPortrait;
            }
            set
            {
                Screen.autorotateToPortrait = value;
            }
        }

        /// <summary>
        /// Enables auto-rotation to portrait, upside down.
        /// </summary>
        public bool AutorotateToPortraitUpsideDown
        {
            get
            {
                return Screen.autorotateToPortraitUpsideDown;
            }
            set
            {
                Screen.autorotateToPortraitUpsideDown = value;
            }
        }

        /// <summary>
        /// The current brightness of the screen.
        /// </summary>
        public float Brightness
        {
            get
            {
                return Screen.brightness;
            }
            set
            {
                Screen.brightness = value;
            }
        }

        /// <summary>
        /// The current screen resolution (Read Only).
        /// </summary>
        public Resolution CurrentResolution
        {
            get
            {
                return Screen.currentResolution;
            }
        }

        /// <summary>
        /// Returns a list of screen areas that are not functional for displaying content
        /// (Read Only).
        /// </summary>
        public Rect[] Cutouts
        {
            get
            {
                return Screen.cutouts;
            }
        }

        /// <summary>
        /// The current DPI of the screen / device (Read Only).
        /// </summary>
        public float Dpi
        {
            get
            {
                return Screen.dpi;
            }
        }

        /// <summary>
        /// Enables full-screen mode for the application.
        /// </summary>
        public bool FullScreen
        {
            get
            {
                return Screen.fullScreen;
            }
            set
            {
                Screen.fullScreen = value;
            }
        }

        /// <summary>
        /// Set this property to one of the values in FullScreenMode to change the display
        /// mode of your application.
        /// </summary>
        public FullScreenMode FullScreenMode
        {
            get
            {
                return Screen.fullScreenMode;
            }
            set
            {
                Screen.fullScreenMode = value;
            }
        }

        /// <summary>
        /// The current height of the screen window in pixels (Read Only).
        /// </summary>
        public int Height
        {
            get
            {
                return Screen.height;
            }
        }

        /// <summary>
        /// The current width of the screen window in pixels (Read Only).
        /// </summary>
        public int Width
        {
            get
            {
                return Screen.width;
            }
        }

        /// <summary>
        /// The display information associated with the display that the main application
        /// window is on.
        /// </summary>
        public DisplayInfo MainWindowDisplayInfo
        {
            get
            {
                return Screen.mainWindowDisplayInfo;
            }
        }

        /// <summary>
        /// The position of the top left corner of the main window relative to the top left
        /// corner of the display.
        /// </summary>
        public Vector2Int MainWindowPosition
        {
            get
            {
                return Screen.mainWindowPosition;
            }
        }

        /// <summary>
        /// Specifies logical orientation of the screen.
        /// </summary>
        public ScreenOrientation Orientation
        {
            get
            {
                return Screen.orientation;
            }
        }

        /// <summary>
        /// Returns all full-screen resolutions that the monitor supports (Read Only).
        /// </summary>
        public Resolution[] Resolutions
        {
            get
            {
                return Screen.resolutions;
            }
        }

        /// <summary>
        /// Returns the safe area of the screen in pixels (Read Only).
        /// </summary>
        public Rect SafeArea
        {
            get
            {
                return Screen.safeArea;
            }
        }

        /// <summary>
        /// A power saving setting, allowing the screen to dim some time after the last active
        /// user interaction.
        /// </summary>
        public int SleepTimeout
        {
            get
            {
                return Screen.sleepTimeout;
            }
            set
            {
                Screen.sleepTimeout = value;
            }
        }

        public void GetDisplayLayout(List<DisplayInfo> displayLayout)
        {
            Screen.GetDisplayLayout(displayLayout);
        }

        public AsyncOperation MoveMainWindowTo(in DisplayInfo display, Vector2Int position)
        {
            return Screen.MoveMainWindowTo(display, position);
        }

        /// <summary>
        /// Switches the screen resolution.
        /// </summary>
        public void SetResolution(int width, int height, FullScreenMode fullscreenMode)
        {
            Screen.SetResolution(width, height, fullscreenMode, 0);
        }

        /// <summary>
        /// Switches the screen resolution.
        /// </summary>
        public void SetResolution(int width, int height, bool fullscreen, int preferredRefreshRate)
        {
            Screen.SetResolution(width, height, fullscreen, preferredRefreshRate);
        }

        /// <summary>
        /// Switches the screen resolution.
        /// </summary>
        public void SetResolution(int width, int height, bool fullscreen)
        {
            Screen.SetResolution(width, height, fullscreen, 0);
        }
    }
}

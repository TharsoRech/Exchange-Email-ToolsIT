'
' * Please leave this Copyright notice in your code if you use it
' * Written by Decebal Mihailescu [http://www.codeproject.com/script/articles/list_articles.asp?userid=634640]
' 

Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Security

Namespace ScreenMonitorLib

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure STARTUPINFO
        Public cb As Int32
        Public lpReserved As String
        Public lpDesktop As String
        Public lpTitle As String
        Public dwX As Int32
        Public dwY As Int32
        Public dwXSize As Int32
        Public dwXCountChars As Int32
        Public dwYCountChars As Int32
        Public dwFillAttribute As Int32
        Public dwFlags As Int32
        Public wShowWindow As Int16
        Public cbReserved2 As Int16
        Public lpReserved2 As IntPtr
        Public hStdInput As IntPtr
        Public hStdOutput As IntPtr
        Public hStdError As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure PROCESS_INFORMATION
        Public hProcess As IntPtr
        Public hThread As IntPtr
        Public dwProcessID As Int32
        Public dwThreadID As Int32
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure SECURITY_ATTRIBUTES
        Public Length As Int32
        Public lpSecurityDescriptor As IntPtr
        Public bInheritHandle As Boolean
    End Structure

    Public Enum SECURITY_IMPERSONATION_LEVEL
        SecurityAnonymous
        SecurityIdentification
        SecurityImpersonation
        SecurityDelegation
    End Enum

    Public Enum TOKEN_TYPE
        TokenPrimary = 1
        TokenImpersonation
    End Enum



    <Flags> _
    Public Enum TokenPrivilege As UInteger
        STANDARD_RIGHTS_REQUIRED = &HF0000
        STANDARD_RIGHTS_READ = &H20000
        TOKEN_ASSIGN_PRIMARY = &H1
        TOKEN_DUPLICATE = &H2
        TOKEN_IMPERSONATE = &H4
        TOKEN_QUERY = &H8
        TOKEN_QUERY_SOURCE = &H10
        TOKEN_ADJUST_PRIVILEGES = &H20
        TOKEN_ADJUST_GROUPS = &H40
        TOKEN_ADJUST_DEFAULT = &H80
        TOKEN_ADJUST_SESSIONID = &H100
        TOKEN_READ = (STANDARD_RIGHTS_READ Or TOKEN_QUERY)
        TOKEN_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED Or TOKEN_ASSIGN_PRIMARY Or TOKEN_DUPLICATE Or TOKEN_IMPERSONATE Or TOKEN_QUERY Or TOKEN_QUERY_SOURCE Or TOKEN_ADJUST_PRIVILEGES Or TOKEN_ADJUST_GROUPS Or TOKEN_ADJUST_DEFAULT Or TOKEN_ADJUST_SESSIONID)
    End Enum
    ' The SPI enum code borrowed from www.pinvoke.net
#Region "SPI"
    ''' <summary>
    ''' SPI_ System-wide parameter - Used in SystemParametersInfo function 
    ''' </summary>
    Friend Enum SPI As UInteger
        ''' <summary>
        ''' Determines whether the warning beeper is on. 
        ''' The pvParam parameter must point to a BOOL variable that receives TRUE if the beeper is on, or FALSE if it is off.
        ''' </summary>
        SPI_GETBEEP = &H1

        ''' <summary>
        ''' Turns the warning beeper on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.
        ''' </summary>
        SPI_SETBEEP = &H2

        ''' <summary>
        ''' Retrieves the two mouse threshold values and the mouse speed.
        ''' </summary>
        SPI_GETMOUSE = &H3

        ''' <summary>
        ''' Sets the two mouse threshold values and the mouse speed.
        ''' </summary>
        SPI_SETMOUSE = &H4

        ''' <summary>
        ''' Retrieves the border multiplier factor that determines the width of a window's sizing border. 
        ''' The pvParam parameter must point to an integer variable that receives this value.
        ''' </summary>
        SPI_GETBORDER = &H5

        ''' <summary>
        ''' Sets the border multiplier factor that determines the width of a window's sizing border. 
        ''' The uiParam parameter specifies the new value.
        ''' </summary>
        SPI_SETBORDER = &H6

        ''' <summary>
        ''' Retrieves the keyboard repeat-speed setting, which is a value in the range from 0 (approximately 2.5 repetitions per second) 
        ''' through 31 (approximately 30 repetitions per second). The actual repeat rates are hardware-dependent and may vary from 
        ''' a linear scale by as much as 20%. The pvParam parameter must point to a DWORD variable that receives the setting
        ''' </summary>
        SPI_GETKEYBOARDSPEED = &HA

        ''' <summary>
        ''' Sets the keyboard repeat-speed setting. The uiParam parameter must specify a value in the range from 0 
        ''' (approximately 2.5 repetitions per second) through 31 (approximately 30 repetitions per second). 
        ''' The actual repeat rates are hardware-dependent and may vary from a linear scale by as much as 20%. 
        ''' If uiParam is greater than 31, the parameter is set to 31.
        ''' </summary>
        SPI_SETKEYBOARDSPEED = &HB

        ''' <summary>
        ''' Not implemented.
        ''' </summary>
        SPI_LANGDRIVER = &HC

        ''' <summary>
        ''' Sets or retrieves the width, in pixels, of an icon cell. The system uses this rectangle to arrange icons in large icon view. 
        ''' To set this value, set uiParam to the new value and set pvParam to null. You cannot set this value to less than SM_CXICON.
        ''' To retrieve this value, pvParam must point to an integer that receives the current value.
        ''' </summary>
        SPI_ICONHORIZONTALSPACING = &HD

        ''' <summary>
        ''' Retrieves the screen saver time-out value, in seconds. The pvParam parameter must point to an integer variable that receives the value.
        ''' </summary>
        SPI_GETSCREENSAVETIMEOUT = &HE

        ''' <summary>
        ''' Sets the screen saver time-out value to the value of the uiParam parameter. This value is the amount of time, in seconds, 
        ''' that the system must be idle before the screen saver activates.
        ''' </summary>
        SPI_SETSCREENSAVETIMEOUT = &HF

        ''' <summary>
        ''' Determines whether screen saving is enabled. The pvParam parameter must point to a bool variable that receives TRUE 
        ''' if screen saving is enabled, or FALSE otherwise.
        ''' </summary>
        SPI_GETSCREENSAVEACTIVE = &H10

        ''' <summary>
        ''' Sets the state of the screen saver. The uiParam parameter specifies TRUE to activate screen saving, or FALSE to deactivate it.
        ''' </summary>
        SPI_SETSCREENSAVEACTIVE = &H11

        ''' <summary>
        ''' Retrieves the current granularity value of the desktop sizing grid. The pvParam parameter must point to an integer variable 
        ''' that receives the granularity.
        ''' </summary>
        SPI_GETGRIDGRANULARITY = &H12

        ''' <summary>
        ''' Sets the granularity of the desktop sizing grid to the value of the uiParam parameter.
        ''' </summary>
        SPI_SETGRIDGRANULARITY = &H13

        ''' <summary>
        ''' Sets the desktop wallpaper. The value of the pvParam parameter determines the new wallpaper. To specify a wallpaper bitmap, 
        ''' set pvParam to point to a null-terminated string containing the name of a bitmap file. Setting pvParam to "" removes the wallpaper. 
        ''' Setting pvParam to SETWALLPAPER_DEFAULT or null reverts to the default wallpaper.
        ''' </summary>
        SPI_SETDESKWALLPAPER = &H14

        ''' <summary>
        ''' Sets the current desktop pattern by causing Windows to read the Pattern= setting from the WIN.INI file.
        ''' </summary>
        SPI_SETDESKPATTERN = &H15

        ''' <summary>
        ''' Retrieves the keyboard repeat-delay setting, which is a value in the range from 0 (approximately 250 ms delay) through 3 
        ''' (approximately 1 second delay). The actual delay associated with each value may vary depending on the hardware. The pvParam parameter must point to an integer variable that receives the setting.
        ''' </summary>
        SPI_GETKEYBOARDDELAY = &H16

        ''' <summary>
        ''' Sets the keyboard repeat-delay setting. The uiParam parameter must specify 0, 1, 2, or 3, where zero sets the shortest delay 
        ''' (approximately 250 ms) and 3 sets the longest delay (approximately 1 second). The actual delay associated with each value may 
        ''' vary depending on the hardware.
        ''' </summary>
        SPI_SETKEYBOARDDELAY = &H17

        ''' <summary>
        ''' Sets or retrieves the height, in pixels, of an icon cell. 
        ''' To set this value, set uiParam to the new value and set pvParam to null. You cannot set this value to less than SM_CYICON.
        ''' To retrieve this value, pvParam must point to an integer that receives the current value.
        ''' </summary>
        SPI_ICONVERTICALSPACING = &H18

        ''' <summary>
        ''' Determines whether icon-title wrapping is enabled. The pvParam parameter must point to a bool variable that receives TRUE 
        ''' if enabled, or FALSE otherwise.
        ''' </summary>
        SPI_GETICONTITLEWRAP = &H19

        ''' <summary>
        ''' Turns icon-title wrapping on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.
        ''' </summary>
        SPI_SETICONTITLEWRAP = &H1A

        ''' <summary>
        ''' Determines whether pop-up menus are left-aligned or right-aligned, relative to the corresponding menu-bar item. 
        ''' The pvParam parameter must point to a bool variable that receives TRUE if left-aligned, or FALSE otherwise.
        ''' </summary>
        SPI_GETMENUDROPALIGNMENT = &H1B

        ''' <summary>
        ''' Sets the alignment value of pop-up menus. The uiParam parameter specifies TRUE for right alignment, or FALSE for left alignment.
        ''' </summary>
        SPI_SETMENUDROPALIGNMENT = &H1C

        ''' <summary>
        ''' Sets the width of the double-click rectangle to the value of the uiParam parameter. 
        ''' The double-click rectangle is the rectangle within which the second click of a double-click must fall for it to be registered 
        ''' as a double-click.
        ''' To retrieve the width of the double-click rectangle, call GetSystemMetrics with the SM_CXDOUBLECLK flag.
        ''' </summary>
        SPI_SETDOUBLECLKWIDTH = &H1D

        ''' <summary>
        ''' Sets the height of the double-click rectangle to the value of the uiParam parameter. 
        ''' The double-click rectangle is the rectangle within which the second click of a double-click must fall for it to be registered 
        ''' as a double-click.
        ''' To retrieve the height of the double-click rectangle, call GetSystemMetrics with the SM_CYDOUBLECLK flag.
        ''' </summary>
        SPI_SETDOUBLECLKHEIGHT = &H1E

        ''' <summary>
        ''' Retrieves the logical font information for the current icon-title font. The uiParam parameter specifies the size of a LOGFONT structure, 
        ''' and the pvParam parameter must point to the LOGFONT structure to fill in.
        ''' </summary>
        SPI_GETICONTITLELOGFONT = &H1F

        ''' <summary>
        ''' Sets the double-click time for the mouse to the value of the uiParam parameter. The double-click time is the maximum number 
        ''' of milliseconds that can occur between the first and second clicks of a double-click. You can also call the SetDoubleClickTime 
        ''' function to set the double-click time. To get the current double-click time, call the GetDoubleClickTime function.
        ''' </summary>
        SPI_SETDOUBLECLICKTIME = &H20

        ''' <summary>
        ''' Swaps or restores the meaning of the left and right mouse buttons. The uiParam parameter specifies TRUE to swap the meanings 
        ''' of the buttons, or FALSE to restore their original meanings.
        ''' </summary>
        SPI_SETMOUSEBUTTONSWAP = &H21

        ''' <summary>
        ''' Sets the font that is used for icon titles. The uiParam parameter specifies the size of a LOGFONT structure, 
        ''' and the pvParam parameter must point to a LOGFONT structure.
        ''' </summary>
        SPI_SETICONTITLELOGFONT = &H22

        ''' <summary>
        ''' This flag is obsolete. Previous versions of the system use this flag to determine whether ALT+TAB fast task switching is enabled. 
        ''' For Windows 95, Windows 98, and Windows NT version 4.0 and later, fast task switching is always enabled.
        ''' </summary>
        SPI_GETFASTTASKSWITCH = &H23

        ''' <summary>
        ''' This flag is obsolete. Previous versions of the system use this flag to enable or disable ALT+TAB fast task switching. 
        ''' For Windows 95, Windows 98, and Windows NT version 4.0 and later, fast task switching is always enabled.
        ''' </summary>
        SPI_SETFASTTASKSWITCH = &H24

        '#if(WINVER >= 0x0400)
        ''' <summary>
        ''' Sets dragging of full windows either on or off. The uiParam parameter specifies TRUE for on, or FALSE for off. 
        ''' Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
        ''' </summary>
        SPI_SETDRAGFULLWINDOWS = &H25

        ''' <summary>
        ''' Determines whether dragging of full windows is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        ''' if enabled, or FALSE otherwise. 
        ''' Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
        ''' </summary>
        SPI_GETDRAGFULLWINDOWS = &H26

        ''' <summary>
        ''' Retrieves the metrics associated with the nonclient area of nonminimized windows. The pvParam parameter must point 
        ''' to a NONCLIENTMETRICS structure that receives the information. Set the cbSize member of this structure and the uiParam parameter 
        ''' to sizeof(NONCLIENTMETRICS).
        ''' </summary>
        SPI_GETNONCLIENTMETRICS = &H29

        ''' <summary>
        ''' Sets the metrics associated with the nonclient area of nonminimized windows. The pvParam parameter must point 
        ''' to a NONCLIENTMETRICS structure that contains the new parameters. Set the cbSize member of this structure 
        ''' and the uiParam parameter to sizeof(NONCLIENTMETRICS). Also, the lfHeight member of the LOGFONT structure must be a negative value.
        ''' </summary>
        SPI_SETNONCLIENTMETRICS = &H2A

        ''' <summary>
        ''' Retrieves the metrics associated with minimized windows. The pvParam parameter must point to a MINIMIZEDMETRICS structure 
        ''' that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(MINIMIZEDMETRICS).
        ''' </summary>
        SPI_GETMINIMIZEDMETRICS = &H2B

        ''' <summary>
        ''' Sets the metrics associated with minimized windows. The pvParam parameter must point to a MINIMIZEDMETRICS structure 
        ''' that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(MINIMIZEDMETRICS).
        ''' </summary>
        SPI_SETMINIMIZEDMETRICS = &H2C

        ''' <summary>
        ''' Retrieves the metrics associated with icons. The pvParam parameter must point to an ICONMETRICS structure that receives 
        ''' the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(ICONMETRICS).
        ''' </summary>
        SPI_GETICONMETRICS = &H2D

        ''' <summary>
        ''' Sets the metrics associated with icons. The pvParam parameter must point to an ICONMETRICS structure that contains 
        ''' the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ICONMETRICS).
        ''' </summary>
        SPI_SETICONMETRICS = &H2E

        ''' <summary>
        ''' Sets the size of the work area. The work area is the portion of the screen not obscured by the system taskbar 
        ''' or by application desktop toolbars. The pvParam parameter is a pointer to a RECT structure that specifies the new work area rectangle, 
        ''' expressed in virtual screen coordinates. In a system with multiple display monitors, the function sets the work area 
        ''' of the monitor that contains the specified rectangle.
        ''' </summary>
        SPI_SETWORKAREA = &H2F

        ''' <summary>
        ''' Retrieves the size of the work area on the primary display monitor. The work area is the portion of the screen not obscured 
        ''' by the system taskbar or by application desktop toolbars. The pvParam parameter must point to a RECT structure that receives 
        ''' the coordinates of the work area, expressed in virtual screen coordinates. 
        ''' To get the work area of a monitor other than the primary display monitor, call the GetMonitorInfo function.
        ''' </summary>
        SPI_GETWORKAREA = &H30

        ''' <summary>
        ''' Windows Me/98/95:  Pen windows is being loaded or unloaded. The uiParam parameter is TRUE when loading and FALSE 
        ''' when unloading pen windows. The pvParam parameter is null.
        ''' </summary>
        SPI_SETPENWINDOWS = &H31

        ''' <summary>
        ''' Retrieves information about the HighContrast accessibility feature. The pvParam parameter must point to a HIGHCONTRAST structure 
        ''' that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(HIGHCONTRAST). 
        ''' For a general discussion, see remarks.
        ''' Windows NT:  This value is not supported.
        ''' </summary>
        ''' <remarks>
        ''' There is a difference between the High Contrast color scheme and the High Contrast Mode. The High Contrast color scheme changes 
        ''' the system colors to colors that have obvious contrast; you switch to this color scheme by using the Display Options in the control panel. 
        ''' The High Contrast Mode, which uses SPI_GETHIGHCONTRAST and SPI_SETHIGHCONTRAST, advises applications to modify their appearance 
        ''' for visually-impaired users. It involves such things as audible warning to users and customized color scheme 
        ''' (using the Accessibility Options in the control panel). For more information, see HIGHCONTRAST on MSDN.
        ''' For more information on general accessibility features, see Accessibility on MSDN.
        ''' </remarks>
        SPI_GETHIGHCONTRAST = &H42

        ''' <summary>
        ''' Sets the parameters of the HighContrast accessibility feature. The pvParam parameter must point to a HIGHCONTRAST structure 
        ''' that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(HIGHCONTRAST).
        ''' Windows NT:  This value is not supported.
        ''' </summary>
        SPI_SETHIGHCONTRAST = &H43

        ''' <summary>
        ''' Determines whether the user relies on the keyboard instead of the mouse, and wants applications to display keyboard interfaces 
        ''' that would otherwise be hidden. The pvParam parameter must point to a BOOL variable that receives TRUE 
        ''' if the user relies on the keyboard; or FALSE otherwise.
        ''' Windows NT:  This value is not supported.
        ''' </summary>
        SPI_GETKEYBOARDPREF = &H44

        ''' <summary>
        ''' Sets the keyboard preference. The uiParam parameter specifies TRUE if the user relies on the keyboard instead of the mouse, 
        ''' and wants applications to display keyboard interfaces that would otherwise be hidden; uiParam is FALSE otherwise.
        ''' Windows NT:  This value is not supported.
        ''' </summary>
        SPI_SETKEYBOARDPREF = &H45

        ''' <summary>
        ''' Determines whether a screen reviewer utility is running. A screen reviewer utility directs textual information to an output device, 
        ''' such as a speech synthesizer or Braille display. When this flag is set, an application should provide textual information 
        ''' in situations where it would otherwise present the information graphically.
        ''' The pvParam parameter is a pointer to a BOOL variable that receives TRUE if a screen reviewer utility is running, or FALSE otherwise.
        ''' Windows NT:  This value is not supported.
        ''' </summary>
        SPI_GETSCREENREADER = &H46

        ''' <summary>
        ''' Determines whether a screen review utility is running. The uiParam parameter specifies TRUE for on, or FALSE for off.
        ''' Windows NT:  This value is not supported.
        ''' </summary>
        SPI_SETSCREENREADER = &H47

        ''' <summary>
        ''' Retrieves the animation effects associated with user actions. The pvParam parameter must point to an ANIMATIONINFO structure 
        ''' that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(ANIMATIONINFO).
        ''' </summary>
        SPI_GETANIMATION = &H48

        ''' <summary>
        ''' Sets the animation effects associated with user actions. The pvParam parameter must point to an ANIMATIONINFO structure 
        ''' that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ANIMATIONINFO).
        ''' </summary>
        SPI_SETANIMATION = &H49

        ''' <summary>
        ''' Determines whether the font smoothing feature is enabled. This feature uses font antialiasing to make font curves appear smoother 
        ''' by painting pixels at different gray levels. 
        ''' The pvParam parameter must point to a BOOL variable that receives TRUE if the feature is enabled, or FALSE if it is not.
        ''' Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
        ''' </summary>
        SPI_GETFONTSMOOTHING = &H4A

        ''' <summary>
        ''' Enables or disables the font smoothing feature, which uses font antialiasing to make font curves appear smoother 
        ''' by painting pixels at different gray levels. 
        ''' To enable the feature, set the uiParam parameter to TRUE. To disable the feature, set uiParam to FALSE.
        ''' Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
        ''' </summary>
        SPI_SETFONTSMOOTHING = &H4B

        ''' <summary>
        ''' Sets the width, in pixels, of the rectangle used to detect the start of a drag operation. Set uiParam to the new value. 
        ''' To retrieve the drag width, call GetSystemMetrics with the SM_CXDRAG flag.
        ''' </summary>
        SPI_SETDRAGWIDTH = &H4C

        ''' <summary>
        ''' Sets the height, in pixels, of the rectangle used to detect the start of a drag operation. Set uiParam to the new value. 
        ''' To retrieve the drag height, call GetSystemMetrics with the SM_CYDRAG flag.
        ''' </summary>
        SPI_SETDRAGHEIGHT = &H4D

        ''' <summary>
        ''' Used internally; applications should not use this value.
        ''' </summary>
        SPI_SETHANDHELD = &H4E

        ''' <summary>
        ''' Retrieves the time-out value for the low-power phase of screen saving. The pvParam parameter must point to an integer variable 
        ''' that receives the value. This flag is supported for 32-bit applications only.
        ''' Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        ''' Windows 95:  This flag is supported for 16-bit applications only.
        ''' </summary>
        SPI_GETLOWPOWERTIMEOUT = &H4F

        ''' <summary>
        ''' Retrieves the time-out value for the power-off phase of screen saving. The pvParam parameter must point to an integer variable 
        ''' that receives the value. This flag is supported for 32-bit applications only.
        ''' Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        ''' Windows 95:  This flag is supported for 16-bit applications only.
        ''' </summary>
        SPI_GETPOWEROFFTIMEOUT = &H50

        ''' <summary>
        ''' Sets the time-out value, in seconds, for the low-power phase of screen saving. The uiParam parameter specifies the new value. 
        ''' The pvParam parameter must be null. This flag is supported for 32-bit applications only.
        ''' Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        ''' Windows 95:  This flag is supported for 16-bit applications only.
        ''' </summary>
        SPI_SETLOWPOWERTIMEOUT = &H51

        ''' <summary>
        ''' Sets the time-out value, in seconds, for the power-off phase of screen saving. The uiParam parameter specifies the new value. 
        ''' The pvParam parameter must be null. This flag is supported for 32-bit applications only.
        ''' Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        ''' Windows 95:  This flag is supported for 16-bit applications only.
        ''' </summary>
        SPI_SETPOWEROFFTIMEOUT = &H52

        ''' <summary>
        ''' Determines whether the low-power phase of screen saving is enabled. The pvParam parameter must point to a BOOL variable 
        ''' that receives TRUE if enabled, or FALSE if disabled. This flag is supported for 32-bit applications only.
        ''' Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        ''' Windows 95:  This flag is supported for 16-bit applications only.
        ''' </summary>
        SPI_GETLOWPOWERACTIVE = &H53

        ''' <summary>
        ''' Determines whether the power-off phase of screen saving is enabled. The pvParam parameter must point to a BOOL variable 
        ''' that receives TRUE if enabled, or FALSE if disabled. This flag is supported for 32-bit applications only.
        ''' Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        ''' Windows 95:  This flag is supported for 16-bit applications only.
        ''' </summary>
        SPI_GETPOWEROFFACTIVE = &H54

        ''' <summary>
        ''' Activates or deactivates the low-power phase of screen saving. Set uiParam to 1 to activate, or zero to deactivate. 
        ''' The pvParam parameter must be null. This flag is supported for 32-bit applications only.
        ''' Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        ''' Windows 95:  This flag is supported for 16-bit applications only.
        ''' </summary>
        SPI_SETLOWPOWERACTIVE = &H55

        ''' <summary>
        ''' Activates or deactivates the power-off phase of screen saving. Set uiParam to 1 to activate, or zero to deactivate. 
        ''' The pvParam parameter must be null. This flag is supported for 32-bit applications only.
        ''' Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        ''' Windows 95:  This flag is supported for 16-bit applications only.
        ''' </summary>
        SPI_SETPOWEROFFACTIVE = &H56

        ''' <summary>
        ''' Reloads the system cursors. Set the uiParam parameter to zero and the pvParam parameter to null.
        ''' </summary>
        SPI_SETCURSORS = &H57

        ''' <summary>
        ''' Reloads the system icons. Set the uiParam parameter to zero and the pvParam parameter to null.
        ''' </summary>
        SPI_SETICONS = &H58

        ''' <summary>
        ''' Retrieves the input locale identifier for the system default input language. The pvParam parameter must point 
        ''' to an HKL variable that receives this value. For more information, see Languages, Locales, and Keyboard Layouts on MSDN.
        ''' </summary>
        SPI_GETDEFAULTINPUTLANG = &H59

        ''' <summary>
        ''' Sets the default input language for the system shell and applications. The specified language must be displayable 
        ''' using the current system character set. The pvParam parameter must point to an HKL variable that contains 
        ''' the input locale identifier for the default language. For more information, see Languages, Locales, and Keyboard Layouts on MSDN.
        ''' </summary>
        SPI_SETDEFAULTINPUTLANG = &H5A

        ''' <summary>
        ''' Sets the hot key set for switching between input languages. The uiParam and pvParam parameters are not used. 
        ''' The value sets the shortcut keys in the keyboard property sheets by reading the registry again. The registry must be set before this flag is used. the path in the registry is \HKEY_CURRENT_USER\keyboard layout\toggle. Valid values are "1" = ALT+SHIFT, "2" = CTRL+SHIFT, and "3" = none.
        ''' </summary>
        SPI_SETLANGTOGGLE = &H5B

        ''' <summary>
        ''' Windows 95:  Determines whether the Windows extension, Windows Plus!, is installed. Set the uiParam parameter to 1. 
        ''' The pvParam parameter is not used. The function returns TRUE if the extension is installed, or FALSE if it is not.
        ''' </summary>
        SPI_GETWINDOWSEXTENSION = &H5C

        ''' <summary>
        ''' Enables or disables the Mouse Trails feature, which improves the visibility of mouse cursor movements by briefly showing 
        ''' a trail of cursors and quickly erasing them. 
        ''' To disable the feature, set the uiParam parameter to zero or 1. To enable the feature, set uiParam to a value greater than 1 
        ''' to indicate the number of cursors drawn in the trail.
        ''' Windows 2000/NT:  This value is not supported.
        ''' </summary>
        SPI_SETMOUSETRAILS = &H5D

        ''' <summary>
        ''' Determines whether the Mouse Trails feature is enabled. This feature improves the visibility of mouse cursor movements 
        ''' by briefly showing a trail of cursors and quickly erasing them. 
        ''' The pvParam parameter must point to an integer variable that receives a value. If the value is zero or 1, the feature is disabled. 
        ''' If the value is greater than 1, the feature is enabled and the value indicates the number of cursors drawn in the trail. 
        ''' The uiParam parameter is not used.
        ''' Windows 2000/NT:  This value is not supported.
        ''' </summary>
        SPI_GETMOUSETRAILS = &H5E

        ''' <summary>
        ''' Windows Me/98:  Used internally; applications should not use this flag.
        ''' </summary>
        SPI_SETSCREENSAVERRUNNING = &H61

        ''' <summary>
        ''' Same as SPI_SETSCREENSAVERRUNNING.
        ''' </summary>
        SPI_SCREENSAVERRUNNING = SPI_SETSCREENSAVERRUNNING
        '#endif /* WINVER >= 0x0400 */

        ''' <summary>
        ''' Retrieves information about the FilterKeys accessibility feature. The pvParam parameter must point to a FILTERKEYS structure 
        ''' that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(FILTERKEYS).
        ''' </summary>
        SPI_GETFILTERKEYS = &H32

        ''' <summary>
        ''' Sets the parameters of the FilterKeys accessibility feature. The pvParam parameter must point to a FILTERKEYS structure 
        ''' that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(FILTERKEYS).
        ''' </summary>
        SPI_SETFILTERKEYS = &H33

        ''' <summary>
        ''' Retrieves information about the ToggleKeys accessibility feature. The pvParam parameter must point to a TOGGLEKEYS structure 
        ''' that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(TOGGLEKEYS).
        ''' </summary>
        SPI_GETTOGGLEKEYS = &H34

        ''' <summary>
        ''' Sets the parameters of the ToggleKeys accessibility feature. The pvParam parameter must point to a TOGGLEKEYS structure 
        ''' that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(TOGGLEKEYS).
        ''' </summary>
        SPI_SETTOGGLEKEYS = &H35

        ''' <summary>
        ''' Retrieves information about the MouseKeys accessibility feature. The pvParam parameter must point to a MOUSEKEYS structure 
        ''' that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(MOUSEKEYS).
        ''' </summary>
        SPI_GETMOUSEKEYS = &H36

        ''' <summary>
        ''' Sets the parameters of the MouseKeys accessibility feature. The pvParam parameter must point to a MOUSEKEYS structure 
        ''' that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(MOUSEKEYS).
        ''' </summary>
        SPI_SETMOUSEKEYS = &H37

        ''' <summary>
        ''' Determines whether the Show Sounds accessibility flag is on or off. If it is on, the user requires an application 
        ''' to present information visually in situations where it would otherwise present the information only in audible form. 
        ''' The pvParam parameter must point to a BOOL variable that receives TRUE if the feature is on, or FALSE if it is off. 
        ''' Using this value is equivalent to calling GetSystemMetrics (SM_SHOWSOUNDS). That is the recommended call.
        ''' </summary>
        SPI_GETSHOWSOUNDS = &H38

        ''' <summary>
        ''' Sets the parameters of the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure 
        ''' that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
        ''' </summary>
        SPI_SETSHOWSOUNDS = &H39

        ''' <summary>
        ''' Retrieves information about the StickyKeys accessibility feature. The pvParam parameter must point to a STICKYKEYS structure 
        ''' that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(STICKYKEYS).
        ''' </summary>
        SPI_GETSTICKYKEYS = &H3A

        ''' <summary>
        ''' Sets the parameters of the StickyKeys accessibility feature. The pvParam parameter must point to a STICKYKEYS structure 
        ''' that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(STICKYKEYS).
        ''' </summary>
        SPI_SETSTICKYKEYS = &H3B

        ''' <summary>
        ''' Retrieves information about the time-out period associated with the accessibility features. The pvParam parameter must point 
        ''' to an ACCESSTIMEOUT structure that receives the information. Set the cbSize member of this structure and the uiParam parameter 
        ''' to sizeof(ACCESSTIMEOUT).
        ''' </summary>
        SPI_GETACCESSTIMEOUT = &H3C

        ''' <summary>
        ''' Sets the time-out period associated with the accessibility features. The pvParam parameter must point to an ACCESSTIMEOUT 
        ''' structure that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ACCESSTIMEOUT).
        ''' </summary>
        SPI_SETACCESSTIMEOUT = &H3D

        '#if(WINVER >= 0x0400)
        ''' <summary>
        ''' Windows Me/98/95:  Retrieves information about the SerialKeys accessibility feature. The pvParam parameter must point 
        ''' to a SERIALKEYS structure that receives the information. Set the cbSize member of this structure and the uiParam parameter 
        ''' to sizeof(SERIALKEYS).
        ''' Windows Server 2003, Windows XP/2000/NT:  Not supported. The user controls this feature through the control panel.
        ''' </summary>
        SPI_GETSERIALKEYS = &H3E

        ''' <summary>
        ''' Windows Me/98/95:  Sets the parameters of the SerialKeys accessibility feature. The pvParam parameter must point 
        ''' to a SERIALKEYS structure that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter 
        ''' to sizeof(SERIALKEYS). 
        ''' Windows Server 2003, Windows XP/2000/NT:  Not supported. The user controls this feature through the control panel.
        ''' </summary>
        SPI_SETSERIALKEYS = &H3F
        '#endif /* WINVER >= 0x0400 */ 

        ''' <summary>
        ''' Retrieves information about the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure 
        ''' that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
        ''' </summary>
        SPI_GETSOUNDSENTRY = &H40

        ''' <summary>
        ''' Sets the parameters of the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure 
        ''' that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
        ''' </summary>
        SPI_SETSOUNDSENTRY = &H41

        '#if(_WIN32_WINNT >= 0x0400)
        ''' <summary>
        ''' Determines whether the snap-to-default-button feature is enabled. If enabled, the mouse cursor automatically moves 
        ''' to the default button, such as OK or Apply, of a dialog box. The pvParam parameter must point to a BOOL variable 
        ''' that receives TRUE if the feature is on, or FALSE if it is off. 
        ''' Windows 95:  Not supported.
        ''' </summary>
        SPI_GETSNAPTODEFBUTTON = &H5F

        ''' <summary>
        ''' Enables or disables the snap-to-default-button feature. If enabled, the mouse cursor automatically moves to the default button, 
        ''' such as OK or Apply, of a dialog box. Set the uiParam parameter to TRUE to enable the feature, or FALSE to disable it. 
        ''' Applications should use the ShowWindow function when displaying a dialog box so the dialog manager can position the mouse cursor. 
        ''' Windows 95:  Not supported.
        ''' </summary>
        SPI_SETSNAPTODEFBUTTON = &H60
        '#endif /* _WIN32_WINNT >= 0x0400 */

        '#if (_WIN32_WINNT >= 0x0400) || (_WIN32_WINDOWS > 0x0400)
        ''' <summary>
        ''' Retrieves the width, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent 
        ''' to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the width. 
        ''' Windows 95:  Not supported.
        ''' </summary>
        SPI_GETMOUSEHOVERWIDTH = &H62

        ''' <summary>
        ''' Retrieves the width, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent 
        ''' to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the width. 
        ''' Windows 95:  Not supported.
        ''' </summary>
        SPI_SETMOUSEHOVERWIDTH = &H63

        ''' <summary>
        ''' Retrieves the height, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent 
        ''' to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the height. 
        ''' Windows 95:  Not supported.
        ''' </summary>
        SPI_GETMOUSEHOVERHEIGHT = &H64

        ''' <summary>
        ''' Sets the height, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent 
        ''' to generate a WM_MOUSEHOVER message. Set the uiParam parameter to the new height.
        ''' Windows 95:  Not supported.
        ''' </summary>
        SPI_SETMOUSEHOVERHEIGHT = &H65

        ''' <summary>
        ''' Retrieves the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle for TrackMouseEvent 
        ''' to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the time. 
        ''' Windows 95:  Not supported.
        ''' </summary>
        SPI_GETMOUSEHOVERTIME = &H66

        ''' <summary>
        ''' Sets the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle for TrackMouseEvent 
        ''' to generate a WM_MOUSEHOVER message. This is used only if you pass HOVER_DEFAULT in the dwHoverTime parameter in the call to TrackMouseEvent. Set the uiParam parameter to the new time. 
        ''' Windows 95:  Not supported.
        ''' </summary>
        SPI_SETMOUSEHOVERTIME = &H67

        ''' <summary>
        ''' Retrieves the number of lines to scroll when the mouse wheel is rotated. The pvParam parameter must point 
        ''' to a UINT variable that receives the number of lines. The default value is 3. 
        ''' Windows 95:  Not supported.
        ''' </summary>
        SPI_GETWHEELSCROLLLINES = &H68

        ''' <summary>
        ''' Sets the number of lines to scroll when the mouse wheel is rotated. The number of lines is set from the uiParam parameter. 
        ''' The number of lines is the suggested number of lines to scroll when the mouse wheel is rolled without using modifier keys. 
        ''' If the number is 0, then no scrolling should occur. If the number of lines to scroll is greater than the number of lines viewable, 
        ''' and in particular if it is WHEEL_PAGESCROLL (#defined as UINT_MAX), the scroll operation should be interpreted 
        ''' as clicking once in the page down or page up regions of the scroll bar.
        ''' Windows 95:  Not supported.
        ''' </summary>
        SPI_SETWHEELSCROLLLINES = &H69

        ''' <summary>
        ''' Retrieves the time, in milliseconds, that the system waits before displaying a shortcut menu when the mouse cursor is 
        ''' over a submenu item. The pvParam parameter must point to a DWORD variable that receives the time of the delay. 
        ''' Windows 95:  Not supported.
        ''' </summary>
        SPI_GETMENUSHOWDELAY = &H6A

        ''' <summary>
        ''' Sets uiParam to the time, in milliseconds, that the system waits before displaying a shortcut menu when the mouse cursor is 
        ''' over a submenu item. 
        ''' Windows 95:  Not supported.
        ''' </summary>
        SPI_SETMENUSHOWDELAY = &H6B

        ''' <summary>
        ''' Determines whether the IME status window is visible (on a per-user basis). The pvParam parameter must point to a BOOL variable 
        ''' that receives TRUE if the status window is visible, or FALSE if it is not.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETSHOWIMEUI = &H6E

        ''' <summary>
        ''' Sets whether the IME status window is visible or not on a per-user basis. The uiParam parameter specifies TRUE for on or FALSE for off.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETSHOWIMEUI = &H6F
        '#endif

        '#if(WINVER >= 0x0500)
        ''' <summary>
        ''' Retrieves the current mouse speed. The mouse speed determines how far the pointer will move based on the distance the mouse moves. 
        ''' The pvParam parameter must point to an integer that receives a value which ranges between 1 (slowest) and 20 (fastest). 
        ''' A value of 10 is the default. The value can be set by an end user using the mouse control panel application or 
        ''' by an application using SPI_SETMOUSESPEED.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETMOUSESPEED = &H70

        ''' <summary>
        ''' Sets the current mouse speed. The pvParam parameter is an integer between 1 (slowest) and 20 (fastest). A value of 10 is the default. 
        ''' This value is typically set using the mouse control panel application.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETMOUSESPEED = &H71

        ''' <summary>
        ''' Determines whether a screen saver is currently running on the window station of the calling process. 
        ''' The pvParam parameter must point to a BOOL variable that receives TRUE if a screen saver is currently running, or FALSE otherwise.
        ''' Note that only the interactive window station, "WinSta0", can have a screen saver running.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETSCREENSAVERRUNNING = &H72

        ''' <summary>
        ''' Retrieves the full path of the bitmap file for the desktop wallpaper. The pvParam parameter must point to a buffer 
        ''' that receives a null-terminated path string. Set the uiParam parameter to the size, in characters, of the pvParam buffer. The returned string will not exceed MAX_PATH characters. If there is no desktop wallpaper, the returned string is empty.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETDESKWALLPAPER = &H73
        '#endif /* WINVER >= 0x0500 */

        '#if(WINVER >= 0x0500)
        ''' <summary>
        ''' Determines whether active window tracking (activating the window the mouse is on) is on or off. The pvParam parameter must point 
        ''' to a BOOL variable that receives TRUE for on, or FALSE for off.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETACTIVEWINDOWTRACKING = &H1000

        ''' <summary>
        ''' Sets active window tracking (activating the window the mouse is on) either on or off. Set pvParam to TRUE for on or FALSE for off.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETACTIVEWINDOWTRACKING = &H1001

        ''' <summary>
        ''' Determines whether the menu animation feature is enabled. This master switch must be on to enable menu animation effects. 
        ''' The pvParam parameter must point to a BOOL variable that receives TRUE if animation is enabled and FALSE if it is disabled. 
        ''' If animation is enabled, SPI_GETMENUFADE indicates whether menus use fade or slide animation.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETMENUANIMATION = &H1002

        ''' <summary>
        ''' Enables or disables menu animation. This master switch must be on for any menu animation to occur. 
        ''' The pvParam parameter is a BOOL variable; set pvParam to TRUE to enable animation and FALSE to disable animation.
        ''' If animation is enabled, SPI_GETMENUFADE indicates whether menus use fade or slide animation.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETMENUANIMATION = &H1003

        ''' <summary>
        ''' Determines whether the slide-open effect for combo boxes is enabled. The pvParam parameter must point to a BOOL variable 
        ''' that receives TRUE for enabled, or FALSE for disabled.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETCOMBOBOXANIMATION = &H1004

        ''' <summary>
        ''' Enables or disables the slide-open effect for combo boxes. Set the pvParam parameter to TRUE to enable the gradient effect, 
        ''' or FALSE to disable it.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETCOMBOBOXANIMATION = &H1005

        ''' <summary>
        ''' Determines whether the smooth-scrolling effect for list boxes is enabled. The pvParam parameter must point to a BOOL variable 
        ''' that receives TRUE for enabled, or FALSE for disabled.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETLISTBOXSMOOTHSCROLLING = &H1006

        ''' <summary>
        ''' Enables or disables the smooth-scrolling effect for list boxes. Set the pvParam parameter to TRUE to enable the smooth-scrolling effect,
        ''' or FALSE to disable it.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETLISTBOXSMOOTHSCROLLING = &H1007

        ''' <summary>
        ''' Determines whether the gradient effect for window title bars is enabled. The pvParam parameter must point to a BOOL variable 
        ''' that receives TRUE for enabled, or FALSE for disabled. For more information about the gradient effect, see the GetSysColor function.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETGRADIENTCAPTIONS = &H1008

        ''' <summary>
        ''' Enables or disables the gradient effect for window title bars. Set the pvParam parameter to TRUE to enable it, or FALSE to disable it. 
        ''' The gradient effect is possible only if the system has a color depth of more than 256 colors. For more information about 
        ''' the gradient effect, see the GetSysColor function.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETGRADIENTCAPTIONS = &H1009

        ''' <summary>
        ''' Determines whether menu access keys are always underlined. The pvParam parameter must point to a BOOL variable that receives TRUE 
        ''' if menu access keys are always underlined, and FALSE if they are underlined only when the menu is activated by the keyboard.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETKEYBOARDCUES = &H100A

        ''' <summary>
        ''' Sets the underlining of menu access key letters. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to always underline menu 
        ''' access keys, or FALSE to underline menu access keys only when the menu is activated from the keyboard.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETKEYBOARDCUES = &H100B

        ''' <summary>
        ''' Same as SPI_GETKEYBOARDCUES.
        ''' </summary>
        SPI_GETMENUUNDERLINES = SPI_GETKEYBOARDCUES

        ''' <summary>
        ''' Same as SPI_SETKEYBOARDCUES.
        ''' </summary>
        SPI_SETMENUUNDERLINES = SPI_SETKEYBOARDCUES

        ''' <summary>
        ''' Determines whether windows activated through active window tracking will be brought to the top. The pvParam parameter must point 
        ''' to a BOOL variable that receives TRUE for on, or FALSE for off.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETACTIVEWNDTRKZORDER = &H100C

        ''' <summary>
        ''' Determines whether or not windows activated through active window tracking should be brought to the top. Set pvParam to TRUE 
        ''' for on or FALSE for off.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETACTIVEWNDTRKZORDER = &H100D

        ''' <summary>
        ''' Determines whether hot tracking of user-interface elements, such as menu names on menu bars, is enabled. The pvParam parameter 
        ''' must point to a BOOL variable that receives TRUE for enabled, or FALSE for disabled. 
        ''' Hot tracking means that when the cursor moves over an item, it is highlighted but not selected. You can query this value to decide 
        ''' whether to use hot tracking in the user interface of your application.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETHOTTRACKING = &H100E

        ''' <summary>
        ''' Enables or disables hot tracking of user-interface elements such as menu names on menu bars. Set the pvParam parameter to TRUE 
        ''' to enable it, or FALSE to disable it.
        ''' Hot-tracking means that when the cursor moves over an item, it is highlighted but not selected.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETHOTTRACKING = &H100F

        ''' <summary>
        ''' Determines whether menu fade animation is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        ''' when fade animation is enabled and FALSE when it is disabled. If fade animation is disabled, menus use slide animation. 
        ''' This flag is ignored unless menu animation is enabled, which you can do using the SPI_SETMENUANIMATION flag. 
        ''' For more information, see AnimateWindow.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETMENUFADE = &H1012

        ''' <summary>
        ''' Enables or disables menu fade animation. Set pvParam to TRUE to enable the menu fade effect or FALSE to disable it. 
        ''' If fade animation is disabled, menus use slide animation. he The menu fade effect is possible only if the system 
        ''' has a color depth of more than 256 colors. This flag is ignored unless SPI_MENUANIMATION is also set. For more information, 
        ''' see AnimateWindow.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_SETMENUFADE = &H1013

        ''' <summary>
        ''' Determines whether the selection fade effect is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        ''' if enabled or FALSE if disabled. 
        ''' The selection fade effect causes the menu item selected by the user to remain on the screen briefly while fading out 
        ''' after the menu is dismissed.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETSELECTIONFADE = &H1014

        ''' <summary>
        ''' Set pvParam to TRUE to enable the selection fade effect or FALSE to disable it.
        ''' The selection fade effect causes the menu item selected by the user to remain on the screen briefly while fading out 
        ''' after the menu is dismissed. The selection fade effect is possible only if the system has a color depth of more than 256 colors.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_SETSELECTIONFADE = &H1015

        ''' <summary>
        ''' Determines whether ToolTip animation is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        ''' if enabled or FALSE if disabled. If ToolTip animation is enabled, SPI_GETTOOLTIPFADE indicates whether ToolTips use fade or slide animation.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETTOOLTIPANIMATION = &H1016

        ''' <summary>
        ''' Set pvParam to TRUE to enable ToolTip animation or FALSE to disable it. If enabled, you can use SPI_SETTOOLTIPFADE 
        ''' to specify fade or slide animation.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_SETTOOLTIPANIMATION = &H1017

        ''' <summary>
        ''' If SPI_SETTOOLTIPANIMATION is enabled, SPI_GETTOOLTIPFADE indicates whether ToolTip animation uses a fade effect or a slide effect.
        '''  The pvParam parameter must point to a BOOL variable that receives TRUE for fade animation or FALSE for slide animation. 
        '''  For more information on slide and fade effects, see AnimateWindow.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETTOOLTIPFADE = &H1018

        ''' <summary>
        ''' If the SPI_SETTOOLTIPANIMATION flag is enabled, use SPI_SETTOOLTIPFADE to indicate whether ToolTip animation uses a fade effect 
        ''' or a slide effect. Set pvParam to TRUE for fade animation or FALSE for slide animation. The tooltip fade effect is possible only 
        ''' if the system has a color depth of more than 256 colors. For more information on the slide and fade effects, 
        ''' see the AnimateWindow function.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_SETTOOLTIPFADE = &H1019

        ''' <summary>
        ''' Determines whether the cursor has a shadow around it. The pvParam parameter must point to a BOOL variable that receives TRUE 
        ''' if the shadow is enabled, FALSE if it is disabled. This effect appears only if the system has a color depth of more than 256 colors.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETCURSORSHADOW = &H101A

        ''' <summary>
        ''' Enables or disables a shadow around the cursor. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to enable the shadow 
        ''' or FALSE to disable the shadow. This effect appears only if the system has a color depth of more than 256 colors.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_SETCURSORSHADOW = &H101B

        '#if(_WIN32_WINNT >= 0x0501)
        ''' <summary>
        ''' Retrieves the state of the Mouse Sonar feature. The pvParam parameter must point to a BOOL variable that receives TRUE 
        ''' if enabled or FALSE otherwise. For more information, see About Mouse Input on MSDN.
        ''' Windows 2000/NT, Windows 98/95:  This value is not supported.
        ''' </summary>
        SPI_GETMOUSESONAR = &H101C

        ''' <summary>
        ''' Turns the Sonar accessibility feature on or off. This feature briefly shows several concentric circles around the mouse pointer 
        ''' when the user presses and releases the CTRL key. The pvParam parameter specifies TRUE for on and FALSE for off. The default is off. 
        ''' For more information, see About Mouse Input.
        ''' Windows 2000/NT, Windows 98/95:  This value is not supported.
        ''' </summary>
        SPI_SETMOUSESONAR = &H101D

        ''' <summary>
        ''' Retrieves the state of the Mouse ClickLock feature. The pvParam parameter must point to a BOOL variable that receives TRUE 
        ''' if enabled, or FALSE otherwise. For more information, see About Mouse Input.
        ''' Windows 2000/NT, Windows 98/95:  This value is not supported.
        ''' </summary>
        SPI_GETMOUSECLICKLOCK = &H101E

        ''' <summary>
        ''' Turns the Mouse ClickLock accessibility feature on or off. This feature temporarily locks down the primary mouse button 
        ''' when that button is clicked and held down for the time specified by SPI_SETMOUSECLICKLOCKTIME. The uiParam parameter specifies 
        ''' TRUE for on, 
        ''' or FALSE for off. The default is off. For more information, see Remarks and About Mouse Input on MSDN.
        ''' Windows 2000/NT, Windows 98/95:  This value is not supported.
        ''' </summary>
        SPI_SETMOUSECLICKLOCK = &H101F

        ''' <summary>
        ''' Retrieves the state of the Mouse Vanish feature. The pvParam parameter must point to a BOOL variable that receives TRUE 
        ''' if enabled or FALSE otherwise. For more information, see About Mouse Input on MSDN.
        ''' Windows 2000/NT, Windows 98/95:  This value is not supported.
        ''' </summary>
        SPI_GETMOUSEVANISH = &H1020

        ''' <summary>
        ''' Turns the Vanish feature on or off. This feature hides the mouse pointer when the user types; the pointer reappears 
        ''' when the user moves the mouse. The pvParam parameter specifies TRUE for on and FALSE for off. The default is off. 
        ''' For more information, see About Mouse Input on MSDN.
        ''' Windows 2000/NT, Windows 98/95:  This value is not supported.
        ''' </summary>
        SPI_SETMOUSEVANISH = &H1021

        ''' <summary>
        ''' Determines whether native User menus have flat menu appearance. The pvParam parameter must point to a BOOL variable 
        ''' that returns TRUE if the flat menu appearance is set, or FALSE otherwise.
        ''' Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETFLATMENU = &H1022

        ''' <summary>
        ''' Enables or disables flat menu appearance for native User menus. Set pvParam to TRUE to enable flat menu appearance 
        ''' or FALSE to disable it. 
        ''' When enabled, the menu bar uses COLOR_MENUBAR for the menubar background, COLOR_MENU for the menu-popup background, COLOR_MENUHILIGHT 
        ''' for the fill of the current menu selection, and COLOR_HILIGHT for the outline of the current menu selection. 
        ''' If disabled, menus are drawn using the same metrics and colors as in Windows 2000 and earlier.
        ''' Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_SETFLATMENU = &H1023

        ''' <summary>
        ''' Determines whether the drop shadow effect is enabled. The pvParam parameter must point to a BOOL variable that returns TRUE 
        ''' if enabled or FALSE if disabled.
        ''' Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETDROPSHADOW = &H1024

        ''' <summary>
        ''' Enables or disables the drop shadow effect. Set pvParam to TRUE to enable the drop shadow effect or FALSE to disable it. 
        ''' You must also have CS_DROPSHADOW in the window class style.
        ''' Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_SETDROPSHADOW = &H1025

        ''' <summary>
        ''' Retrieves a BOOL indicating whether an application can reset the screensaver's timer by calling the SendInput function 
        ''' to simulate keyboard or mouse input. The pvParam parameter must point to a BOOL variable that receives TRUE 
        ''' if the simulated input will be blocked, or FALSE otherwise. 
        ''' </summary>
        SPI_GETBLOCKSENDINPUTRESETS = &H1026

        ''' <summary>
        ''' Determines whether an application can reset the screensaver's timer by calling the SendInput function to simulate keyboard 
        ''' or mouse input. The uiParam parameter specifies TRUE if the screensaver will not be deactivated by simulated input, 
        ''' or FALSE if the screensaver will be deactivated by simulated input.
        ''' </summary>
        SPI_SETBLOCKSENDINPUTRESETS = &H1027
        '#endif /* _WIN32_WINNT >= 0x0501 */

        ''' <summary>
        ''' Determines whether UI effects are enabled or disabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        ''' if all UI effects are enabled, or FALSE if they are disabled.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETUIEFFECTS = &H103E

        ''' <summary>
        ''' Enables or disables UI effects. Set the pvParam parameter to TRUE to enable all UI effects or FALSE to disable all UI effects.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_SETUIEFFECTS = &H103F

        ''' <summary>
        ''' Retrieves the amount of time following user input, in milliseconds, during which the system will not allow applications 
        ''' to force themselves into the foreground. The pvParam parameter must point to a DWORD variable that receives the time.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETFOREGROUNDLOCKTIMEOUT = &H2000

        ''' <summary>
        ''' Sets the amount of time following user input, in milliseconds, during which the system does not allow applications 
        ''' to force themselves into the foreground. Set pvParam to the new timeout value.
        ''' The calling thread must be able to change the foreground window, otherwise the call fails.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETFOREGROUNDLOCKTIMEOUT = &H2001

        ''' <summary>
        ''' Retrieves the active window tracking delay, in milliseconds. The pvParam parameter must point to a DWORD variable 
        ''' that receives the time.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETACTIVEWNDTRKTIMEOUT = &H2002

        ''' <summary>
        ''' Sets the active window tracking delay. Set pvParam to the number of milliseconds to delay before activating the window 
        ''' under the mouse pointer.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETACTIVEWNDTRKTIMEOUT = &H2003

        ''' <summary>
        ''' Retrieves the number of times SetForegroundWindow will flash the taskbar button when rejecting a foreground switch request. 
        ''' The pvParam parameter must point to a DWORD variable that receives the value.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_GETFOREGROUNDFLASHCOUNT = &H2004

        ''' <summary>
        ''' Sets the number of times SetForegroundWindow will flash the taskbar button when rejecting a foreground switch request. 
        ''' Set pvParam to the number of times to flash.
        ''' Windows NT, Windows 95:  This value is not supported.
        ''' </summary>
        SPI_SETFOREGROUNDFLASHCOUNT = &H2005

        ''' <summary>
        ''' Retrieves the caret width in edit controls, in pixels. The pvParam parameter must point to a DWORD that receives this value.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETCARETWIDTH = &H2006

        ''' <summary>
        ''' Sets the caret width in edit controls. Set pvParam to the desired width, in pixels. The default and minimum value is 1.
        ''' Windows NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_SETCARETWIDTH = &H2007

        '#if(_WIN32_WINNT >= 0x0501)
        ''' <summary>
        ''' Retrieves the time delay before the primary mouse button is locked. The pvParam parameter must point to DWORD that receives 
        ''' the time delay. This is only enabled if SPI_SETMOUSECLICKLOCK is set to TRUE. For more information, see About Mouse Input on MSDN.
        ''' Windows 2000/NT, Windows 98/95:  This value is not supported.
        ''' </summary>
        SPI_GETMOUSECLICKLOCKTIME = &H2008

        ''' <summary>
        ''' Turns the Mouse ClickLock accessibility feature on or off. This feature temporarily locks down the primary mouse button 
        ''' when that button is clicked and held down for the time specified by SPI_SETMOUSECLICKLOCKTIME. The uiParam parameter 
        ''' specifies TRUE for on, or FALSE for off. The default is off. For more information, see Remarks and About Mouse Input on MSDN.
        ''' Windows 2000/NT, Windows 98/95:  This value is not supported.
        ''' </summary>
        SPI_SETMOUSECLICKLOCKTIME = &H2009

        ''' <summary>
        ''' Retrieves the type of font smoothing. The pvParam parameter must point to a UINT that receives the information.
        ''' Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETFONTSMOOTHINGTYPE = &H200A

        ''' <summary>
        ''' Sets the font smoothing type. The pvParam parameter points to a UINT that contains either FE_FONTSMOOTHINGSTANDARD, 
        ''' if standard anti-aliasing is used, or FE_FONTSMOOTHINGCLEARTYPE, if ClearType is used. The default is FE_FONTSMOOTHINGSTANDARD. 
        ''' When using this option, the fWinIni parameter must be set to SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE; otherwise, 
        ''' SystemParametersInfo fails.
        ''' </summary>
        SPI_SETFONTSMOOTHINGTYPE = &H200B

        ''' <summary>
        ''' Retrieves a contrast value that is used in ClearType™ smoothing. The pvParam parameter must point to a UINT 
        ''' that receives the information.
        ''' Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETFONTSMOOTHINGCONTRAST = &H200C

        ''' <summary>
        ''' Sets the contrast value used in ClearType smoothing. The pvParam parameter points to a UINT that holds the contrast value. 
        ''' Valid contrast values are from 1000 to 2200. The default value is 1400.
        ''' When using this option, the fWinIni parameter must be set to SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE; otherwise, 
        ''' SystemParametersInfo fails.
        ''' SPI_SETFONTSMOOTHINGTYPE must also be set to FE_FONTSMOOTHINGCLEARTYPE.
        ''' Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_SETFONTSMOOTHINGCONTRAST = &H200D

        ''' <summary>
        ''' Retrieves the width, in pixels, of the left and right edges of the focus rectangle drawn with DrawFocusRect. 
        ''' The pvParam parameter must point to a UINT.
        ''' Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETFOCUSBORDERWIDTH = &H200E

        ''' <summary>
        ''' Sets the height of the left and right edges of the focus rectangle drawn with DrawFocusRect to the value of the pvParam parameter.
        ''' Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_SETFOCUSBORDERWIDTH = &H200F

        ''' <summary>
        ''' Retrieves the height, in pixels, of the top and bottom edges of the focus rectangle drawn with DrawFocusRect. 
        ''' The pvParam parameter must point to a UINT.
        ''' Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_GETFOCUSBORDERHEIGHT = &H2010

        ''' <summary>
        ''' Sets the height of the top and bottom edges of the focus rectangle drawn with DrawFocusRect to the value of the pvParam parameter.
        ''' Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        ''' </summary>
        SPI_SETFOCUSBORDERHEIGHT = &H2011

        ''' <summary>
        ''' Not implemented.
        ''' </summary>
        SPI_GETFONTSMOOTHINGORIENTATION = &H2012

        ''' <summary>
        ''' Not implemented.
        ''' </summary>
        SPI_SETFONTSMOOTHINGORIENTATION = &H2013
    End Enum
#End Region
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RECT
        Friend Left As Integer
        Friend Top As Integer
        Friend Right As Integer
        Friend Bottom As Integer
        Public Overrides Function ToString() As String
            Return String.Format("Left = {0}, Top = {1}, Right = {2}, Bottom ={3}", Left, Top, Right, Bottom)
        End Function
        Public ReadOnly Property Width() As Integer
            Get
                Return Math.Abs(Right - Left)
            End Get
        End Property
        Public ReadOnly Property Height() As Integer
            Get
                Return Math.Abs(Bottom - Top)
            End Get
        End Property
    End Structure
    Public NotInheritable Class Win32API
        Private Sub New()
        End Sub

        Public Delegate Function EnumDelegate(hWnd As IntPtr, lParam As IntPtr) As Boolean
        <DllImport("user32.dll", EntryPoint:="EnumDesktopWindows", ExactSpelling:=False, CharSet:=CharSet.Auto, SetLastError:=True)> _
        Public Shared Function EnumDesktopWindows(hDesktop As IntPtr, lpEnumCallbackFunction As EnumDelegate, lParam As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")> _
        Public Shared Function GetFocus() As IntPtr
        End Function

        <DllImport("user32.dll", SetLastError:=True)> _
        Public Shared Function SetFocus(hWnd As IntPtr) As IntPtr
        End Function

        <DllImport("kernel32.dll", EntryPoint:="CloseHandle", SetLastError:=True, CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall), SuppressUnmanagedCodeSecurityAttribute> _
        Public Shared Function CloseHandle(handle As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("advapi32.dll", EntryPoint:="CreateProcessAsUser", SetLastError:=True, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function CreateProcessAsUser(hToken As IntPtr, lpApplicationName As String, lpCommandLine As String, ByRef lpProcessAttributes As SECURITY_ATTRIBUTES, ByRef lpThreadAttributes As SECURITY_ATTRIBUTES, bInheritHandle As Boolean, _
            dwCreationFlags As Int32, lpEnvrionment As IntPtr, lpCurrentDirectory As String, ByRef lpStartupInfo As STARTUPINFO, ByRef lpProcessInformation As PROCESS_INFORMATION) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        'only for server 20003
        '[
        '   DllImport("advapi32.dll",
        '      EntryPoint = "CreateProcessWithTokenW", SetLastError = true,
        '      CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)
        ']
        'public static extern bool CreateProcessWithTokenW(IntPtr hToken,uint dwLogonFlags,string lpApplicationName, string lpCommandLine,
        '                        Int32 dwCreationFlags, IntPtr lpEnvrionment,
        '                       string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo,
        '                       ref PROCESS_INFORMATION lpProcessInformation);



        <DllImport("advapi32.dll", EntryPoint:="DuplicateTokenEx")> _
        Public Shared Function DuplicateTokenEx(hExistingToken As IntPtr, dwDesiredAccess As Int32, ByRef lpThreadAttributes As SECURITY_ATTRIBUTES, ImpersonationLevel As Int32, dwTokenType As Int32, ByRef phNewToken As IntPtr) As Boolean
        End Function

        <DllImport("user32.dll", SetLastError:=True)> _
        Private Shared Function SystemParametersInfo(uiAction As SPI, uiParam As UInteger, ByRef pvParam As ANIMATIONINFO, fWinIni As SPIF) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        Public Const GENERIC_ALL_ACCESS As Integer = &H10000000
        'When using the SPI_GETANIMATION or SPI_SETANIMATION actions, the uiParam value must be set to (System.UInt32)Marshal.SizeOf(typeof(ANIMATIONINFO)).

        <Flags> _
        Private Enum SPIF
            None = &H0
            SPIF_UPDATEINIFILE = &H1
            ' Writes the new system-wide parameter setting to the user profile.
            SPIF_SENDCHANGE = &H2
            ' Broadcasts the WM_SETTINGCHANGE message after updating the user profile.
            SPIF_SENDWININICHANGE = &H2
            ' Same as SPIF_SENDCHANGE.
        End Enum

        ''' <summary>
        ''' ANIMATIONINFO specifies animation effects associated with user actions. 
        ''' Used with SystemParametersInfo when SPI_GETANIMATION or SPI_SETANIMATION action is specified.
        ''' </summary>
        ''' <remark>
        ''' The uiParam value must be set to (System.UInt32)Marshal.SizeOf(typeof(ANIMATIONINFO)) when using this structure.
        ''' </remark>
        <StructLayout(LayoutKind.Sequential)> _
        Private Structure ANIMATIONINFO
            ''' <summary>
            ''' Creates an AMINMATIONINFO structure.
            ''' </summary>
            ''' <param name="iMinAnimate">If non-zero and SPI_SETANIMATION is specified, enables minimize/restore animation.</param>
            Public Sub New(iMinAnimate As Boolean)
                Me.cbSize = GetSize()

                If iMinAnimate Then
                    Me.m_iMinAnimate = 1
                Else
                    Me.m_iMinAnimate = 0
                End If
            End Sub

            ''' <summary>
            ''' Always must be set to (System.UInt32)Marshal.SizeOf(typeof(ANIMATIONINFO)).
            ''' </summary>
            Public cbSize As UInteger

            ''' <summary>
            ''' If non-zero, minimize/restore animation is enabled, otherwise disabled.
            ''' </summary>
            Private m_iMinAnimate As Integer

            Public Property IMinAnimate() As Boolean
                Get
                    If Me.m_iMinAnimate = 0 Then
                        Return False
                    Else
                        Return True
                    End If
                End Get
                Set(value As Boolean)
                    If value = True Then
                        Me.m_iMinAnimate = 1
                    Else
                        Me.m_iMinAnimate = 0
                    End If
                End Set
            End Property

            Public Shared Function GetSize() As UInteger
                Return CUInt(Marshal.SizeOf(GetType(ANIMATIONINFO)))
            End Function

        End Structure

        ''' <summary>
        ''' Enable/Disable MinAnimate
        ''' </summary>
        ''' <param name="status"></param>
        Public Shared Sub SetMinimizeMaximizeAnimation(status As Boolean)
            Dim animationInfo__1 As New ANIMATIONINFO(status)

            'System.Threading.Thread.Sleep(500);
            If Not SystemParametersInfo(SPI.SPI_GETANIMATION, ANIMATIONINFO.GetSize(), animationInfo__1, SPIF.None) Then
                Dim ex As New Win32Exception(Marshal.GetLastWin32Error())
                Throw New ApplicationException("SystemParametersInfo get failed: " & ex.Message, ex)
            End If
            'else
            '    EventLog.WriteEntry("Screen Monitor", "SystemParametersInfo get succeeded ", EventLogEntryType.Information, 1, 1);

            If animationInfo__1.IMinAnimate <> status Then
                animationInfo__1.IMinAnimate = status
                'System.Threading.Thread.Sleep(500);
                If Not SystemParametersInfo(SPI.SPI_SETANIMATION, ANIMATIONINFO.GetSize(), animationInfo__1, SPIF.SPIF_SENDCHANGE) Then
                    Dim ex As New Win32Exception(Marshal.GetLastWin32Error())
                    Throw New ApplicationException("SystemParametersInfo set failed: " & ex.Message, ex)
                    'else
                    '    EventLog.WriteEntry("Screen Monitor", "SystemParametersInfo set succeeded ", EventLogEntryType.Information, 1, 1);
                End If
            End If
        End Sub

        Friend Const WM_PAINT As UInteger = &HF

        Friend Const GWL_EXSTYLE As Integer = -20
        Friend Const WS_EX_LAYERED As Integer = &H80000
        Friend Const LWA_ALPHA As Integer = &H2
        Friend Const PW_CLIENTONLY As UInteger = &H1

        Friend Const MAXIMUM_ALLOWED As Integer = &H2000000

        <DllImport("User32.dll", SetLastError:=True)> _
        Friend Shared Function OpenWindowStation(lpszWinSta As [String], fInherit As Boolean, dwDesiredAccess As Integer) As IntPtr
        End Function

        <DllImport("User32.dll", SetLastError:=True)> _
        Friend Shared Function OpenDesktop(lpszDesktop As [String], dwFlags As Integer, fInherit As Boolean, dwDesiredAccess As Integer) As IntPtr
        End Function

        '[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        <DllImport("user32", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Friend Shared Function GetProcessWindowStation() As IntPtr
        End Function

        <DllImport("user32.dll", SetLastError:=True)> _
        Friend Shared Function GetThreadDesktop(dwThreadID As Integer) As IntPtr
        End Function

        <DllImport("kernel32.dll")> _
        Friend Shared Function GetCurrentThreadId() As Integer
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Friend Shared Function SetProcessWindowStation(hWindowStation As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Friend Shared Function SetThreadDesktop(hDesktop As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("User32.dll", SetLastError:=True)> _
        Friend Shared Function CloseWindowStation(hWinSta As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("User32.dll", SetLastError:=True)> _
        Friend Shared Function CloseDesktop(hDesktop As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("rpcrt4.dll")> _
        Friend Shared Function RpcImpersonateClient(rpcBindingHandle As IntPtr) As Integer
        End Function

        <DllImport("rpcrt4.dll")> _
        Friend Shared Function RpcRevertToSelf() As Integer
        End Function

        <DllImport("User32.Dll", SetLastError:=True)> _
        Public Shared Sub GetClassName(hWnd As IntPtr, <MarshalAs(UnmanagedType.LPStr)> param As System.Text.StringBuilder, length As Integer)
        End Sub

        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
        Public Shared Function GetWindowTextLength(hWnd As IntPtr) As Integer
        End Function

        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Public Shared Function GetWindowText(hWnd As IntPtr, lpString As StringBuilder, nMaxCount As Integer) As Integer
        End Function

        Public Delegate Function EnumThreadDelegate(hWnd As IntPtr, lParam As IntPtr) As Boolean

        <DllImport("user32.dll")> _
        Friend Shared Function GetActiveWindow() As IntPtr
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function EnumThreadWindows(dwThreadId As UInteger, lpfn As Win32API.EnumThreadDelegate, lParam As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32")> _
        Friend Shared Function PrintWindow(hWnd As IntPtr, dc As IntPtr, flags As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")> _
        Friend Shared Function PostMessage(hWnd As IntPtr, msg As UInteger, wParam As UInteger, lParam As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")> _
        Friend Shared Function SendMessage(hWnd As IntPtr, msg As UInteger, wParam As UInteger, lParam As UInteger) As UInteger
        End Function

        <DllImport("user32.dll")> _
        Friend Shared Function ReleaseDC(hWnd As IntPtr, hDC As IntPtr) As Integer
        End Function

        <DllImport("user32.dll")> _
        Public Shared Function GetSystemMenu(hWnd As IntPtr, <MarshalAs(UnmanagedType.Bool)> bRevert As Boolean) As IntPtr
        End Function


        <DllImport("user32.dll")> _
        Public Shared Function AppendMenu(hMenu As IntPtr, wFlags As Int32, wIDNewItem As IntPtr, lpNewItem As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")> _
        Friend Shared Function ShowWindow(hWnd As IntPtr, nCmdShow As WindowShowStyle) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")> _
        Public Shared Function IsRectEmpty(<[In]> ByRef lprc As RECT) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")> _
        Friend Shared Function ClientToScreen(hwnd As IntPtr, ByRef lpPoint As Point) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        Public Const WM_SYSCOMMAND As Int32 = &H112
        Public Const MF_SEPARATOR As Int32 = &H800
        Public Const MF_STRING As Int32 = &H0

        <DllImport("user32", SetLastError:=True)> _
        Friend Shared Function GetWindowLong(hWnd As IntPtr, index As Integer) As Integer
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Friend Shared Function SetWindowLong(hWnd As IntPtr, index As Integer, dwNewLong As Integer) As Integer
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Friend Shared Function SetLayeredWindowAttributes(hwnd As IntPtr, crKey As UInteger, bAlpha As Byte, dwFlags As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("advapi32.dll", SetLastError:=True)> _
        Friend Shared Function ImpersonateLoggedOnUser(hToken As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("advapi32.dll", SetLastError:=True)> _
        Public Shared Function RevertToSelf() As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function


        ' handle to process
        ' desired access to process
        <DllImport("advapi32", SetLastError:=True), SuppressUnmanagedCodeSecurityAttribute> _
        Public Shared Function OpenProcessToken(ProcessHandle As System.IntPtr, DesiredAccess As TokenPrivilege, ByRef TokenHandle As IntPtr) As Integer
            ' handle to open access token
        End Function

        '[DllImport("kernel32", SetLastError = true),
        'SuppressUnmanagedCodeSecurityAttribute]
        'public static extern bool CloseHandle(IntPtr handle);
        <DllImport("advapi32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Public Shared Function DuplicateToken(ExistingTokenHandle As IntPtr, SECURITY_IMPERSONATION_LEVEL As Integer, ByRef DuplicateTokenHandle As IntPtr) As Boolean
        End Function
        ''' <summary>Enumeration of the different ways of showing a window using 
        ''' ShowWindow</summary>
        Friend Enum WindowShowStyle As UInteger
            ''' <summary>Hides the window and activates another window.</summary>
            ''' <remarks>See SW_HIDE</remarks>
            Hide = 0
            ''' <summary>Activates and displays a window. If the window is minimized 
            ''' or maximized, the system restores it to its original size and 
            ''' position. An application should specify this flag when displaying 
            ''' the window for the first time.</summary>
            ''' <remarks>See SW_SHOWNORMAL</remarks>
            ShowNormal = 1
            ''' <summary>Activates the window and displays it as a minimized window.</summary>
            ''' <remarks>See SW_SHOWMINIMIZED</remarks>
            ShowMinimized = 2
            ''' <summary>Activates the window and displays it as a maximized window.</summary>
            ''' <remarks>See SW_SHOWMAXIMIZED</remarks>
            ShowMaximized = 3
            ''' <summary>Maximizes the specified window.</summary>
            ''' <remarks>See SW_MAXIMIZE</remarks>
            Maximize = 3
            ''' <summary>Displays a window in its most recent size and position. 
            ''' This value is similar to "ShowNormal", except the window is not 
            ''' actived.</summary>
            ''' <remarks>See SW_SHOWNOACTIVATE</remarks>
            ShowNormalNoActivate = 4
            ''' <summary>Activates the window and displays it in its current size 
            ''' and position.</summary>
            ''' <remarks>See SW_SHOW</remarks>
            Show = 5
            ''' <summary>Minimizes the specified window and activates the next 
            ''' top-level window in the Z order.</summary>
            ''' <remarks>See SW_MINIMIZE</remarks>
            Minimize = 6
            ''' <summary>Displays the window as a minimized window. This value is 
            ''' similar to "ShowMinimized", except the window is not activated.</summary>
            ''' <remarks>See SW_SHOWMINNOACTIVE</remarks>
            ShowMinNoActivate = 7
            ''' <summary>Displays the window in its current size and position. This 
            ''' value is similar to "Show", except the window is not activated.</summary>
            ''' <remarks>See SW_SHOWNA</remarks>
            ShowNoActivate = 8
            ''' <summary>Activates and displays the window. If the window is 
            ''' minimized or maximized, the system restores it to its original size 
            ''' and position. An application should specify this flag when restoring 
            ''' a minimized window.</summary>
            ''' <remarks>See SW_RESTORE</remarks>
            Restore = 9
            ''' <summary>Sets the show state based on the SW_ value specified in the 
            ''' STARTUPINFO structure passed to the CreateProcess function by the 
            ''' program that started the application.</summary>
            ''' <remarks>See SW_SHOWDEFAULT</remarks>
            ShowDefault = 10
            ''' <summary>Windows 2000/XP: Minimizes a window, even if the thread 
            ''' that owns the window is hung. This flag should only be used when 
            ''' minimizing windows from a different thread.</summary>
            ''' <remarks>See SW_FORCEMINIMIZE</remarks>
            ForceMinimized = 11
        End Enum

        Friend Const SRCCOPY As Integer = 13369376

        <DllImport("user32.dll", SetLastError:=True)> _
        Public Shared Function FindWindow(lpClassName As String, lpWindowName As String) As IntPtr
        End Function

        <DllImport("user32.dll", EntryPoint:="GetDC")> _
        Friend Shared Function GetDC(hWnd As IntPtr) As IntPtr
        End Function

        '[DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        'internal extern static IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);

        <DllImport("gdi32.dll", EntryPoint:="DeleteDC")> _
        Friend Shared Function DeleteDC(hDc As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("gdi32.dll", EntryPoint:="DeleteObject")> _
        Friend Shared Function DeleteObject(hDc As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function


        <DllImport("gdi32.dll", EntryPoint:="BitBlt")> _
        Friend Shared Function BitBlt(hdcDest As IntPtr, xDest As Integer, yDest As Integer, wDest As Integer, hDest As Integer, hdcSource As IntPtr, _
            xSrc As Integer, ySrc As Integer, RasterOp As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("gdi32.dll", EntryPoint:="CreateCompatibleBitmap")> _
        Friend Shared Function CreateCompatibleBitmap(hdc As IntPtr, nWidth As Integer, nHeight As Integer) As IntPtr
        End Function

        <DllImport("gdi32.dll", EntryPoint:="CreateCompatibleDC")> _
        Friend Shared Function CreateCompatibleDC(hdc As IntPtr) As IntPtr
        End Function

        <DllImport("gdi32.dll", EntryPoint:="SelectObject")> _
        Friend Shared Function SelectObject(hdc As IntPtr, bmp As IntPtr) As IntPtr
        End Function

        <DllImport("user32.dll", SetLastError:=False)> _
        Public Shared Function GetDesktopWindow() As IntPtr
        End Function

        <DllImport("user32.dll")> _
        Friend Shared Function GetWindowDC(hWnd As IntPtr) As IntPtr
        End Function

        <DllImport("user32.dll")> _
        Friend Shared Function SetForegroundWindow(hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")> _
        Friend Shared Function AttachThreadInput(idAttach As Integer, idAttachTo As Integer, fAttach As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function


        <DllImport("user32.dll")> _
        Friend Shared Function GetForegroundWindow() As IntPtr
        End Function

        <DllImport("User32.Dll")> _
        Public Shared Function IsIconic(hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")> _
        Public Shared Function IsWindow(hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")> _
        Public Shared Function GetWindowRect(hWnd As IntPtr, ByRef lpRect As RECT) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")> _
        Public Shared Function IsWindowVisible(hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")> _
        Friend Shared Function GetClientRect(hWnd As IntPtr, ByRef lpRect As RECT) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll", SetLastError:=True)> _
        Public Shared Function GetWindowThreadProcessId(hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
        End Function

        <DllImport("userenv", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Public Shared Function LoadUserProfile(hToken As IntPtr, lpProfileinfo As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("userenv", SetLastError:=True)> _
        Public Shared Function UnloadUserProfile(hToken As IntPtr, hProfile As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure PROFILEINFO
            Public dwSize As Integer
            Public dwFlags As Integer
            <MarshalAs(UnmanagedType.LPTStr)> _
            Public lpUserName As String
            <MarshalAs(UnmanagedType.LPTStr)> _
            Public lpProfilePath As String
            <MarshalAs(UnmanagedType.LPTStr)> _
            Public lpDefaultPath As String
            <MarshalAs(UnmanagedType.LPTStr)> _
            Public lpServerName As String
            <MarshalAs(UnmanagedType.LPTStr)> _
            Public lpPolicyPath As String
            Public hProfile As IntPtr
        End Structure

        <DllImport("user32.dll")> _
        Public Shared Function IntersectRect(ByRef lprcDst As RECT, <[In]> ByRef lprcSrc1 As RECT, <[In]> ByRef lprcSrc2 As RECT) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

    End Class
End Namespace

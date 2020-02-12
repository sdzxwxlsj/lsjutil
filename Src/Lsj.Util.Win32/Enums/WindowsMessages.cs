﻿using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Windows Messages
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/winmsg/about-messages-and-message-queues
    /// </para>
    /// </summary>
    public enum WindowsMessages : uint
    {
        /// <summary>
        /// Used to define private messages, usually of the form <see cref="WM_APP"/>+x, where x is an integer value.
        /// </summary>
        WM_APP = 0x8000,

        /// <summary>
        /// Used to define private messages for use by private window classes, 
        /// usually of the form <see cref="WM_USER"/>+x, where x is an integer value.
        /// </summary>
        WM_USER = 0x0400,

        /// <summary>
        /// WM_KEYFIRST
        /// </summary>
        WM_KEYFIRST = 0x0100,

        /// <summary>
        /// WM_KEYLAST
        /// </summary>
        WM_KEYLAST = 0x0109,

        /// <summary>
        /// WM_MOUSEFIRST
        /// </summary>
        WM_MOUSEFIRST = 0x0200,

        /// <summary>
        /// WM_MOUSELAST
        /// </summary>
        WM_MOUSELAST = 0x020E,

        #region Button Control Notifications

        /// <summary>
        /// <para>
        /// The <see cref="WM_CTLCOLORBTN"/> message is sent to the parent window of a button before drawing the button.
        /// The parent window can change the button's text and background colors.
        /// However, only owner-drawn buttons respond to the parent window processing this message.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/controls/wm-ctlcolorbtn
        /// </para>
        /// </summary>
        WM_CTLCOLORBTN = 0x0135,

        #endregion

        #region Clipboard Messages

        /// <summary>
        /// An application sends a <see cref="WM_CUT"/> message to an edit control or combo box to delete (cut) the current selection,
        /// if any, in the edit control and copy the deleted text to the clipboard in CF_TEXT format. 
        /// </summary>
        WM_CUT = 0x0300,

        /// <summary>
        /// An application sends the <see cref="WM_COPY"/> message to an edit control or combo box to copy the current selection 
        /// to the clipboard in CF_TEXT format. 
        /// </summary>
        WM_COPY = 0x0301,

        /// <summary>
        /// An application sends a <see cref="WM_PASTE"/> message to an edit control or combo box to copy the current content of the clipboard 
        /// to the edit control at the current caret position. Data is inserted only if the clipboard contains data in CF_TEXT format. 
        /// </summary>
        WM_PASTE = 0x0302,

        /// <summary>
        /// An application sends a <see cref="WM_CLEAR"/> message to an edit control or combo box to delete (clear) the current selection,
        /// if any, from the edit control. 
        /// </summary>
        WM_CLEAR = 0x0303,

        #endregion

        #region Clipboard Notifications

        /// <summary>
        /// Sent to the clipboard owner by a clipboard viewer window to request the name of a CF_OWNERDISPLAY clipboard format.
        /// </summary>
        WM_ASKCBFORMATNAME = 0x030C,

        /// <summary>
        /// Sent to the first window in the clipboard viewer chain when a window is being removed from the chain.
        /// </summary>
        WM_CHANGECBCHAIN = 0x30D,

        /// <summary>
        /// Sent when the contents of the clipboard have changed.
        /// </summary>
        WM_CLIPBOARDUPDATE = 0x31D,

        /// <summary>
        /// Sent to the clipboard owner when a call to the EmptyClipboard function empties the clipboard.
        /// </summary>
        WM_DESTROYCLIPBOARD = 0x307,

        /// <summary>
        /// Sent to the first window in the clipboard viewer chain when the content of the clipboard changes.
        /// This enables a clipboard viewer window to display the new content of the clipboard.
        /// </summary>
        WM_DRAWCLIPBOARD = 0x308,

        /// <summary>
        /// Sent to the clipboard owner by a clipboard viewer window.
        /// This occurs when the clipboard contains data in the CF_OWNERDISPLAY format and an event occurs 
        /// in the clipboard viewer's horizontal scroll bar.
        /// The owner should scroll the clipboard image and update the scroll bar values.
        /// </summary>
        WM_HSCROLLCLIPBOARD = 0x030E,

        /// <summary>
        /// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format 
        /// and the clipboard viewer's client area needs repainting.
        /// </summary>
        WM_PAINTCLIPBOARD = 0x309,

        /// <summary>
        /// Sent to the clipboard owner before it is destroyed, if the clipboard owner has delayed rendering one or more clipboard formats.
        /// For the content of the clipboard to remain available to other applications, the clipboard owner must render data
        /// in all the formats it is capable of generating, and place the data on the clipboard by calling the SetClipboardData function.
        /// </summary>
        WM_RENDERALLFORMATS = 0x306,

        /// <summary>
        /// Sent to the clipboard owner if it has delayed rendering a specific clipboard format and if an application has requested data in that format.
        /// The clipboard owner must render data in the specified format and place it on the clipboard by calling the SetClipboardData function.
        /// </summary>
        WM_RENDERFORMAT = 0x305,

        /// <summary>
        /// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format 
        /// and the clipboard viewer's client area has changed size.
        /// </summary>
        WM_SIZECLIPBOARD = 0x30B,

        /// <summary>
        /// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format
        /// and an event occurs in the clipboard viewer's vertical scroll bar.
        /// The owner should scroll the clipboard image and update the scroll bar values.
        /// </summary>
        WM_VSCROLLCLIPBOARD = 0x30A,

        #endregion

        #region Common Dialog Box Notifications

        /// <summary>
        /// Notifies the hook procedure of a Page Setup dialog box, PagePaintHook, 
        /// that the dialog box is about to draw the envelope-stamp rectangle of the sample page.
        /// </summary>
        WM_PSD_ENVSTAMPRECT = WM_USER + 5,

        /// <summary>
        /// Notifies a PagePaintHook hook procedure of the coordinates of the sample page rectangle in the Page Setup dialog box.
        /// The dialog box sends this message when it is about to draw the contents of the sample page.
        /// </summary>
        WM_PSD_FULLPAGERECT = WM_USER + 1,

        /// <summary>
        /// Notifies the hook procedure of a Page Setup dialog box, PagePaintHook,
        /// that the dialog box is about to draw Greek text inside the margin rectangle of the sample page.
        /// </summary>
        WM_PSD_GREEKTEXTRECT = WM_USER + 4,

        /// <summary>
        /// Notifies the hook procedure of a Page Setup dialog box, PagePaintHook,
        /// that the dialog box is about to draw the margin rectangle of the sample page.
        /// </summary>
        WM_PSD_MARGINRECT = WM_USER + 3,

        /// <summary>
        /// Notifies a PagePaintHook hook procedure of the coordinates of the margin rectangle in the sample page.
        /// A Page Setup dialog box sends this message when it is about to draw the contents of the sample page.
        /// </summary>
        WM_PSD_MINMARGINRECT = WM_USER + 2,

        /// <summary>
        /// Notifies a PagePaintHook hook procedure that the Page Setup dialog box is about to draw the contents of the sample page.
        /// The hook procedure can use this message to carry out initialization tasks related to drawing the contents of the sample page.
        /// </summary>
        WM_PSD_PAGESETUPDLG = WM_USER,

        /// <summary>
        /// Notifies the hook procedure of a Page Setup dialog box, PagePaintHook,
        /// that the dialog box is about to draw the return address portion of an envelope sample page.
        /// </summary>
        WM_PSD_YAFULLPAGERECT = WM_USER + 6,

        #endregion

        #region Cursor Notifications

        /// <summary>
        /// Sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured.
        /// </summary>
        WM_SETCURSOR = 0x0020,

        #endregion

        #region Data Copy Message

        /// <summary>
        /// An application sends the <see cref="WM_COPYDATA"/> message to pass data to another application.
        /// </summary>
        WM_COPYDATA = 0x004A,

        #endregion

        #region Desktop Window Manager Messages

        /// <summary>
        /// Informs all top-level windows that the colorization color has changed.
        /// </summary>
        WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320,

        /// <summary>
        /// Informs all top-level windows that Desktop Window Manager (DWM) composition has been enabled or disabled.
        /// </summary>
        WM_DWMCOMPOSITIONCHANGED = 0x031E,

        /// <summary>
        /// Sent when the non-client area rendering policy has changed.
        /// </summary>
        WM_DWMNCRENDERINGCHANGED = 0x031F,

        /// <summary>
        /// Instructs a window to provide a static bitmap to use as a live preview (also known as a Peek preview) of that window.
        /// </summary>
        WM_DWMSENDICONICLIVEPREVIEWBITMAP = 0x0326,

        /// <summary>
        /// Instructs a window to provide a static bitmap to use as a thumbnail representation of that window.
        /// </summary>
        WM_DWMSENDICONICTHUMBNAIL = 0x0323,

        /// <summary>
        /// Sent when a Desktop Window Manager (DWM) composed window is maximized.
        /// </summary>
        WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321,

        #endregion

        #region Device Management Messages

        /// <summary>
        /// Notifies an application of a change to the hardware configuration of a device or the computer.
        /// </summary>
        WM_DEVICECHANGE = 0x0219,

        #endregion

        #region Dialog Box Notifications

        /// <summary>
        /// Sent to a dialog box before the system draws the dialog box.
        /// By responding to this message, the dialog box can set its text and background colors using the specified display device context handle.
        /// </summary>
        WM_CTLCOLORDLG = 0x0136,

        /// <summary>
        /// Sent to the owner window of a modal dialog box or menu that is entering an idle state.
        /// A modal dialog box or menu enters an idle state when no messages are waiting in its queue
        /// after it has processed one or more previous messages.
        /// </summary>
        WM_ENTERIDLE = 0x0121,

        /// <summary>
        /// Sent to the window procedure associated with a control.
        /// By default, the system handles all keyboard input to the control;
        /// the system interprets certain types of keyboard input as dialog box navigation keys.
        /// To override this default behavior, the control can respond to the <see cref="WM_GETDLGCODE"/> message to indicate the types 
        /// of input it wants to process itself.
        /// </summary>
        WM_GETDLGCODE = 0x0087,

        /// <summary>
        /// Sent to the dialog box procedure immediately before a dialog box is displayed.
        /// Dialog box procedures typically use this message to initialize controls and carry out any other initialization tasks
        /// that affect the appearance of the dialog box.
        /// </summary>
        WM_INITDIALOG = 0x0110,

        /// <summary>
        /// Sent to a dialog box procedure to set the keyboard focus to a different control in the dialog box.
        /// </summary>
        WM_NEXTDLGCTL = 0x0028,

        #endregion

        #region Dynamic Data Exchange Messages

        /// <summary>
        /// A Dynamic Data Exchange (DDE) client application sends a <see cref="WM_DDE_INITIATE"/> message to
        /// initiate a conversation with a server application responding to the specified application and topic names.
        /// Upon receiving this message, all server applications with names that match the specified application and 
        /// that support the specified topic are expected to acknowledge it. (For more information, see the <see cref="WM_DDE_ACK"/> message.)
        /// </summary>
        WM_DDE_INITIATE = 0x03E0,

        #endregion

        #region Dynamic Data Exchange Notifications

        /// <summary>
        /// The WM_DDE_ACK message notifies a Dynamic Data Exchange (DDE) application of the receipt and processing of the following messages: 
        /// <see cref="WM_DDE_POKE"/>, <see cref="WM_DDE_EXECUTE"/>, <see cref="WM_DDE_DATA"/>, <see cref="WM_DDE_ADVISE"/>,
        /// <see cref="WM_DDE_UNADVISE"/>, <see cref="WM_DDE_INITIATE"/>, <see cref="WM_DDE_REQUEST"/> (in some cases).
        /// </summary>
        WM_DDE_ACK = 0x03E4,

        /// <summary>
        /// A Dynamic Data Exchange (DDE) client application posts the <see cref="WM_DDE_ADVISE"/> message to a DDE server application
        /// to request the server to supply an update for a data item whenever the item changes.
        /// </summary>
        WM_DDE_ADVISE = 0x03E2,

        /// <summary>
        /// A Dynamic Data Exchange (DDE) server application posts a <see cref="WM_DDE_DATA"/> message to a DDE client application
        /// to pass a data item to the client or to notify the client of the availability of a data item.
        /// </summary>
        WM_DDE_DATA = 0x03E5,

        /// <summary>
        /// A Dynamic Data Exchange (DDE) client application posts a <see cref="WM_DDE_EXECUTE"/> message to a DDE server application
        /// to send a string to the server to be processed as a series of commands.
        /// The server application is expected to post a <see cref="WM_DDE_ACK"/> message in response.
        /// </summary>
        WM_DDE_EXECUTE = 0x03E8,

        /// <summary>
        /// A Dynamic Data Exchange (DDE) client application posts a <see cref="WM_DDE_POKE"/> message to a DDE server application.
        /// A client uses this message to request the server to accept an unsolicited data item.
        /// The server is expected to reply with a <see cref="WM_DDE_ACK"/> message indicating whether it accepted the data item.
        /// </summary>
        WM_DDE_POKE = 0x03E7,

        /// <summary>
        /// A Dynamic Data Exchange (DDE) client application posts a <see cref="WM_DDE_REQUEST"/> message to a DDE server application
        /// to request the value of a data item.
        /// </summary>
        WM_DDE_REQUEST = 0x03E6,

        /// <summary>
        /// A Dynamic Data Exchange (DDE) application (client or server) posts a <see cref="WM_DDE_TERMINATE"/> message to terminate a conversation.
        /// </summary>
        WM_DDE_TERMINATE = 0x03E1,

        /// <summary>
        /// A Dynamic Data Exchange (DDE) client application posts a <see cref="WM_DDE_UNADVISE"/> message to inform a DDE server application
        /// that the specified item or a particular clipboard format for the item should no longer be updated.
        /// This terminates the warm or hot data link for the specified item.
        /// </summary>
        WM_DDE_UNADVISE = 0x03E3,

        #endregion

        #region High DPI

        /// <summary>
        /// <para>
        /// Sent when the effective dots per inch (dpi) for a window has changed. The DPI is the scale factor for a window.
        /// There are multiple events that can cause the DPI to change. The following list indicates the possible causes for the change in DPI.
        /// The window is moved to a new monitor that has a different DPI.
        /// The DPI of the monitor hosting the window changes.
        /// </para>
        /// <para>
        /// The current DPI for a window always equals the last DPI sent by <see cref="WM_DPICHANGED"/>.
        /// This is the scale factor that the window should be scaling to for threads that are aware of DPI changes.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/hidpi/wm-dpichanged
        /// </para>
        /// </summary>
        WM_DPICHANGED = 0x02E0,

        /// <summary>
        /// <para>
        /// For Per Monitor v2 top-level windows, this message is sent to all HWNDs in the child HWDN tree of the window that is undergoing a DPI change.
        /// This message occurs before the top-level window receives <see cref="WM_DPICHANGED"/>, and traverses the child tree from the bottom up.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/hidpi/wm-dpichanged-beforeparent
        /// </para>
        /// </summary>
        WM_DPICHANGED_BEFOREPARENT = 0x02E2,

        /// <summary>
        /// <para>
        /// For Per Monitor v2 top-level windows, this message is sent to all HWNDs in the child HWDN tree of the window that is undergoing a DPI change.
        /// This message occurs after the top-level window receives WM_DPICHANGED, and traverses the child tree from the top down.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/hidpi/wm-dpichanged-afterparent
        /// </para>
        /// </summary>
        WM_DPICHANGED_AFTERPARENT = 0x02E3,

        /// <summary>
        /// <para>
        /// This message tells the operating system that the window will be sized to dimensions other than the default.
        /// This message is sent to top-level windows with a DPI_AWARENESS_CONTEXT of Per Monitor v2 before a <see cref="WM_DPICHANGED"/> message is sent, 
        /// and allows the window to compute its desired size for the pending DPI change.
        /// As linear DPI scaling is the default behavior, this is only useful in scenarios where the window wants to scale non-linearly.
        /// If the application responds to this message, the resulting size will be the candidate rectangle send to <see cref="WM_DPICHANGED"/>.
        /// Use this message to alter the size of the rect that is provided with <see cref="WM_DPICHANGED"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/hidpi/wm-getdpiscaledsize
        /// </para>
        /// </summary>
        WM_GETDPISCALEDSIZE = 0x02E4,

        #endregion

        #region Hook Notifications

        /// <summary>
        /// Posted to an application when a user cancels the application's journaling activities. The message is posted with a NULL window handle.
        /// </summary>
        WM_CANCELJOURNAL = 0x004B,

        /// <summary>
        /// Sent by a computer-based training (CBT) application to separate user-input messages from other messages
        /// sent through the WH_JOURNALPLAYBACK procedure.
        /// </summary>
        WM_QUEUESYNC = 0x0023,

        #endregion

        #region Keyboard Accelerator Messages

        /// <summary>
        /// An application sends the <see cref="WM_CHANGEUISTATE"/> message to indicate that the UI state should be changed.
        /// </summary>
        WM_CHANGEUISTATE = 0x0127,

        /// <summary>
        /// Sent when a menu is about to become active. It occurs when the user clicks an item on the menu bar or presses a menu key.
        /// This allows the application to modify the menu before it is displayed.
        /// </summary>
        WM_INITMENU = 0x0116,

        /// <summary>
        /// An application sends the <see cref="WM_QUERYUISTATE"/> message to retrieve the UI state for a window.
        /// </summary>
        WM_QUERYUISTATE = 0x0129,

        /// <summary>
        /// An application sends the <see cref="WM_UPDATEUISTATE"/> message to change the UI state for the specified window and all its child windows.
        /// </summary>
        WM_UPDATEUISTATE = 0x0128,

        #endregion

        #region Keyboard Accelerator Notifications

        /// <summary>
        /// Sent when a drop-down menu or submenu is about to become active.
        /// This allows an application to modify the menu before it is displayed, without changing the entire menu.
        /// </summary>
        WM_INITMENUPOPUP = 0x0117,

        /// <summary>
        /// Sent when a menu is active and the user presses a key that does not correspond to any mnemonic or accelerator key.
        /// This message is sent to the window that owns the menu.
        /// </summary>
        WM_MENUCHAR = 0x0120,

        /// <summary>
        /// Sent to a menu's owner window when the user selects a menu item.
        /// </summary>
        WM_MENUSELECT = 0x011F,

        /// <summary>
        /// Posted to the window with the keyboard focus when a <see cref="WM_SYSKEYDOWN"/> message is translated
        /// by the <see cref="TranslateMessage"/> function.
        /// It specifies the character code of a system character key that is, a character key that is pressed while the ALT key is down.
        /// </summary>
        WM_SYSCHAR = 0x0106,

        /// <summary>
        /// A window receives this message when the user chooses a command from the Window menu (formerly known as the system or control menu)
        /// or when the user chooses the maximize button, minimize button, restore button, or close button.
        /// </summary>
        WM_SYSCOMMAND = 0x0112,

        #endregion

        #region Keyboard Input Messages

        /// <summary>
        /// Sent to determine the hot key associated with a window.
        /// </summary>
        WM_GETHOTKEY = 0x0033,

        /// <summary>
        /// Sent to a window to associate a hot key with the window. When the user presses the hot key, the system activates the window.
        /// </summary>
        WM_SETHOTKEY = 0x0032,

        #endregion

        #region Keyboard Input Notifications

        /// <summary>
        /// Sent to both the window being activated and the window being deactivated.
        /// If the windows use the same input queue, the message is sent synchronously,
        /// first to the window procedure of the top-level window being deactivated,
        /// then to the window procedure of the top-level window being activated.
        /// If the windows use different input queues, the message is sent asynchronously, so the window is activated immediately.
        /// </summary>
        WM_ACTIVATE = 0x0006,

        /// <summary>
        /// Notifies a window that the user generated an application command event, for example,
        /// by clicking an application command button using the mouse or typing an application command key on the keyboard.
        /// </summary>
        WM_APPCOMMAND = 0x0319,

        /// <summary>
        /// Posted to the window with the keyboard focus when a <see cref="WM_KEYDOWN"/> message is translated
        /// by the <see cref="TranslateMessage"/> function.
        /// The <see cref="WM_CHAR"/> message contains the character code of the key that was pressed.
        /// </summary>
        WM_CHAR = 0x0102,

        /// <summary>
        /// Posted to the window with the keyboard focus when a <see cref="WM_KEYUP"/> message is translated
        /// by the <see cref="TranslateMessage"/> function.
        /// <see cref="WM_DEADCHAR"/> specifies a character code generated by a dead key.
        /// A dead key is a key that generates a character, such as the umlaut (double-dot),
        /// that is combined with another character to form a composite character.
        /// For example, the umlaut-O character ( ) is generated by typing the dead key for the umlaut character, and then typing the O key.
        /// </summary>
        WM_DEADCHAR = 0x0103,

        /// <summary>
        /// Posted when the user presses a hot key registered by the RegisterHotKey function.
        /// The message is placed at the top of the message queue associated with the thread that registered the hot key.
        /// </summary>
        WM_HOTKEY = 0x0312,

        /// <summary>
        /// Posted to the window with the keyboard focus when a nonsystem key is pressed.
        /// A nonsystem key is a key that is pressed when the ALT key is not pressed.
        /// </summary>
        WM_KEYDOWN = 0x0100,

        /// <summary>
        /// Posted to the window with the keyboard focus when a nonsystem key is released.
        /// A nonsystem key is a key that is pressed when the ALT key is not pressed, or a keyboard key that is pressed
        /// when a window has the keyboard focus.
        /// </summary>
        WM_KEYUP = 0x0101,

        /// <summary>
        /// Sent to a window immediately before it loses the keyboard focus.
        /// </summary>
        WM_KILLFOCUS = 0x0008,

        /// <summary>
        /// Sent to a window after it has gained the keyboard focus.
        /// </summary>
        WM_SETFOCUS = 0x0007,

        /// <summary>
        /// Sent to the window with the keyboard focus when a <see cref="WM_SYSKEYDOWN"/> message is translated
        /// by the <see cref="TranslateMessage"/> function.
        /// <see cref="WM_SYSDEADCHAR"/> specifies the character code of a system dead key that is, a dead key that is pressed
        /// while holding down the ALT key.
        /// </summary>
        WM_SYSDEADCHAR = 0x0107,

        /// <summary>
        /// Posted to the window with the keyboard focus when the user presses the F10 key (which activates the menu bar)
        /// or holds down the ALT key and then presses another key.
        /// It also occurs when no window currently has the keyboard focus;
        /// in this case, the <see cref="WM_SYSKEYDOWN"/> message is sent to the active window.
        /// The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter.
        /// </summary>
        WM_SYSKEYDOWN = 0x0104,

        /// <summary>
        /// Posted to the window with the keyboard focus when the user releases a key that was pressed while the ALT key was held down.
        /// It also occurs when no window currently has the keyboard focus;
        /// in this case, the <see cref="WM_SYSKEYUP"/> message is sent to the active window.
        /// The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter.
        /// </summary>
        WM_SYSKEYUP = 0x0105,

        /// <summary>
        /// The WM_UNICHAR message can be used by an application to post input to other windows.
        /// This message contains the character code of the key that was pressed.
        /// (Test whether a target app can process <see cref="WM_UNICHAR"/> messages by sending the message with wParam set to UNICODE_NOCHAR.)
        /// </summary>
        WM_UNICHAR = 0x0109,

        #endregion

        #region Menu Notifications

        /// <summary>
        /// Sent when the user selects a command item from a menu, when a control sends a notification message to its parent window,
        /// or when an accelerator keystroke is translated.
        /// </summary>
        WM_COMMAND = 0x0111,

        /// <summary>
        /// Notifies a window that the user clicked the right mouse button (right-clicked) in the window.
        /// </summary>
        WM_CONTEXTMENU = 0x007B,

        /// <summary>
        /// Notifies an application's main window procedure that a menu modal loop has been entered.
        /// </summary>
        WM_ENTERMENULOOP = 0x0211,

        /// <summary>
        /// Notifies an application's main window procedure that a menu modal loop has been exited.
        /// </summary>
        WM_EXITMENULOOP = 0x0212,

        /// <summary>
        /// Sent to request extended title bar information.
        /// </summary>
        WM_GETTITLEBARINFOEX = 0x033F,

        /// <summary>
        /// Sent when the user makes a selection from a menu.
        /// </summary>
        WM_MENUCOMMAND = 0x0126,

        /// <summary>
        /// Sent to the owner of a drag-and-drop menu when the user drags a menu item.
        /// </summary>
        WM_MENUDRAG = 0x0123,

        /// <summary>
        /// Sent to the owner of a drag-and-drop menu when the mouse cursor enters a menu item or moves from the center of the item to the top or bottom of the item.
        /// </summary>
        WM_MENUGETOBJECT = 0x0124,

        /// <summary>
        /// Sent when the user releases the right mouse button while the cursor is on a menu item.
        /// </summary>
        WM_MENURBUTTONUP = 0x0122,

        /// <summary>
        /// Sent to an application when the right or left arrow key is used to switch between the menu bar and the system menu.
        /// </summary>
        WM_NEXTMENU = 0x0213,

        /// <summary>
        /// Sent when a drop-down menu or submenu has been destroyed.
        /// </summary>
        WM_UNINITMENUPOPUP = 0x0125,

        #endregion

        #region Mouse Input Notifications

        /// <summary>
        /// Sent to the window that is losing the mouse capture.
        /// </summary>
        WM_CAPTURECHANGED = 0x0215,

        /// <summary>
        /// Posted when the user double-clicks the left mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_LBUTTONDBLCLK = 0x0213,

        /// <summary>
        /// Posted when the user presses the left mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_LBUTTONDOWN = 0x0201,

        /// <summary>
        /// Posted when the user releases the left mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_LBUTTONUP = 0x0202,

        /// <summary>
        /// Posted when the user double-clicks the middle mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_MBUTTONDBLCLK = 0x0209,

        /// <summary>
        /// Posted when the user presses the middle mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_MBUTTONDOWN = 0x0207,

        /// <summary>
        /// Posted when the user releases the middle mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_MBUTTONUP = 0x0208,

        /// <summary>
        /// Sent when the cursor is in an inactive window and the user presses a mouse button.
        /// The parent window receives this message only if the child window passes it to the <see cref="DefWindowProc"/> function.
        /// </summary>
        WM_MOUSEACTIVATE = 0x0021,

        /// <summary>
        /// Posted to a window when the cursor hovers over the client area of the window for the period
        /// of time specified in a prior call to TrackMouseEvent.
        /// </summary>
        WM_MOUSEHOVER = 0x02A1,

        /// <summary>
        /// Sent to the active window when the mouse's horizontal scroll wheel is tilted or rotated.
        /// The <see cref="DefWindowProc"/> function propagates the message to the window's parent.
        /// There should be no internal forwarding of the message, since <see cref="DefWindowProc"/> propagates it up the parent chain
        /// until it finds a window that processes it.
        /// </summary>
        WM_MOUSEHWHEEL = 0x020E,

        /// <summary>
        /// Posted to a window when the cursor leaves the client area of the window specified in a prior call to TrackMouseEvent.
        /// </summary>
        WM_MOUSELEAVE = 0x02A3,

        /// <summary>
        /// Posted to a window when the cursor moves.
        /// If the mouse is not captured, the message is posted to the window that contains the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_MOUSEMOVE = 0x0200,

        /// <summary>
        /// Sent to the focus window when the mouse wheel is rotated.
        /// The <see cref="DefWindowProc"/> function propagates the message to the window's parent.
        /// There should be no internal forwarding of the message, since <see cref="DefWindowProc"/> propagates it up the parent chain
        /// until it finds a window that processes it.
        /// </summary>
        WM_MOUSEWHEEL = 0x020A,

        /// <summary>
        /// Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate.
        /// This can happen, for example, when the cursor moves, when a mouse button is pressed or released,
        /// or in response to a call to a function such as WindowFromPoint.
        /// If the mouse is not captured, the message is sent to the window beneath the cursor.
        /// Otherwise, the message is sent to the window that has captured the mouse.
        /// </summary>
        WM_NCHITTEST = 0x0084,

        /// <summary>
        /// Posted when the user double-clicks the left mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCLBUTTONDBLCLK = 0x00A3,

        /// <summary>
        /// Posted when the user presses the left mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCLBUTTONDOWN = 0x00A1,

        /// <summary>
        /// Posted when the user releases the left mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCLBUTTONUP = 0x00A2,

        /// <summary>
        /// Posted when the user double-clicks the middle mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCMBUTTONDBLCLK = 0x00A9,

        /// <summary>
        /// Posted when the user presses the middle mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCMBUTTONDOWN = 0x00A7,

        /// <summary>
        /// Posted when the user releases the middle mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCMBUTTONUP = 0x00A8,

        /// <summary>
        /// Posted to a window when the cursor hovers over the nonclient area of the window for the period of time specified in a prior call to TrackMouseEvent.
        /// </summary>
        WM_NCMOUSEHOVER = 0x02A0,

        /// <summary>
        /// Posted to a window when the cursor leaves the nonclient area of the window specified in a prior call to TrackMouseEvent.
        /// </summary>
        WM_NCMOUSELEAVE = 0x02A2,

        /// <summary>
        /// Posted to a window when the cursor is moved within the nonclient area of the window.
        /// This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCMOUSEMOVE = 0x00A0,

        /// <summary>
        /// Posted when the user double-clicks the right mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCRBUTTONDBLCLK = 0x00A6,

        /// <summary>
        /// Posted when the user presses the right mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCRBUTTONDOWN = 0x00A4,

        /// <summary>
        /// Posted when the user releases the right mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCRBUTTONUP = 0x00A5,

        /// <summary>
        /// Posted when the user double-clicks the first or second X button while the cursor is in the nonclient area of a window.
        /// This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCXBUTTONDBLCLK = 0x00A0,

        /// <summary>
        /// Posted when the user presses the first or second X button while the cursor is in the nonclient area of a window
        /// . This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCXBUTTONDOWN = 0x00AB,

        /// <summary>
        /// Posted when the user releases the first or second X button while the cursor is in the nonclient area of a window.
        /// This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        WM_NCXBUTTONUP = 0x00AC,

        /// <summary>
        /// Posted when the user double-clicks the right mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_RBUTTONDBLCLK = 0x0206,

        /// <summary>
        /// Posted when the user presses the right mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_RBUTTONDOWN = 0x0204,

        /// <summary>
        /// Posted when the user releases the right mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_RBUTTONUP = 0x0205,

        /// <summary>
        /// Posted when the user double-clicks the first or second X button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_XBUTTONDBLCLK = 0x020D,

        /// <summary>
        /// Posted when the user presses the first or second X button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_XBUTTONDOWN = 0x020B,

        /// <summary>
        /// Posted when the user releases the first or second X button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_XBUTTONUP = 0x020C,

        #endregion

        #region Multiple Document Interface Messages

        /// <summary>
        /// An application sends the <see cref="WM_MDIACTIVATE"/> message to a multiple-document interface (MDI) client window
        /// to instruct the client window to activate a different MDI child window.
        /// </summary>
        WM_MDIACTIVATE = 0x0222,

        /// <summary>
        /// An application sends the <see cref="WM_MDICASCADE"/> message to a multiple-document interface (MDI) client window
        /// to arrange all its child windows in a cascade format.
        /// </summary>
        WM_MDICASCADE = 0x0227,

        /// <summary>
        /// An application sends the <see cref="WM_MDICASCADE"/> message to a multiple-document interface (MDI) client window
        /// to create an MDI child window.
        /// </summary>
        WM_MDICREATE = 0x0220,

        /// <summary>
        /// An application sends the <see cref="WM_MDIDESTROY"/>message to a multiple-document interface (MDI) client window
        /// to close an MDI child window.
        /// </summary>
        WM_MDIDESTROY = 0x0221,

        /// <summary>
        /// An application sends the <see cref="WM_MDIGETACTIVE"/> message to a multiple-document interface (MDI) client window
        /// to retrieve the handle to the active MDI child window.
        /// </summary>
        WM_MDIGETACTIVE = 0x0229,

        /// <summary>
        /// An application sends the <see cref="WM_MDIICONARRANGE"/> message to a multiple-document interface (MDI) client window
        /// to arrange all minimized MDI child windows. It does not affect child windows that are not minimized.
        /// </summary>
        WM_MDIICONARRANGE = 0x0228,

        /// <summary>
        /// An application sends the <see cref="WM_MDIMAXIMIZE"/> message to a multiple-document interface (MDI) client window
        /// to maximize an MDI child window. The system resizes the child window to make its client area fill the client window.
        /// The system places the child window's window menu icon in the rightmost position of the frame window's menu bar,
        /// and places the child window's restore icon in the leftmost position.
        /// The system also appends the title bar text of the child window to that of the frame window.
        /// </summary>
        WM_MDIMAXIMIZE = 0x0225,

        /// <summary>
        /// An application sends the <see cref="WM_MDINEXT"/>message to a multiple-document interface (MDI) client window
        /// to activate the next or previous child window.
        /// </summary>
        WM_MDINEXT = 0x0224,

        /// <summary>
        /// An application sends the <see cref="WM_MDIREFRESHMENU"/> message to a multiple-document interface (MDI) client window
        /// to refresh the window menu of the MDI frame window.
        /// </summary>
        WM_MDIREFRESHMENU = 0x0234,

        /// <summary>
        /// An application sends the <see cref="WM_MDIRESTORE"/> message to a multiple-document interface (MDI) client window
        /// to restore an MDI child window from maximized or minimized size.
        /// </summary>
        WM_MDIRESTORE = 0x0223,

        /// <summary>
        /// An application sends the <see cref="WM_MDISETMENU"/> message to a multiple-document interface (MDI) client window
        /// to replace the entire menu of an MDI frame window, to replace the window menu of the frame window, or both.
        /// </summary>
        WM_MDISETMENU = 0x0230,

        /// <summary>
        /// An application sends the <see cref="WM_MDITILE"/> message to a multiple-document interface (MDI) client window
        /// to arrange all of its MDI child windows in a tile format.
        /// </summary>
        WM_MDITILE = 0x0226,

        #endregion

        #region Painting and Drawing Messages

        /// <summary>
        /// <para>
        /// The <see cref="WM_DISPLAYCHANGE"/> message is sent to all windows when the display resolution has changed.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/gdi/wm-displaychange
        /// </para>
        /// </summary>
        WM_DISPLAYCHANGE = 0x007E,

        /// <summary>
        /// <para>
        /// The <see cref="WM_NCPAINT"/> message is sent to a window when its frame must be painted.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/gdi/wm-ncpaint
        /// </para>
        /// </summary>
        WM_NCPAINT = 0x0085,

        /// <summary>
        /// <para>
        /// The <see cref="WM_PAINT"/> message is sent when the system or another application makes a request to
        /// paint a portion of an application's window.
        /// The message is sent when the <see cref="UpdateWindow"/> or <see cref="RedrawWindow"/> function is called,
        /// or by the <see cref="DispatchMessage"/> function when the application obtains a <see cref="WM_PAINT"/> message
        /// by using the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/gdi/wm-paint
        /// </para>
        /// </summary>
        WM_PAINT = 0x000F,

        /// <summary>
        /// <para>
        /// The <see cref="WM_PRINT"/> message is sent to a window to request that it draw itself in the specified device context,
        /// most commonly in a printer device context.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/gdi/wm-print
        /// </para>
        /// </summary>
        WM_PRINT = 0x0317,

        /// <summary>
        /// <para>
        /// The <see cref="WM_PRINTCLIENT"/> message is sent to a window to request that it draw its client area in the specified device context,
        /// most commonly in a printer device context.
        /// Unlike <see cref="WM_PRINT"/>, <see cref="WM_PRINTCLIENT"/> is not processed by <see cref="DefWindowProc"/>.
        /// A window should process the <see cref="WM_PRINTCLIENT"/> message through an application-defined WindowProc function
        /// for it to be used properly.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/gdi/wm-printclient
        /// </para>
        /// </summary>
        WM_PRINTCLIENT = 0x0318,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_SETREDRAW"/> message to a window to allow changes in that window
        /// to be redrawn or to prevent changes in that window from being redrawn.
        /// To send this message, call the <see cref="SendMessage"/> function with the following parameters.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/gdi/wm-setredraw
        /// </para>
        /// </summary>
        WM_SETREDRAW = 0x000B,

        /// <summary>
        /// <para>
        /// The <see cref="WM_SYNCPAINT"/> message is used to synchronize painting while avoiding linking independent GUI threads.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/gdi/wm-syncpaint
        /// </para>
        /// </summary>
        WM_SYNCPAINT = 0x0088,

        #endregion

        #region Power Management

        /// <summary>
        /// <para>
        /// Notifies applications that the system, typically a battery-powered personal computer, is about to enter a suspended mode.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/power/wm-power
        /// </para>
        /// </summary>
        WM_POWER = 0x0048,

        /// <summary>
        /// <para>
        /// Notifies applications that a power-management event has occurred.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/power/wm-powerbroadcast
        /// </para>
        /// </summary>
        WM_POWERBROADCAST = 0x0218,

        #endregion

        #region Raw Input Notifications

        /// <summary>
        /// Sent to the window that is getting raw input.
        /// </summary>
        WM_INPUT = 0x00FF,

        /// <summary>
        /// Sent to the window that registered to receive raw input.
        /// </summary>
        WM_INPUT_DEVICE_CHANGE = 0x00FE,

        #endregion

        #region Scroll Bar Notifications

        /// <summary>
        /// The <see cref="WM_CTLCOLORSCROLLBAR"/> message is sent to the parent window of a scroll bar control when the control is about to be drawn.
        /// By responding to this message, the parent window can use the display context handle to set the background color of the scroll bar control.
        /// </summary>
        WM_CTLCOLORSCROLLBAR = 0x0137,

        /// <summary>
        /// The <see cref="WM_HSCROLL"/> message is sent to a window when a scroll event occurs in the window's standard horizontal scroll bar.
        /// This message is also sent to the owner of a horizontal scroll bar control when a scroll event occurs in the control.
        /// </summary>
        WM_HSCROLL = 0x0114,

        /// <summary>
        /// The <see cref="WM_VSCROLL"/> message is sent to a window when a scroll event occurs in the window's standard vertical scroll bar.
        /// This message is also sent to the owner of a vertical scroll bar control when a scroll event occurs in the control.
        /// </summary>
        WM_VSCROLL = 0x0115,

        #endregion

        #region SystemParametersInfo Messages

        /// <summary>
        /// <para>
        /// A message that is sent to all top-level windows when the <see cref="SystemParametersInfo"/> function changes a system-wide setting
        /// or when policy settings have changed.
        /// Applications should send <see cref="WM_SETTINGCHANGE"/> to all top-level windows when they make changes to system parameters.
        /// (This message cannot be sent directly to a window.)
        /// To send the <see cref="WM_SETTINGCHANGE"/> message to all top-level windows,
        /// use the <see cref="SendMessageTimeout"/> function with the hwnd parameter set to <see cref="HWND_BROADCAST"/>.
        ///A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/winmsg/wm-settingchange
        /// </para>
        /// </summary>
        WM_SETTINGCHANGE = WM_WININICHANGE,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_WININICHANGE"/> message to all top-level windows after making a change to the WIN.INI file.
        /// The <see cref="SystemParametersInfo"/> function sends this message after an application uses the function to change a setting in WIN.INI.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/winmsg/wm-wininichange
        /// </para>
        /// </summary>
        /// <remarks>
        /// The <see cref="WM_WININICHANGE"/> message is provided only for compatibility with earlier versions of the system.
        /// Applications should use the <see cref="WM_SETTINGCHANGE"/> message.
        /// </remarks>
        WM_WININICHANGE = 0x001A,

        #endregion

        #region Timer Notifications

        /// <summary>
        /// Posted to the installing thread's message queue when a timer expires.
        /// The message is posted by the <see cref="GetMessage"/> or PeekMessage function.
        /// </summary>
        WM_TIMER = 0x0113,

        #endregion

        #region Window Messages

        /// <summary>
        /// Sent when the window background must be erased (for example, when a window is resized).
        /// The message is sent to prepare an invalidated portion of a window for painting.
        /// </summary>
        WM_ERASEBKGND = 0x0014,

        /// <summary>
        /// Retrieves the font with which the control is currently drawing its text.
        /// </summary>
        WM_GETFONT = 0x0031,

        /// <summary>
        /// Copies the text that corresponds to a window into a buffer provided by the caller.
        /// </summary>
        WM_GETTEXT = 0x000D,

        /// <summary>
        /// Determines the length, in characters, of the text associated with a window.
        /// </summary>
        WM_GETTEXTLENGTH = 0x000E,

        /// <summary>
        /// Sets the font that a control is to use when drawing text.
        /// </summary>
        WM_SETFONT = 0x0030,

        /// <summary>
        /// Associates a new large or small icon with a window.
        /// The system displays the large icon in the ALT+TAB dialog box, and the small icon in the window caption.
        /// </summary>
        WM_SETICON = 0x0080,

        /// <summary>
        /// Sets the text of a window.
        /// </summary>
        WM_SETTEXT = 0x000C,

        #endregion

        #region Window Notifications

        /// <summary>
        /// Sent when a window belonging to a different application than the active window is about to be activated.
        /// The message is sent to the application whose window is being activated and to the application whose window is being deactivated.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_ACTIVATEAPP = 0x001C,

        /// <summary>
        /// Sent to cancel certain modes, such as mouse capture.
        /// For example, the system sends this message to the active window when a dialog box or message box is displayed.
        /// Certain functions also send this message explicitly to the specified window regardless of whether it is the active window.
        /// For example, the EnableWindow function sends this message when disabling the specified window.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_CANCELMODE = 0x001F,

        /// <summary>
        /// Sent to a child window when the user clicks the window's title bar or when the window is activated, moved, or sized.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_CHILDACTIVATE = 0x0022,

        /// <summary>
        /// Sent as a signal that a window or an application should terminate.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_CLOSE = 0x0010,

        /// <summary>
        /// Sent to all top-level windows when the system detects more than 12.5 percent of system time over a 30- to 60-second interval
        /// is being spent compacting memory. This indicates that system memory is low.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_COMPACTING = 0x0041,

        /// <summary>
        /// Sent when an application requests that a window be created by calling 
        /// the <see cref="CreateWindowEx"/> or CreateWindow function.
        /// (The message is sent before the function returns.)
        /// The window procedure of the new window receives this message after the window is created, but before the window becomes visible.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_CREATE = 0x0001,

        /// <summary>
        /// Sent when a window is being destroyed. It is sent to the window procedure of the window being destroyed after the window
        /// is removed from the screen.
        /// This message is sent first to the window being destroyed and then to the child windows (if any) as they are destroyed.
        /// During the processing of the message, it can be assumed that all child windows still exist.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_DESTROY = 0x0002,

        /// <summary>
        /// Sent when an application changes the enabled state of a window. It is sent to the window whose enabled state is changing.
        /// This message is sent before the EnableWindow function returns,
        /// but after the enabled state (<see cref="WindowStyles.WS_DISABLED"/> style bit) of the window has changed.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_ENABLE = 0x000A,

        /// <summary>
        /// Sent one time to a window after it enters the moving or sizing modal loop.
        /// The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, 
        /// or when the window passes the WM_SYSCOMMAND message to the <see cref="DefWindowProc"/> function and 
        /// the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value.
        /// The operation is complete when <see cref="DefWindowProc"/> returns.
        /// The system sends the <see cref="WM_ENTERSIZEMOVE"/> message regardless of whether the dragging of full windows is enabled.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_ENTERSIZEMOVE = 0x0231,

        /// <summary>
        /// Sent one time to a window, after it has exited the moving or sizing modal loop.
        /// The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border,
        /// or when the window passes the WM_SYSCOMMAND message to the <see cref="DefWindowProc"/> function and 
        /// the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value.
        /// The operation is complete when DefWindowProc returns.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_EXITSIZEMOVE = 0x232,

        /// <summary>
        /// Sent to a window to retrieve a handle to the large or small icon associated with a window.
        /// The system displays the large icon in the ALT+TAB dialog, and the small icon in the window caption.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_GETICON = 0x007F,

        /// <summary>
        /// Sent to a window when the size or position of the window is about to change.
        /// An application can use this message to override the window's default maximized size and position, or its default minimum or maximum tracking size.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_GETMINMAXINFO = 0x0024,

        /// <summary>
        /// Sent to the topmost affected window after an application's input language has been changed.
        /// You should make any application-specific settings and pass the message to the <see cref="DefWindowProc"/> function,
        /// which passes the message to all first-level child windows.
        /// These child windows can pass the message to <see cref="DefWindowProc"/> to have it pass the message to their child windows, and so on.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_INPUTLANGCHANGE = 0x0051,

        /// <summary>
        /// Posted to the window with the focus when the user chooses a new input language,
        /// either with the hotkey (specified in the Keyboard control panel application) or from the indicator on the system taskbar.
        /// An application can accept the change by passing the message to the <see cref="DefWindowProc"/> function
        /// or reject the change (and prevent it from taking place) by returning immediately.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_INPUTLANGCHANGEREQUEST = 0x0050,

        /// <summary>
        /// Sent after a window has been moved.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_MOVE = 0x0003,

        /// <summary>
        /// Sent to a window that the user is moving.
        /// By processing this message, an application can monitor the position of the drag rectangle and, if needed, change its position.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_MOVING = 0x0216,

        /// <summary>
        /// Sent to a window when its nonclient area needs to be changed to indicate an active or inactive state.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_NCACTIVATE = 0x0086,

        /// <summary>
        /// Sent when the size and position of a window's client area must be calculated.
        /// By processing this message, an application can control the content of the window's client area
        /// when the size or position of the window changes.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_NCCALCSIZE = 0x0083,

        /// <summary>
        /// Sent prior to the <see cref="WM_CREATE"/> message when a window is first created.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_NCCREATE = 0x0081,

        /// <summary>
        /// Notifies a window that its nonclient area is being destroyed.
        /// The DestroyWindow function sends the <see cref="WM_NCDESTROY"/> message to the window following the <see cref="WM_DESTROY"/> message.
        /// <see cref="WM_DESTROY"/> is used to free the allocated memory object associated with the window.
        /// The <see cref="WM_NCDESTROY"/> message is sent after the child windows have been destroyed.
        /// In contrast, <see cref="WM_DESTROY"/> is sent before the child windows are destroyed.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_NCDESTROY = 0x0082,

        /// <summary>
        /// Performs no operation.
        /// An application sends the <see cref="WM_NULL"/> message if it wants to post a message that the recipient window will ignore.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_NULL = 0x0000,

        /// <summary>
        /// Sent to a minimized (iconic) window.
        /// The window is about to be dragged by the user but does not have an icon defined for its class.
        /// An application can return a handle to an icon or cursor. The system displays this cursor or icon while the user drags the icon.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_QUERYDRAGICON = 0x0037,

        /// <summary>
        /// Sent to an icon when the user requests that the window be restored to its previous size and position.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_QUERYOPEN = 0x0013,

        /// <summary>
        /// Indicates a request to terminate an application,
        /// and is generated when the application calls the <see cref="PostQuitMessage(int)"/> function.
        /// This message causes the <see cref="GetMessage"/> function to return zero.
        /// </summary>
        WM_QUIT = 0x0012,

        /// <summary>
        /// Sent to a window when the window is about to be hidden or shown.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_SHOWWINDOW = 0x0018,

        /// <summary>
        /// Sent to a window after its size has changed.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_SIZE = 0x0005,

        /// <summary>
        /// Sent to a window that the user is resizing.
        /// By processing this message, an application can monitor the size and position of the drag rectangle and,
        /// if needed, change its size or position.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_SIZING = 0x0214,

        /// <summary>
        /// Sent to a window after the <see cref="SetWindowLong"/> function has changed one or more of the window's styles.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_STYLECHANGED = 0x007D,

        /// <summary>
        /// Sent to a window when the <see cref="SetWindowLong"/> function is about to change one or more of the window's styles.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_STYLECHANGING = 0x007C,

        /// <summary>
        /// Broadcast to every window following a theme change event.
        /// Examples of theme change events are the activation of a theme, the deactivation of a theme, or a transition from one theme to another.
        /// </summary>
        WM_THEMECHANGED = 0x031A,

        /// <summary>
        /// Sent to all windows after the user has logged on or off.
        /// When the user logs on or off, the system updates the user-specific settings.
        /// The system sends this message immediately after updating the settings.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_USERCHANGED = 0x0054,

        /// <summary>
        /// Sent to a window whose size, position, or place in the Z order has changed
        /// as a result of a call to the <see cref="SetWindowPos"/> function or another window-management function.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_WINDOWPOSCHANGED = 0x0047,

        /// <summary>
        /// Sent to a window whose size, position, or place in the Z order is about to change
        /// as a result of a call to the <see cref="SetWindowPos"/> function
        /// or another window-management function.
        /// A window receives this message through its WindowProc function.
        /// </summary>
        WM_WINDOWPOSCHANGING = 0x0046,

        #endregion
    }
}

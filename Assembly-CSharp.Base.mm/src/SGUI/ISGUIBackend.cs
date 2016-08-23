﻿using System;
using UnityEngine;

namespace SGUI {
    /// <summary>
    /// A SGUI backend. Only use it in a valid context (when rendering)!
    /// </summary>
    public interface ISGUIBackend {

        /// <summary>
        /// The root that currently uses the backend to render.
        /// </summary>
        /// <value>The current root using the backend. Null when not rendering.</value>
        SGUIRoot CurrentRoot { get; }

        bool UpdateStyleOnRender { get; }

        /// <summary>
        /// Whether to use OnGUI (IMGUI) or not (GameObject-based / shadow hierarchy).
        /// </summary>
        /// <value><c>true</c> if the children of CurrentRoot should be rendered on and Start-/EndRender should get called in OnGUI.</value>
        bool RenderOnGUI { get; }

        float LineHeight { get; set; }

        void Init();

        bool Initialized { get; }

        void StartRender(SGUIRoot root);
        void EndRender(SGUIRoot root);

        int CurrentElementID { get; }
        int GetElementID(SElement elem);

        void Focus(SElement elem);
        void Focus(int id);
        bool IsFocused(SElement elem);
        bool IsFocused(int id);

        bool IsClicked(SElement elem);
        bool IsClicked(int id);

        void Rect(SElement elem, Vector2 position, Vector2 size, Color color);
        void Rect(Rect bounds, Color color);

        void StartClip(SElement elem);
        void StartClip(SElement elem, Rect bounds);
        void StartClip(Rect bounds);
        void EndClip();

        /// <summary>
        /// Render the specified text on screen.
        /// </summary>
        /// <param name="elem">Element instance. Null for root.</param>
        /// <param name="position">Relative position to render the text at.</param>
        /// <param name="text">Text to render.</param>
        void Text(SElement elem, Vector2 position, string text);
        /// <summary>
        /// Render the specified text on screen.
        /// </summary>
        /// <param name="elem">Element instance. Null for root.</param>
        /// <param name="bounds">Bounds to render the text in.</param>
        /// <param name="text">Text to render.</param>
        void Text(SElement elem, Rect bounds, string text);

        /// <summary>
        /// Render a text field on screen.
        /// </summary>
        /// <param name="elem">Element instance. Null for root.</param>
        /// <param name="position">Position.</param>
        /// <param name="size">Size.</param>
        /// <param name="text">Text.</param>
        /// <returns>Whether the element is focused or not.</returns>
        bool TextField(SElement elem, Vector2 position, Vector2 size, ref string text);
        /// <summary>
        /// Render a text field on screen.
        /// </summary>
        /// <param name="bounds">Bounds.</param>
        /// <param name="text">Text.</param>
        /// <returns>Whether the element is focused or not.</returns>
        bool TextField(Rect bounds, ref string text);

        bool Button(SElement elem, Vector2 position, Vector2 size, string text);
        bool Button(Rect bounds, string text);

        void StartGroup(SGroup group);
        void EndGroup(SGroup group);

        void Window(SGroup group);
        void StartWindow(SGroup group);
        void EndWindow(SGroup group);
        void WindowTitleBar(SWindowTitleBar bar);
        void UpdateWindows();
        bool UpdateWindow(SGroup group);

        /// <summary>
        /// Gets the size of the text.
        /// </summary>
        /// <returns>The size of the given text.</returns>
        /// <param name="text">The text to measure.</param>
        /// <param name="size">The bounds in which the text should fit in.</param>
        Vector2 MeasureText(string text, Vector2? size = null);

        // Text auto-generated by MonoDevelop. Nice! -- 0x0ade
        /// <summary>
        /// Releases all resource used by the <see cref="T:WTFGUI.IWTFGUIBackend"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose()"/> when you are finished using the <see cref="T:WTFGUI.IWTFGUIBackend"/>. The
        /// <see cref="Dispose()"/> method leaves the <see cref="T:WTFGUI.IWTFGUIBackend"/> in an unusable state. After
        /// calling <see cref="Dispose()"/>, you must release all references to the <see cref="T:WTFGUI.IWTFGUIBackend"/>
        /// so the garbage collector can reclaim the memory that the <see cref="T:WTFGUI.IWTFGUIBackend"/> was occupying.</remarks>
        void Dispose();

        /// <summary>
        /// Dispose the specified elem.
        /// </summary>
        /// <param name="elem">Element.</param>
        void Dispose(SElement elem);

    }
}

using Wavefunction_Collapse;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
namespace Wavefunction_Collapse

{
    static class KeyMouseReader
    {
        public static KeyboardState keyState, oldKeyState = Keyboard.GetState();
        public static MouseState mouseState, oldMouseState = Mouse.GetState();
        public static Rectangle MouseRectangle;
        public static bool KeyPressed(Keys key)
        {
            return keyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key);
        }

        public static bool KeyIsDown(Keys key)
        {
            return keyState.IsKeyDown(key);
        }

        public static bool LeftClick()
        {
            return mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released;
        }

        public static bool LeftPressed()
        {
            return mouseState.LeftButton == ButtonState.Pressed;
        }
        public static bool RightPressed()
        {
            return mouseState.RightButton == ButtonState.Pressed;
        }

        public static bool RightClick()
        {
            return mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released;
        }
        public static bool AnyKeyDown()
        {
            return keyState.GetPressedKeys().Length > 0;
        }

        //Should be called at beginning of Update in Game
        public static void Update()
        {
            oldKeyState = keyState;
            keyState = Keyboard.GetState();
            oldMouseState = mouseState;
            mouseState = Mouse.GetState();
            MouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 32, 32);

        }
    }
}
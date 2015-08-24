using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hero
{
    class InputManager
    {
        private KeyboardState currentKeyboardState, prevKeyboardState;

        private static InputManager instance;

        public static InputManager Instance 
        {
            get
            {
                if(instance==null)
                    instance=new InputManager();
                return instance;
            }
        }

        public void update(GameTime time)
        {
            prevKeyboardState = currentKeyboardState;
            if (!ScreenManager.Instance.isTransitioning)
                currentKeyboardState = Keyboard.GetState();
        }

        public bool keyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyboardState.IsKeyUp(key) && prevKeyboardState.IsKeyDown(key))
                    return true;
            }
            return false;
        }
        public bool keyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyboardState.IsKeyDown(key) && prevKeyboardState.IsKeyUp(key))
                    return true;
            }
            return false;
        }

        internal bool keyDown(Keys keys)
        {
            if (currentKeyboardState.IsKeyDown(keys))
                return true;
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;
using ValueEngine.Input;
using Tao.Sdl;
using Tao.OpenGl;

namespace VaueTest
{
    public class InputTestState : IGameObject
    {
        Input _input;

        public InputTestState()
        {
            _input = new Input();
        }

        public void DrawButtonPoint(bool held, int yPos)
        {
            if (held)
            {
                Gl.glColor3f(0, 1, 0);
            }
            else
            {
                Gl.glColor3f(1, 0, 0);
            }
            Gl.glVertex2f(-400, yPos);
        }


        #region IgameObject members

        public void Update(double elapsedTime)
        {
            _input.Update(elapsedTime);
        }

        public void Render()
        {
        }

        #endregion
    }
}

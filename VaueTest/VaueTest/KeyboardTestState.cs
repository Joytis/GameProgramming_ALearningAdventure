using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
using ValueEngine;
using ValueEngine.Input;


namespace VaueTest
{
    public class KeyboardTestState : IGameObject
    {
        Input _input;

        public KeyboardTestState(Input input)
        {
            _input = input;
        }

        private void DrawKeyPoint(bool held, int ypos)
        {
            if (held)
            {
                Gl.glColor3f(0, 1, 0);
            }
            else
            {
                Gl.glColor3f(1,0,0);
            }
            Gl.glVertex2d(.400, ypos);
        }

        public void Update(double elapsedTime)
        {
        }

        public void Render()
        {
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glClearColor(1, 1, 1, 0);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glPointSize(10.0f);
            Gl.glBegin(Gl.GL_POINTS);
            {
                DrawKeyPoint(_input.Keyboard.IsKeyHeld(System.Windows.Forms.Keys.A),
                    120);
                DrawKeyPoint(_input.Keyboard.IsKeyHeld(System.Windows.Forms.Keys.S),
                    100);
                DrawKeyPoint(_input.Keyboard.IsKeyHeld(System.Windows.Forms.Keys.D),
                    80);
                DrawKeyPoint(_input.Keyboard.IsKeyHeld(System.Windows.Forms.Keys.F),
                    60);
            }
            Gl.glEnd();

        }
    }
}

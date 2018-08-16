using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace HelloTriangle
{
    public class CircleIntersectionState:IGameObject
    {
        Circle _circle = new Circle(Vector.Zero, 200);
        Input _input = new Input();

        public CircleIntersectionState(Input input)
        {
            Gl.glLineWidth(3);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            _input = input;
        }


        #region IgameObject Members

        public void Update(double elapsedTime)
        {

            if (_circle.Intersects(_input.MousePosition))
            {
                _circle.Color = new Color(1, 0, 0, 1);
            }
            else
            {
                _circle.Color = new Color(1, 1, 1, 1);
            }

        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _circle.Draw();

            //Draw Mouse cursor at point
            Gl.glPointSize(5);
            Gl.glBegin(Gl.GL_POINTS);
            {
                Gl.glVertex2d(_input.MousePosition.X, _input.MousePosition.Y);
            }
            Gl.glEnd();
        }

        #endregion
    }
}

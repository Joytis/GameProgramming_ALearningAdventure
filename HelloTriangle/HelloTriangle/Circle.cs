using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace HelloTriangle
{
    public class Circle
    {
        Vector Position { get; set; }
        double Radius { get; set; }
        Color _color = new Color ( 1, 1, 1, 1 );

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Circle()
        {
            Position = Vector.Zero;
            Radius = 1;
        }

        public Circle(Vector position, double radius)
        {
            Position = position;
            Radius = radius;
        }

        public bool Intersects(Point interPoint)
        {
            Vector vPoint = new Vector(interPoint.X, interPoint.Y, 0);
            Vector distanceToPoint = Position - vPoint;
            double distance = distanceToPoint.Length();

            if (distance > Radius)
            {
                return false;
            }
            return true;
        }

        public void Draw()
        {
            int vertexAmount = 1000;
            double twoPI = 2.0 * Math.PI;

            Gl.glColor3f(_color.Red, _color.Green, _color.Blue);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            {
                for (int i = 0; i < vertexAmount; i++)
                {
                    double xPos = Position.X + Radius * Math.Cos(i * twoPI / vertexAmount);
                    double yPos = Position.Y + Radius * Math.Sin(i * twoPI / vertexAmount);

                    Gl.glVertex2d(xPos, yPos);

                }
            }
            Gl.glEnd();
        }
    }
}

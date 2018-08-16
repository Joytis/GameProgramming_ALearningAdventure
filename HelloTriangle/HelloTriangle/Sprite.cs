using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloTriangle
{
    public class Sprite
    {

        //Member variables
        double _scaleX = 1;
        double _scaleY = 1;
        double _rotation = 0;
        double _positionX = 0;
        double _positionY = 0;

        internal const int VertexAmount = 6;
        Vector[] _vertexPositions = new Vector[VertexAmount];
        Color[] _vertexColors = new Color[VertexAmount];
        Point[] _vertexUVs = new Point[VertexAmount];
        Texture _texture = new Texture();

        public Sprite()
        {
            InitVertexPositions(new Vector(0,0,0), 1, 1);
            SetColor(new Color(1, 1, 1, 1));
            SetUVs(new Point(0, 0), new Point(1, 1));
        }

        #region Sprite Accessors

        public Texture Texture
        {
            get { return _texture; }
            set
            {
                _texture = value;
                //By default width and height are set
                // to texture eidth and height
                InitVertexPositions(GetCenter(), _texture.Width, _texture.Height);
            }
        }

        public Vector[] VertexPositions
        {
            get { return _vertexPositions; }
        }

        public Color[] VertexColors
        {
            get { return _vertexColors; }
        }

        public Point[] VertexUVs
        {
            get { return _vertexUVs; }
        }


        #endregion

        //reutnr sprite width
        public double GetWidth()
        {
            //Top right minus top left
            return _vertexPositions[1].X - _vertexPositions[0].X;
        }


        //return sprite height
        public double GetHeight()
        {
            //Top left minus bottom left
            return _vertexPositions[0].Y - _vertexPositions[2].Y;
        }

        public Vector GetPosition()
        {
            return GetCenter();
        }

        //Returns position of sprite's center
        private Vector GetCenter()
        {
            double halfWidth = GetWidth()/2;
            double halfHeight = GetHeight() / 2;

            return new Vector(
                _vertexPositions[0].X + halfWidth,
                _vertexPositions[0].Y - halfHeight,
                _vertexPositions[0].Z);
        }

        //Changes sprite position
        private void InitVertexPositions(Vector position, double width, double height)
        {
            double halfWidth = width / 2;
            double halfHeight = height / 2;
            //Clockwise creation of 2 triangles to make a quad

            //Topleft, TopRight, BottomLeft
            _vertexPositions[0] = new Vector(position.X - halfWidth,
                position.Y + halfHeight, position.Z);
            _vertexPositions[1] = new Vector(position.X + halfWidth,
                position.Y + halfHeight, position.Z);
            _vertexPositions[2] = new Vector(position.X - halfWidth,
                position.Y - halfHeight, position.Z);

            //Topright, BottomRight, BottomLeft
            _vertexPositions[3] = new Vector(position.X + halfWidth,
                position.Y + halfHeight, position.Z);
            _vertexPositions[4] = new Vector(position.X + halfWidth,
                position.Y - halfHeight, position.Z);
            _vertexPositions[5] = new Vector(position.X - halfWidth,
                position.Y - halfHeight, position.Z);
        }

        //Sets width of sprite
        public void SetWidth(float width)
        {
            InitVertexPositions(GetCenter(), width, GetHeight());
        }

        //Sets height of sprite
        public void SetHeight(float height)
        {
            InitVertexPositions(GetCenter(), GetWidth(), height);
        }

        //Sets position with X and Y arguments
        public void SetPosition(double x, double y)
        {
            SetPosition(new Vector(x, y, 0));
        }

        //Sets position to given vector
        public void SetPosition(Vector position)
        {
            Matrix m = new Matrix();
            m.SetTranslation(new Vector(_positionX, _positionY, 0));
            ApplyMatrix(m.Inverse());
            m.SetTranslation(position);
            ApplyMatrix(m);
            _positionX = position.X;
            _positionY = position.Y;
        }


        //Sets Color of Sprite
        public void SetColor(Color color)
        {
            for (int i = 0; i < VertexAmount; i++)
            {
                _vertexColors[i] = color;
            }
        }

        //sets image scale
        public void SetScale(double x, double y)
        {
            double oldX = _positionX;
            double oldY = _positionY;
            SetPosition(0, 0);
            Matrix mScale = new Matrix();
            mScale.SetScale(new Vector(_scaleX, _scaleY, 1));
            mScale = mScale.Inverse();
            ApplyMatrix(mScale);
            mScale = new Matrix();
            mScale.SetScale(new Vector(x, y, 1));
            ApplyMatrix(mScale);
            SetPosition(oldX, oldY);
            _scaleX = x;
            _scaleY = y;
        }

        public void SetRotation(double rotation)
        {
            double oldX = _positionX;
            double oldY = _positionY;
            SetPosition(0,0);
            Matrix mRot = new Matrix();
            mRot.SetRotate(new Vector(0, 0, 1), _rotation);
            ApplyMatrix(mRot.Inverse());
            mRot = new Matrix();
            mRot.SetRotate(new Vector(0, 0, 1), rotation);
            ApplyMatrix(mRot);
            SetPosition(oldX, oldY);
            _rotation = rotation;
        }

        //Sets UV values for sprite
        public  void SetUVs(Point topLeft, Point bottomRight)
        {
            //TopLeft TopRight BottomLeft
            _vertexUVs[0] = topLeft;
            _vertexUVs[1] = new Point(bottomRight.X, topLeft.Y);
            _vertexUVs[2] = new Point(topLeft.X, bottomRight.Y);

            //TopRight BottomRight BottomLeft
            _vertexUVs[3] = new Point(bottomRight.X, topLeft.Y);
            _vertexUVs[4] = bottomRight;
            _vertexUVs[5] = new Point(topLeft.X, bottomRight.Y);

        }

        public void ApplyMatrix(Matrix m)
        {
            for (int i = 0; i < VertexPositions.Length; i++)
            {
                VertexPositions[i] *= m;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace HelloTriangle
{
    class MatrixTestState : IGameObject
    {
        Sprite _faceSprite = new Sprite();
        Renderer _renderer = new Renderer();
        Matrix m = new Matrix();
        Matrix mScale = new Matrix();

        public MatrixTestState(TextureManager textureManager)
        {
            _faceSprite.Texture = textureManager.Get("face");

            m.SetRotate(new Vector(0, 0, 1), Math.PI / 5);
            mScale.SetScale(new Vector(2.0, 2.0, 0.0));

            m *= mScale;

            for (int i = 0; i < _faceSprite.VertexPositions.Length; i++)
            {
                _faceSprite.VertexPositions[i] *= m;
            }

            Gl.glEnable(Gl.GL_TEXTURE_2D);

        }



        #region IGameObject Members

        public void Update(double elapsedTime)
        {
        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawSprite(_faceSprite);
            _renderer.Render();
        }

        #endregion
    }
}

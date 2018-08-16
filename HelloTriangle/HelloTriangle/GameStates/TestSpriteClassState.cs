using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace HelloTriangle
{
    class TestSpriteClassState:IGameObject
    {
        double something;
        Renderer _renderer = new Renderer();
        TextureManager _textureManager = new TextureManager();
        Sprite _testSprite = new Sprite();
        Sprite _testSprite2 = new Sprite();

        public TestSpriteClassState(TextureManager textureManager)
        {
            something = 0;

            // TODO: Complete member initialization
            _textureManager = textureManager;
            _testSprite.Texture = _textureManager.Get("face_alpha");
            _testSprite.SetHeight(256 * 0.5f);

            _testSprite2.Texture = _textureManager.Get("face_alpha");
            _testSprite2.SetPosition(-256, -256);
            _testSprite2.SetColor(new Color(1, 0, 0, 1));

        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawSprite(_testSprite);
            _renderer.DrawSprite(_testSprite2);
            Gl.glFinish();
        }

        public void Update(double elapsedTime)
        {
            something += elapsedTime;
            _testSprite.SetHeight((float)_testSprite.GetHeight() + 1.5f);
            _testSprite2.SetPosition(new Vector(Math.Sin((Math.PI * (something*3)))*100, 256, 0));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace HelloTriangle
{
    class TextRenderState:IGameObject
    {
        TextureManager _textureManager;
        Font _font;
        Text _text;
        Renderer _renderer = new Renderer();

        public TextRenderState(TextureManager textureManager)
        {
            _textureManager = textureManager;
            _font = new Font(textureManager.Get("font"), 
                FontParser.Parse("font.fnt"));
            _text = new Text("Hello", _font);

        }

        #region IGameObject members
        public void Update(double elapsedTime)
        {
        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawText(_text);
        }
        #endregion 
    }
}

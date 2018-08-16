using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace HelloTriangle
{
    class FPSTestState:IGameObject
    {
        TextureManager _textureManager;
        Text _fpsText;
        Font _font;
        Renderer _renderer = new Renderer();
        FramesPerSecond _fps = new FramesPerSecond();

        public FPSTestState(TextureManager textureManager)
        {
            _textureManager = textureManager;
            _font = new Font(textureManager.Get("font"), 
                FontParser.Parse("font.fnt"));
            _fpsText = new Text("FPS: ", _font);
        }
        

        public void Update(double elapsedTime)
        {
            _fps.Process(elapsedTime);
        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _fpsText = new Text("FPS: " + _fps.CurrentFPS.ToString("00.0"), _font);
            for(int i = 0; i < 3333; i++)
            {
                _renderer.DrawText(_fpsText);
            }
            _renderer.Render();
        }
    }
}

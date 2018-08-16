using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;
using ValueEngine.Input;
using Tao.OpenGl;

namespace ValueEmblem
{
    class InnerGameplayState:IGameObject
    {
        PersistantGameData _gameData;
        Renderer _renderer;
        Input _input;
        FontManager _fontManager;
        TextureManager _textureManager;
        StateSystem _innerStateSystem;
        

        public InnerGameplayState(
            Input input,
            FontManager fontManager,
            TextureManager textureManager,
            StateSystem innerStateSystem,
            PersistantGameData  gameData,
            Renderer renderer)
        {
            _input = input;
            _fontManager = fontManager;
            _textureManager = textureManager;
            _innerStateSystem = innerStateSystem;
            _gameData = gameData;
            _renderer = new Renderer();
        }


        private void CheckForPaused()
        {
            if(_input.Controller.ButtonStart.Pressed ||
                _input.Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Enter))
            {
                _innerStateSystem.ChangeState("paused");
            }
        }

        public void Update(double elapsedTime)
        {
            CheckForPaused();
        }

        public void Render()
        {
            Gl.glClearColor(0, 0, 0, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            _gameData.CurrentLevel.Render(_renderer);

            _renderer.Render();
        }
    }
}

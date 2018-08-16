using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;
using ValueEngine.Input;
using Tao.OpenGl;

namespace ValueShmup
{
    class InnerGameState :IGameObject
    {
        Level               _level;
        Renderer            _renderer = new Renderer();
        Input               _input;
        StateSystem         _system;
        PersistantGameData  _gameData;
        FontManager         _fontManager;
        TextureManager      _textureManager;

        double              _gameTime;

        public InnerGameState(StateSystem system,
            Input input,
            PersistantGameData gameData,
            FontManager fontManager,
            TextureManager textureManager)
        {
            _system = system;
            _input = input;
            _gameData = gameData;
            _fontManager = fontManager;
            _textureManager = textureManager;
            OnGameStart();
        }

        public void OnGameStart()
        {
            _gameTime = _gameData.CurrentLevel.Time;
            _level = new Level(_input, _textureManager, _gameData);
        }


        #region IGameObject Members

        public void Update(double elapsedTime)
        {
            _level.Update(elapsedTime);

            _gameTime -= elapsedTime;

            if (_gameTime <= 0)
            {
                OnGameStart();
                _gameData.JustWon = true;
                _system.ChangeState("game_over");
            }
        }

        public void Render()
        {
            Gl.glClearColor(1, 0, 1, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _level.Render(_renderer);
            _renderer.Render();
        }

        #endregion

    }
}

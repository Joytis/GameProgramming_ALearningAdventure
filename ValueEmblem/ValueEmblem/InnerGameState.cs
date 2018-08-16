using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;
using ValueEngine.Input;
using Tao.OpenGl;

namespace ValueEmblem
{
    class InnerGameState:IGameObject
    {
        PersistantGameData  _gameData;
        StateSystem         _system;
        StateSystem         _innerStateSystem = new StateSystem();
        TextureManager      _textureManager;
        Input               _input;
        FontManager         _fontManager;
        Renderer            _renderer;

        public InnerGameState(Input input,
            StateSystem         system,
            TextureManager      textureManager,
            FontManager         fontManager,
            PersistantGameData  gameData)
        {
            _gameData = gameData;
            _input = input;
            _system = system;
            _textureManager = textureManager;
            _fontManager = fontManager;
            _renderer = new Renderer();

            InitializeInnerStateSystem();

        }

        public void InitializeInnerStateSystem()
        {
            _innerStateSystem.AddState("paused", new InnerMenuState(
                _input, 
                _fontManager, 
                _innerStateSystem));

            _innerStateSystem.AddState("unpaused", new InnerGameplayState(
                _input,
                _fontManager,
                _textureManager,
                _innerStateSystem,
                _gameData,
                _renderer));

            _innerStateSystem.ChangeState("unpaused");
        }

        public void Update(double elapsedTime)
        {
            _innerStateSystem.Update(elapsedTime);
        }

        public void Render()
        {
            _innerStateSystem.Render();

            _renderer.Render();
        }
    }
}

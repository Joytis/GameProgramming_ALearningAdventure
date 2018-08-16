using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;
using ValueEngine.Input;
using System.Windows.Forms;
using System.Drawing;

namespace ValueShmup
{
    class Level
    {
        Input _input;
        PersistantGameData _gameData;
        PlayerCharacter _playerCharacter;
        TextureManager _textureManager;
        ScrollingBackground _background;
        ScrollingBackground _backgroundLayer;

        public Level(Input input, TextureManager textureManager,
            PersistantGameData gameData)
        {
            _input = input;
            _gameData = gameData;
            _textureManager = textureManager;

            _background = new ScrollingBackground(textureManager.Get("background"));
            _background.SetScale(2, 2);
            _background.Speed = 0.15f;

            _backgroundLayer = new ScrollingBackground(textureManager.Get("background_layer_1"));
            _backgroundLayer.Speed = 0.1f;
            _backgroundLayer.SetScale(2.0, 2.0);

            _playerCharacter = new PlayerCharacter(_textureManager);


        }

        public void Update(double elapsedTime)
        {
            //Get controls and apply to character
            double _x = _input.Controller.LeftControlStick.X;
            double _y = _input.Controller.LeftControlStick.Y * -1;
            Vector controlInput = new Vector(_x, _y, 0);

            if (Math.Abs(controlInput.Length()) < 0.0001)
            {

                if (_input.Keyboard.IsKeyHeld(Keys.Right)
                    && _input.Keyboard.IsKeyHeld(Keys.Left))
                {
                    controlInput.X = 0;
                }
                else if (_input.Keyboard.IsKeyHeld(Keys.Left))
                {
                    controlInput.X = -1;
                }
                else if (_input.Keyboard.IsKeyHeld(Keys.Right))
                {
                    controlInput.X = 1;
                }

                if (_input.Keyboard.IsKeyHeld(Keys.Down)
                    && _input.Keyboard.IsKeyHeld(Keys.Up))
                {
                    controlInput.Y = 0;
                }
                else if (_input.Keyboard.IsKeyHeld(Keys.Up))
                {
                    controlInput.Y = 1;
                }
                else if (_input.Keyboard.IsKeyHeld(Keys.Down))
                {
                    controlInput.Y = -1;
                }
            }
            _playerCharacter.Move(controlInput * elapsedTime);

            _background.Update((float)elapsedTime);
            _backgroundLayer.Update((float)elapsedTime);

        }

        public void Render(Renderer renderer)
        {
            _background.Render(renderer);
            _backgroundLayer.Render(renderer);
            _playerCharacter.Render(renderer);
        }
    }
}

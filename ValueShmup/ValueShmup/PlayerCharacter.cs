using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;
using ValueEngine.Input;

namespace ValueShmup
{
    class PlayerCharacter
    {
        Sprite _spaceship = new Sprite();

        double _speed = 512;

        public PlayerCharacter(TextureManager textureManager)
        {
            _spaceship.Texture = textureManager.Get("player_ship");
            _spaceship.SetScale(0.5, 0.5); // Spaceship is big. Scale it down
        }

        public void Move(Vector amount)
        {
            amount *= _speed;
            _spaceship.SetPosition(_spaceship.GetPosition() + amount);
        }

        public void Render(Renderer renderer)
        {
            renderer.DrawSprite(_spaceship);
        }
    }
}

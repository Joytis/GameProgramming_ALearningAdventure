using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;

namespace ValueEmblem
{
    public class GameBoardBackground
    {
        Sprite _boardSprite;

        public GameBoardBackground(Texture boardTex)
        {
            _boardSprite = new Sprite();
            _boardSprite.Texture = boardTex;
        }

        public void Render(Renderer renderer)
        {
            renderer.DrawSprite(_boardSprite);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;

namespace ValueEmblem
{
    public class Level
    {
        GameBoardBackground _levelBoard;

        public Level(Texture backgroundTex)
        {
            _levelBoard = new GameBoardBackground(backgroundTex);
        }

        public void Render(Renderer renderer)
        {
            _levelBoard.Render(renderer);
        }

    }
}

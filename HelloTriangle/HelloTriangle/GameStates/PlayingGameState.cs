using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloTriangle
{
    class PlayingGameState:IGameObject
    {
        StateSystem _system;
        public PlayingGameState(StateSystem system)
        {
            _system = system;

        }
        

        #region IGameObject Members

        public void Update(double elapsedTime)
        {
            System.Console.WriteLine("Updating Game");
        }

        public void Render()
        {
            System.Console.WriteLine("Rendering Game");
        }

        #endregion
    }
}

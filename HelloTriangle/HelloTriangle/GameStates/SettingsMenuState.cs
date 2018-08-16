using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloTriangle
{
    class SettingsMenuState:IGameObject
    {

        StateSystem _system;
        public SettingsMenuState(StateSystem system)
        {
            _system = system;

        }

        #region IGameObject Members

        public void Update(double elapsedTime)
        {
            System.Console.WriteLine("Updating Settings Menu");
        }

        public void Render()
        {
            System.Console.WriteLine("Rendering Settings Menu");
        }

        #endregion

    }
}

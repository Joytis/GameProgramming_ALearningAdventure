using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloTriangle
{
    interface IGameObject
    {
        void Update(double elapsedTime);
        void Render();
    }
}

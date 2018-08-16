using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
using System.Runtime.InteropServices;

namespace HelloTriangle
{
    public class Renderer
    {
        Batch _batch = new Batch();

        public Renderer()
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
        }

        public void DrawImmediateModeVertex(Vector position, Color color, Point uvs)
        {
            Gl.glColor4d(color.Red, color.Green, color.Blue, color.Alpha);
            Gl.glTexCoord2d(uvs.X, uvs.Y);
            Gl.glVertex3d(position.X, position.Y, position.Z);
        }

        public void DrawSprite(Sprite sprite)
        {
            _batch.AddSprite(sprite);
        }

        public void Render()
        {
            _batch.Draw();
        }

        internal void DrawText(Text _text)
        {
            foreach (CharacterSprite c in _text.CharacterSprites)
            {
                DrawSprite(c.Sprite);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace HelloTriangle
{
    class DrawSpriteState:IGameObject
    {
        TextureManager _textureManager;

        double height;
        double width;
        double halfHeight;
        double halfWidth;
        double x;
        double y;
        double z;

        public DrawSpriteState(TextureManager _text)
        {
            _textureManager = _text;
            height = 200;
            width = 200;
            halfHeight = height / 2;
            halfWidth = width / 2;
            x = 0;
            y = 0;
            z = 0;

        }

        #region IGameObject Member Functions

        public void Update(double elapsedTime)
        {
            
        }

        public void Render()
        {
            
            Texture texture = _textureManager.Get("face_alpha");
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture.Id);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

            float topUV = 0;
            float bottomUV = 1;
            float leftUV = 0;
            float rightUV = 1;

            float red = 1;
            float green = 0;
            float blue = 0;
            float alpha = 1;

            Gl.glBegin(Gl.GL_TRIANGLES);
            {
                Gl.glColor4d(red, green, blue, alpha);

                Gl.glTexCoord2d(leftUV, topUV);
                Gl.glVertex3d(x - halfWidth, y + halfHeight, z);
                Gl.glTexCoord2d(rightUV, topUV);
                Gl.glVertex3d(x + halfWidth, y + halfHeight, z);
                Gl.glTexCoord2d(leftUV, bottomUV);
                Gl.glVertex3d(x - halfWidth, y - halfHeight, 0);

                Gl.glTexCoord2d(rightUV, topUV);
                Gl.glVertex3d(x + halfWidth, y + halfHeight, z);
                Gl.glTexCoord2d(bottomUV, rightUV);
                Gl.glVertex3d(x + halfWidth, y - halfHeight, z);
                Gl.glTexCoord2d(leftUV, bottomUV);
                Gl.glVertex3d(x - halfWidth, y - halfHeight, 0);
            }
            Gl.glEnd(); 
            
        }

        #endregion
    }
}

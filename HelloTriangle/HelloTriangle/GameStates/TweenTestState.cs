using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace HelloTriangle
{
    public class TweenTestState:IGameObject
    {

        Tween _tween = new Tween(0, 256, 5);
        Tween _tween2 = new Tween(0, 256, 5, Tween.EaseInExpo);
        Tween _alphaTween = new Tween(0, 1, 5, Tween.EaseInCirc);
        Color _color = new Color(1,1,1,0);
        Sprite _faceSprite = new Sprite();
        Renderer _renderer = new Renderer();

        public TweenTestState(TextureManager textureManager)
        {
            _faceSprite.Texture = textureManager.Get("face");
            _faceSprite.SetHeight(0);
            _faceSprite.SetWidth(0);
        }

        public void Process(double elapsedTime)
        {
            if(_tween.IsFinished() != true)
            {
                _tween.Update(elapsedTime);
                _faceSprite.SetWidth((float)_tween.Value());
                _faceSprite.SetHeight((float)_tween.Value());
            }

            if(_alphaTween.IsFinished() != true)
            {
                _alphaTween.Update(elapsedTime);
                _color.Alpha = (float)_alphaTween.Value();
                _faceSprite.SetColor(_color);
            }
        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawSprite(_faceSprite);
            _renderer.Render();
        }

        public void Update(double elapsedTime)
        {
            if(_tween2.IsFinished() != true)
            {
                _tween2.Update(elapsedTime);
                _faceSprite.SetWidth((float)_tween2.Value());
                _faceSprite.SetHeight((float)_tween2.Value());
            }
        }

    }
}

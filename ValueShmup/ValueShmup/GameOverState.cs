using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;
using ValueEngine.Input;
using Tao.OpenGl;

namespace ValueShmup
{
    class GameOverState : IGameObject
    {
        const double        _timeOut = 4;
        double              _countDown          = _timeOut;

        StateSystem         _system;
        Input               _input;
        FontManager         _fontManager;
        PersistantGameData  _gameData;
        Renderer            _renderer           = new Renderer();

        Text _titleWin;
        Text _blurbWin;

        Text _titleLose;
        Text _blurbLose;

        public GameOverState(PersistantGameData data, StateSystem system,
            Input input, FontManager fontManager)
        {
            _gameData = data;
            _system = system;
            _input = input;
            _fontManager = fontManager;

            _titleWin = new Text("Complete!", _fontManager.Get("title_font"));
            _blurbWin = new Text("Congradulations, you won!", _fontManager.Get("general_font"));
            _titleLose = new Text("Game Over!", _fontManager.Get("title_font"));
            _blurbLose = new Text("Please try again...", _fontManager.Get("general_font"));

            FormatText(_titleWin, 300);
            FormatText(_blurbWin, 200);

            FormatText(_titleLose, 300);
            FormatText(_blurbLose, 200);
        }

        private void FormatText(Text _text, int yPosition)
        {
            _text.SetPosition(-_text.Width / 2, yPosition);
            _text.SetColor(new Color(0, 0, 0, 1));
        }

        private void Finish()
        {
            _gameData.JustWon = false;
            _system.ChangeState("start_menu");
            _countDown = _timeOut;
        }


        #region IgameObject members

        public void Update(double elapsedTime)
        {
            _countDown -= elapsedTime;

            if (_countDown <= 0 ||
                _input.Controller.ButtonA.Pressed ||
                _input.Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Enter))
            {
                Finish();
            }

        }

        public void Render()
        {
            Gl.glClearColor(1, 1, 1, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            if (_gameData.JustWon)
            {
                _renderer.DrawText(_titleWin);
                _renderer.DrawText(_blurbWin);
            }
            else
            {
                _renderer.DrawText(_titleLose);
                _renderer.DrawText(_blurbLose);
            }
            _renderer.Render();
        }

        #endregion
    }
}

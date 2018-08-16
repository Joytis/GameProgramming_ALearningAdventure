using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
using ValueEngine;
using ValueEngine.Input;

namespace ValueShmup
{
    class StartMenuState : IGameObject
    {
        Renderer            _renderer       = new Renderer();
        FontManager         _fontManager    = new FontManager();
        Text                _title;
        Input               _input;
        VerticalMenu        _menu;
        StateSystem         _system;
            

        public StartMenuState(FontManager fontManager, Input input, StateSystem system)
        {
            _input = input;
            _fontManager = fontManager;
            _system = system;

            _title = new Text("Value Shmup", _fontManager.Get("title_font"));
            _title.SetColor(new Color(0, 0, 0, 1));

            //Center on the x and place somewhere near the top
            _title.SetPosition(-_title.Width / 2, 300);
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            _menu = new VerticalMenu(0, 150, _input);
            Button startGame = new Button(
                delegate(object o, EventArgs e)
                {
                    _system.ChangeState("inner_game");
                },
                new Text("Start", _fontManager.Get("general_font")));

            Button exitGame = new Button(
                delegate(object o, EventArgs e)
                {
                    //Quit
                    System.Windows.Forms.Application.Exit();
                },
                new Text("Exit", _fontManager.Get("general_font")));

            _menu.AddButton(startGame);
            _menu.AddButton(exitGame);
        }


        public void Update(double elapsedTime)
        {
            _menu.HandleInput();
        }

        public void Render()
        {
            Gl.glClearColor(1, 1, 1, 0);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawText(_title);
            _menu.Render(_renderer);
            _renderer.Render();
        }
    }
}

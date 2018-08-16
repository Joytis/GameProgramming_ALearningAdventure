using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;
using ValueEngine.Input;
using Tao.OpenGl;

namespace ValueEmblem
{
    class MainMenuState: IGameObject
    {
        Renderer            _renderer = new Renderer();
        VerticalMenu        _vmenu;
        Input               _input;
        Text                _title;
        FontManager         _fontManager;
        StateSystem         _system;

        public MainMenuState(Input input, FontManager fontManager, StateSystem system)
        {
            _input = input;
            _fontManager = fontManager;
            _system = system;

            _title = new Text("Value Emblem", fontManager.Get("title_font"));
            _title.SetColor(new Color(0, 0, 0, 1));

            _title.SetPosition(-_title.Width / 2, 300);
            InitializeVMenu();
        }

        private void InitializeVMenu()
        {
            _vmenu = new VerticalMenu(0, 150, _input);
            Button startGame= new Button(
                    delegate(object o, EventArgs e)
                    {
                        _system.ChangeState("inner_game_state");
                    }, 
                    new Text("Start", _fontManager.Get("general_font")));

            Button exitGame = new Button(
                delegate(object o, EventArgs e)
                {
                    System.Windows.Forms.Application.Exit();
                },
                new Text("Exit", _fontManager.Get("general_font")));

            _vmenu.AddButton(startGame);
            _vmenu.AddButton(exitGame);
        }

        public void Update(double elapsedTime)
        {
            _vmenu.HandleInput();
        }

        public void Render()
        {
            Gl.glClearColor(1, 1, 1, 0);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawText(_title);
            _vmenu.Render(_renderer);
            _renderer.Render();
        }
    }
}

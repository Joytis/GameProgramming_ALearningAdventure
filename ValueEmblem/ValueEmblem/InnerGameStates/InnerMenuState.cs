using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;
using ValueEngine.Input;
using Tao.OpenGl;

namespace ValueEmblem
{
    class InnerMenuState:IGameObject
    {
        Renderer _renderer = new Renderer();
        VerticalMenu _vmenu;
        Input _input;
        Text _title;
        FontManager _fontManager;
        StateSystem _system;

        public InnerMenuState(Input input, FontManager fontManager, StateSystem system)
        {
            _input = input;
            _fontManager = fontManager;
            _system = system;

            _title = new Text("Paused", fontManager.Get("general_font"));
            _title.SetColor(new Color(0, 0, 0, 1));

            _title.SetPosition(-_title.Width / 2, 300);

            _vmenu = new VerticalMenu(0, 150, _input);
            InitializeVerticalMenu();
        }

        public void InitializeVerticalMenu()
        {

            Button resumeGame = new Button(
                delegate(object o, EventArgs e)
                {
                    _system.ChangeState("unpaused");
                },
                new Text("Resume", _fontManager.Get("general_font")));

            _vmenu.AddButton(resumeGame);

        }


        public void Update(double elapsedTime)
        {
            _vmenu.HandleInput();
        }

        public void Render()
        {
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            _vmenu.Render(_renderer);
            _renderer.DrawText(_title);
            _renderer.Render();
        }
    }
}

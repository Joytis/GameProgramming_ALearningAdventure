using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ValueEngine;
using ValueEngine.Input;
using Tao.DevIl;
using Tao.OpenGl;

namespace VaueTest
{
    public partial class Form1 : Form
    {
        bool            _fullscreen         = false;
        FastLoop        _fastLoop;
        StateSystem     _system             = new StateSystem();
        Input           _input              = new Input();
        TextureManager  _textureManager     = new TextureManager();
        SoundManager    _soundManager       = new SoundManager();

        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
            _input.Mouse = new Mouse(this, simpleOpenGlControl1);
            _input.Keyboard = new Keyboard(simpleOpenGlControl1);

            InitializeDisplay();
            InitializeSounds();
            InitializeTextures();
            InitializeGameState();

            _fastLoop = new FastLoop(GameLoop);
        }

        private void InitializeGameState()
        {
            //Load Game States
            _system.AddState("sound_test_state", new SoundTestState(_soundManager));
            _system.AddState("input_test_state", new InputTestState());
            _system.AddState("mouse_test_state", new MouseTestState(_input));
            _system.AddState("keyboard_test_state", new KeyboardTestState(_input));

            _system.ChangeState("keyboard_test_state");

        }

        private void InitializeTextures()
        {
            //Init DevIl
            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);

            //Load textures here using texture Manager
        }

        private void InitializeDisplay()
        {
            if (_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }

            else
            {
                ClientSize = new Size(1280, 720);
            }
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
        }

        private void InitializeSounds()
        {
            _soundManager.LoadSound("effect", "soundEffect1.wav");
            _soundManager.LoadSound("effect2", "soundEffect2.wav");
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Gl.glViewport(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
        }

        private void Setup2DGraphics(double width, double hieght)
        {
            double halfWidth = width / 2;
            double halfHeight = Height / 2;
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

        }

        private void UpdateInput(double elapsedTime)
        {
            _input.Update(elapsedTime);
        }

        private void GameLoop(double elapsedTime)
        {

            //Update
            UpdateInput(elapsedTime);
            _system.Update(elapsedTime);

            //Render
            _system.Render();
            simpleOpenGlControl1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

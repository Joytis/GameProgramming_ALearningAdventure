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


namespace ValueShmup
{
    public partial class Form1 : Form
    {

        bool                _fullscreen         = false;
        FastLoop            _fastLoop;
        StateSystem         _system             = new StateSystem();
        Input               _input              = new Input();
        TextureManager      _textureManager     = new TextureManager();
        SoundManager        _soundManager       = new SoundManager();
        FontManager         _fontManager        = new FontManager();
        PersistantGameData  _persistantGameData = new PersistantGameData();


        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();

            _input.Mouse = new Mouse(this, simpleOpenGlControl1);
            _input.Keyboard = new Keyboard(simpleOpenGlControl1);

            InitializeDisplay();
            InitializeSounds();
            InitializeTextures();
            InitializeGameData();
            InitializeFonts();
            InitializeGameState();

            _fastLoop = new FastLoop(GameLoop);
        }

        private void InitializeFonts()
        {
            //Fonts are loaded here
            _fontManager.LoadFont("general_font",
                new ValueEngine.Font(_textureManager.Get("general_font"),
                    FontParser.Parse("Assets/Fonts/general_font.fnt")));


           _fontManager.LoadFont("title_font",
               new ValueEngine.Font(_textureManager.Get("title_font"),
                    FontParser.Parse("Assets/Fonts/title_font.fnt")));

        }

        private void InitializeSounds()
        {
            //sounds are loaded here
        }

        private void InitializeGameState()
        {
            //Game states loaded here
            _system.AddState("start_menu", new StartMenuState(_fontManager, _input, _system));
            _system.AddState("inner_game", new InnerGameState(_system, _input, _persistantGameData, _fontManager, _textureManager));
            _system.AddState("game_over", new GameOverState(_persistantGameData, _system, _input, _fontManager));
            

            _system.ChangeState("start_menu");

        }

        private void InitializeGameData()
        {
            LevelDescription level = new LevelDescription();
            level.Time = 5;
            _persistantGameData.CurrentLevel = level;
        }

        private void InitializeTextures()
        {
            //Init DevIl
            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);

            //Textures Loaded here
            _textureManager.LoadTexture("title_font", "Assets/Fonts/title_font.tga");
            _textureManager.LoadTexture("general_font", "Assets/Fonts/general_font.tga");
            _textureManager.LoadTexture("player_ship", "Assets/Textures/spaceship.tga");
            _textureManager.LoadTexture("background", "Assets/Backgrounds/background.tga");
            _textureManager.LoadTexture("background_layer_1", "Assets/Backgrounds/background_p.tga");
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

        private void UpdateInput(double elapsedTime)
        {
            _input.Update(elapsedTime);
        }

        private void GameLoop(double elapsedTime)
        {
            //update
            UpdateInput(elapsedTime);

            //Process
            _system.Update(elapsedTime);

            //Render
            _system.Render();
            simpleOpenGlControl1.Refresh();
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Gl.glViewport(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
        }

        private void Setup2DGraphics(double width, double height)
        {
            double halfWidth = width / 2;
            double halfHeight = height / 2;
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

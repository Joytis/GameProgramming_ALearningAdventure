using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.DevIl;

namespace HelloTriangle
{


    public partial class Form1 : Form
    {
        //initialize fastLoop
        FastLoop _fastLoop;
        bool _fullscreen = false;
        StateSystem _system = new StateSystem();
        TextureManager _textureManager = new TextureManager();
        Input _input = new Input();

        public Form1() 
        {
            
            //initialize windows stuff
            InitializeComponent();

            //initialize OpenGL
            _openGLControl.InitializeContexts();

            //Initialize DevIl
            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);

            //Load Textures
            _textureManager.LoadTexture("face", "face_alpha.tif");
            _textureManager.LoadTexture("face_alpha", "face.tif");
            _textureManager.LoadTexture("font", "font.tga");

            //Adding States to system
            _system.AddState("splash", new SplashScreenState(_system));
            _system.AddState("title", new TitleMenuState(_system));
            _system.AddState("sprite", new DrawSpriteState(_textureManager));
            _system.AddState("sprite_test", new TestSpriteClassState(_textureManager));
            _system.AddState("text_test", new TextTestState(_textureManager));
            _system.AddState("FPS_test", new FPSTestState(_textureManager));
            _system.AddState("waveform", new WaveformGraphState());
            _system.AddState("effect_test_state", new SpecialEffectsState(_textureManager));
            _system.AddState("circle_test_state", new CircleIntersectionState(_input));
            _system.AddState("rectang_test_state", new RectangleIntersectionState(_input));
            _system.AddState("tween_test_state", new TweenTestState(_textureManager));
            _system.AddState("matrix_test_state", new MatrixTestState(_textureManager));


            //INitilize splash state
            _system.ChangeState("FPS_test");
           


            if (_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                ClientSize = new Size(1280, 720);
            }
            
            //2D grahpics setup
            Setup2DGrahpics(ClientSize.Width, ClientSize.Height);

            //Initiate Fastloop
            _fastLoop = new FastLoop(GameLoop);
        }

        void GameLoop(double elapsedTime)
        {
            //Input
            UpdateInput();

            //Process
            _system.Update(elapsedTime);

            //Render
            _system.Render();
            _openGLControl.Refresh();
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Gl.glViewport(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Setup2DGrahpics(ClientSize.Width, ClientSize.Height);
        }

        private void UpdateInput()
        {
            System.Drawing.Point mousePos = Cursor.Position;
            mousePos = _openGLControl.PointToClient(mousePos);

            //Point Definition
            Point adjustedMousePoint = new Point();

            adjustedMousePoint.X = (float)mousePos.X - ((float)ClientSize.Width / 2);
            adjustedMousePoint.Y = ((float)ClientSize.Height / 2) - (float)mousePos.Y;

            _input.MousePosition = adjustedMousePoint;

        }


        //Initializes 2D graphics Matrix for openGL
        private void Setup2DGrahpics(double width, double height)
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

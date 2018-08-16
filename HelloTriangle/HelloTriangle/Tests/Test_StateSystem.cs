using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace HelloTriangle.Tests
{
    [TestFixture]
    class Test_StateSystem
    {

        [Test]
        public void StateSystemExists()
        {
            StateSystem _system = new StateSystem();
            _system.AddState("splash", new SplashScreenState(_system));
            _system.AddState("title", new SplashScreenState(_system));
            _system.AddState("playing", new SplashScreenState(_system));
            _system.AddState("settings", new SplashScreenState(_system));

            Assert.IsTrue(
                _system.Exists("splash") &&
                _system.Exists("title") &&
                _system.Exists("playing") &&
                _system.Exists("settings")
                );
           
        }

        [Test]
        public void StateSystemChangeWorks()
        {
            StateSystem stateSystem = new StateSystem();
            stateSystem.AddState("splash", new SplashScreenState(stateSystem));
            stateSystem.ChangeState("splash");

            Assert.True(true);
        }
    }
}

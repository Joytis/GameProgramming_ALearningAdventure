using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;

namespace VaueTest
{
    class SoundTestState : IGameObject
    {
        SoundManager _soundManager;
        double _count = 3;

        public SoundTestState(SoundManager soundManager)
        {
            _soundManager = soundManager;
            _soundManager.MasterVolume(0.1f);
        }


        public void Update(double elapsedTime)
        {
            _count -= elapsedTime;
            if (_count < 0)
            {
                _count = 3;
                Sound soundOne = _soundManager.PlaySound("effect");
                Sound soundTwo = _soundManager.PlaySound("effect2");

                if (_soundManager.IsPlayingSound(soundOne))
                {
                    _soundManager.StopSound(soundOne);
                }
            }

        }

        public void Render()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;

namespace ValueEmblem
{
    public class PersistantGameData
    {
        public bool HasWon { get; set; }
        public Level CurrentLevel { get; set; }
        private GameLevels _gameLevels;

        public PersistantGameData()
        {
            HasWon = false;
            _gameLevels = new GameLevels();
        }

        public void AddLevel(string levelId, Level level)
        {
            _gameLevels.AddLevel(levelId, level);
        }

        public void ChangeLegel(string levelId)
        {
            CurrentLevel = _gameLevels.Get(levelId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueEngine;


namespace ValueEmblem
{
    public class GameLevels
    {
        Dictionary<string, Level> _gameLevels;

        public GameLevels()
        {
            _gameLevels = new Dictionary<string,Level>();
        }

        public void AddLevel(string levelId, Level level)
        {
            _gameLevels.Add(levelId, level);
        }

        public Level Get(string levelId)
        {
            return _gameLevels[levelId];
        }

    }
}

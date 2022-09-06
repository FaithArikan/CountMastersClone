using System;
using System.Collections.Generic;
using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.LevelManagement
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<Level> levels;
        private Level _currentLevel;
        [SerializeField] private Transform levelHolder;
        [SerializeField] private GameEvent onLevelLoaded;

        private void Start()
        {
            LoadLevel();
        }

        public void LoadLevel()
        {
            for (int i = 0; i < levels.Count; i++)
            {
                if (!levels[i].IsLevelDone)
                {
                    _currentLevel = levels[i];
                    break;
                }
            }

            Instantiate(_currentLevel, levelHolder);
            onLevelLoaded.Invoke();
        }

        public void SetLevelIsDone()
        {
            _currentLevel.IsLevelDone = true;
        }
    }
}
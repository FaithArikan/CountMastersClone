﻿using _Project.Scripts.Helpers;
using UnityEngine;

namespace _Project.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GameState", order = 2)]
    public class GameStateSO : ScriptableObject
    {
        [SerializeField] private GameEvent onGameStateChanged;
        [SerializeField] private GameState gameState;
        [SerializeField] private GameState lastGameState;

        public GameState GameState
        {
            get => gameState;
            set
            {
                LastGameState = gameState;
                gameState = value;
                if (lastGameState != gameState)
                    onGameStateChanged.Invoke();
            }
        }

        public GameState LastGameState
        {
            get => lastGameState;
            set => lastGameState = value;
        }
    }
}
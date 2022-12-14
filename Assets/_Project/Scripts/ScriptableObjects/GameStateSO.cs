using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Core/GameState", fileName = "GameState")]
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
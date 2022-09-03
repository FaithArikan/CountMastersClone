using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameEvent onLevelLoaded;
        private void Start()
        {
            Application.targetFrameRate = 60;
            OnLevelLoaded();
        }

        private void OnLevelLoaded()
        {
            onLevelLoaded.Invoke();
        }
        public void OnLose()
        {
            Debug.Log("Game Lost");
        }

        public void OnWin()
        {
            Debug.Log("Game Won");
        }
    }
}
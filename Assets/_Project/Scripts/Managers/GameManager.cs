using _Project.Scripts.Helpers;
using UnityEngine;

namespace _Project.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private void Start()
        {
            Application.targetFrameRate = 60;
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
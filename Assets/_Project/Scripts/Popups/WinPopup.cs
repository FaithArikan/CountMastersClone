using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.Popups
{
    public class WinPopup : MonoBehaviour
    {
        [SerializeField] private GameEvent onNextLevelTapped;

        public void OnNextLevel()
        {
            onNextLevelTapped.Invoke();
        }
    }
}
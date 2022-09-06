using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.Popups
{
    public class StartPopup : MonoBehaviour
    {
        [SerializeField] private GameEvent onLevelBegin;

        public void OnLevelBegin()
        {
            onLevelBegin.Invoke();
        }
    }
}
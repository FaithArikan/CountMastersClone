using CountMasters.SaveSystem;
using UnityEngine;

namespace CountMasters.LevelManagement
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private bool _isLevelDone;
        public bool IsLevelDone
        {
            get => _isLevelDone;
            set => _isLevelDone = value;
        }
        
        private void OnEnable()
        {
            IsLevelDone = SaveManager.Load<bool>("IsLevelDone");
        }

        private void OnDisable()
        {
            SaveManager.Save(IsLevelDone, "IsLevelDone");
        }
    }
}
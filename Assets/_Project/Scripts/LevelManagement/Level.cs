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
    }
}
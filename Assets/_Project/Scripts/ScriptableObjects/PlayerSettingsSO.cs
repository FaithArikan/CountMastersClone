using UnityEngine;

namespace CountMasters.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Core/PlayerSettings", fileName = "PlayerSettings")]
    public class PlayerSettingsSO : ScriptableObject
    {
        [SerializeField] private bool canMove;
        [SerializeField] private float speed;
        [SerializeField] private float sideSpeed;

        public bool CanMove
        {
            get => canMove;
            set => canMove = value;
        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        public float SideSpeed
        {
            get => sideSpeed;
            set => sideSpeed = value;
        }
    }
}
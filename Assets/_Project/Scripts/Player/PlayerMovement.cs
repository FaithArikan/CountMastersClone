using CountMasters.Helpers;
using CountMasters.ScriptableObjects;
using UnityEngine;

namespace CountMasters.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private GameEvent onMoveValueChanged;
        [SerializeField] private MoveDirections moveDirections = MoveDirections.Forward;
        [SerializeField] private PlayerSettingsSO playerSettings;
        
        private float horizontal;

        private void Awake()
        {
            StopMovement();
        }

        public void StopMovement()
        {
            if (!playerSettings.CanMove) return;
            playerSettings.CanMove = false;
            onMoveValueChanged.Invoke();
        }
        public void StartMovement()
        {
            if(playerSettings.CanMove) return;
            playerSettings.CanMove = true;
            onMoveValueChanged.Invoke();
        }
        private void Update()
        {
             if(!playerSettings.CanMove) return;
             Move();
        }
        private void Move()
        {
            horizontal = joystick.Horizontal;
            if (horizontal > 0.3f)
                moveDirections = MoveDirections.Right;
            else if(horizontal < -0.3f)
                moveDirections = MoveDirections.Left;
            else
                moveDirections = MoveDirections.Forward;

            switch (moveDirections)
            {
                case MoveDirections.Forward:
                    transform.Translate(new Vector3(0, 0, playerSettings.Speed) * Time.deltaTime * 2);
                    break;
                case MoveDirections.Right:
                    transform.Translate(new Vector3(playerSettings.SideSpeed * horizontal, 0, playerSettings.Speed) * 
                                        Time.deltaTime * 2);
                    break;
                case MoveDirections.Left:
                    transform.Translate(new Vector3(playerSettings.SideSpeed * horizontal, 0, playerSettings.Speed) * 
                                        Time.deltaTime * 2);
                    break;
            }
            ResetHorizontal();
        }
        private void ResetHorizontal()
        {
            horizontal = 0f;
        }
    }
}
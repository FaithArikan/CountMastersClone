using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private GameEvent onMoveValueChanged;
        [SerializeField] private MoveDirections moveDirections = MoveDirections.Forward;
        [SerializeField] private bool _canMove;
        [SerializeField] private float _speed;
        [SerializeField] private float _sideSpeed;
        
        private float horizontal;
        public bool CanMove
        {
            get => _canMove;
            set
            {
                _canMove = value;
                onMoveValueChanged.Invoke();
            }
        }

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
        private void Update()
        {
             if(!CanMove) return;
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
                    transform.Translate(new Vector3(0, 0, Speed) * Time.deltaTime * 2);
                    break;
                case MoveDirections.Right:
                    transform.Translate(new Vector3(_sideSpeed * horizontal, 0, Speed) * 
                                        Time.deltaTime * 2);
                    break;
                case MoveDirections.Left:
                    transform.Translate(new Vector3(_sideSpeed * horizontal, 0, Speed) * 
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
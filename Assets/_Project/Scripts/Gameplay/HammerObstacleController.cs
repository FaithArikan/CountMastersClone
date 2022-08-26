using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public class HammerObstacleController : MonoBehaviour
    {
        [SerializeField] private bool isLeftSideHammer;
        private int _hammerAngle;
        [SerializeField] private int hammerSpeed = 1;
        private void Start()
        {
            if (isLeftSideHammer)
                _hammerAngle = -90;
            else
                _hammerAngle = 90;
            Move();
        }
        private void Move()
        {
            transform.DORotate(new Vector3(0, 0, _hammerAngle), hammerSpeed).SetLoops(-1, LoopType.Yoyo).
                SetEase(Ease.Linear);
        }
    }
}
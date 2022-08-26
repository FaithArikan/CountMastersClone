using System;
using _Project.Scripts.Helpers;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Gameplay.CanvasElement
{
    public class HandMovement : MonoBehaviour
    {
        [SerializeField] private Transform leftSide;
        [SerializeField] private Transform rightSide;

        private int _multiplicationNumber;

        public event Action<int> CloneMultiplicationAction;
        private Sequence moveSequence;
        public void OnFinish()
        {
            _multiplicationNumber = 2;
            float leftSidePoint = leftSide.transform.position.x - (leftSide.transform.localScale.x / 2) - 55;
            float rightSidePoint = rightSide.transform.position.x + (rightSide.transform.localScale.x / 2) + 20;
            transform.position = new Vector3(rightSidePoint, transform.position.y, transform.position.z);
            moveSequence.Append(transform.DOMoveX(leftSidePoint, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCirc));
        }

        public void OnTap()
        {
            DOTween.Kill(moveSequence);
            CloneMultiplicationAction?.Invoke(_multiplicationNumber);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            switch (col.gameObject.name)
            {
                case "2x":
                    _multiplicationNumber = 2;
                    break;
                case "3x":
                    _multiplicationNumber = 3;
                    break;
                case "5x":
                    _multiplicationNumber = 5;
                    break;
            }
        }
    }
}
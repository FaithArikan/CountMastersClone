﻿using CountMasters.Helpers;
using CountMasters.ScriptableObjects;
using DG.Tweening;
using UnityEngine;

namespace CountMasters.CanvasElement
{
    public class HandMovement : MonoBehaviour
    {
        [SerializeField] private Transform leftSide;
        [SerializeField] private Transform rightSide;

        [SerializeField] private FinishBarSO finishBarSo;
        public GameEvent onFinishBarFinished;
        private Sequence _moveSequence;
        public void OnFinish()
        {
            //todo: fix
            float leftSidePoint = leftSide.transform.position.x - (leftSide.transform.localScale.x / 2) - 55;
            float rightSidePoint = rightSide.transform.position.x + (rightSide.transform.localScale.x / 2) + 20;
            transform.position = new Vector3(rightSidePoint, transform.position.y, transform.position.z);
            _moveSequence.Append(transform.DOMoveX(leftSidePoint, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCirc));
        }

        public void OnTap()
        {
            DOTween.Kill(_moveSequence);
            onFinishBarFinished.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            switch (col.gameObject.name)
            {
                case "2x":
                    finishBarSo.MultiplicationAmount = 2;
                    break;
                case "3x":
                    finishBarSo.MultiplicationAmount = 3;
                    break;
                case "5x":
                    finishBarSo.MultiplicationAmount = 5;
                    break;
            }
        }
    }
}
﻿using _Project.ScriptableObjects;
using _Project.Scripts.Helpers;
using UnityEngine;
using DG.Tweening;

namespace Assets._Project.Scripts.Managers
{
    [RequireComponent(typeof(Canvas))]
    public class PopupManager : MonoBehaviour
    {
        
        [SerializeField] private GameStateSO gameStateSo;
        private Canvas _canvas;
        [SerializeField] private RectTransform panel;
        
        private readonly Vector3 _minimizedPanelScale = Vector3.one * 0.001f;
        private Vector3 _normalPanelScale = Vector3.one;
        [SerializeField] private float animationDuration = 0.2f;
        [SerializeField] private GameEvent PopupShownStart;
        [SerializeField] private GameEvent PopupShownEnd;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.enabled = false;
        }

        public void OpenPopup()
        {
            if (_canvas.enabled)
                return;
            
            _canvas.enabled = true;
            PopupShownStart.Invoke();
            gameStateSo.GameState = GameState.Pause;
        }

        public void OpenPopupWithAnimation()
        {
            panel.localScale = _minimizedPanelScale;
            OpenPopup();
            panel.DOScale(_normalPanelScale, animationDuration).SetUpdate(true);
        }

        public void ClosePopup()
        {
            panel.DOScale(_minimizedPanelScale, animationDuration).SetUpdate(true).OnComplete(() =>
            {
                _canvas.enabled = false;
                gameStateSo.GameState = GameState.Playing;
                panel.localScale = _normalPanelScale;
                PopupShownEnd.Invoke();
            });
        }

    }
}
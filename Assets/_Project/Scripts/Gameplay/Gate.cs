using System;
using _Project.ScriptableObjects;
using _Project.Scripts.Helpers;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private GateSO gateSo;
        [SerializeField] private TextMeshProUGUI gateText;
        [SerializeField] [CanBeNull] private Collider otherGate;
        private Collider col;
        private Canvas canvas;

        private void OnEnable()
        {
            canvas = GetComponentInChildren<Canvas>();
        }

        public GateSO GateSo
        {
            get => gateSo;
            set => gateSo = value;
        }

        public Collider Collider
        {
            get => col;
            set => col = value;
        }
        
        public Collider OtherGate
        {
            get => otherGate;
            set => otherGate = value;
        }

        public void RemoveOtherGateCollider()
        {
            if (otherGate != null)
                otherGate.enabled = false;
        }

        public void RemoveCanvas()
        {
            if (canvas != null)
                canvas.enabled = false;
        }
        private void Awake()
        {
            col = GetComponent<Collider>();
            if (gateText == null) gateText = GetComponentInChildren<TextMeshProUGUI>();
            switch (GateSo.Features)
            {
                case GateFeatures.Addition:
                    gateText.text = $"+{GateSo.Amount}";
                    break;
                case GateFeatures.Multiplication:
                    gateText.text = $"x{GateSo.Amount}";
                    break;
            }
        }

    }
}
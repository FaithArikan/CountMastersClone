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

        public GateSO GateSo
        {
            get => gateSo;
            set => gateSo = value;
        }

        public Collider Collider
        {
            get => col;
            set =>  col = value;
        }
        
        public Collider OtherGate
        {
            get => otherGate;
            set => otherGate = value;
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
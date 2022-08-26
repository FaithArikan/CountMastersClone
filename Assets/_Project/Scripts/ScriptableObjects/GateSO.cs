using _Project.Scripts.Helpers;
using UnityEngine;

namespace _Project.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gate", order = 1)]
    public class GateSO : ScriptableObject
    {
        [Header("LeftGate")]
        [SerializeField] private GateFeatures gateFeatures;
        [SerializeField] private int amount;
        public GateFeatures Features
        {
            get => gateFeatures;
            set => gateFeatures = value;
        }

        public int Amount
        {
            get => amount;
            set => amount = value;
        }
    }
}
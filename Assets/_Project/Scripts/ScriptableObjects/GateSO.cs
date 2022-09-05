using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GamePlay/Gate", fileName = "Gate")]
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
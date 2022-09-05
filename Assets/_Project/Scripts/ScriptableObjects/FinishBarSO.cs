using UnityEngine;

namespace CountMasters.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GamePlay/FinishBar", fileName = "FinishBar")]
    public class FinishBarSO : ScriptableObject
    {
        [SerializeField] private int multiplicationAmount = 2;

        public int MultiplicationAmount
        {
            get => multiplicationAmount;
            set => multiplicationAmount = value;
        }
    }
}
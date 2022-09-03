using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Resource", order = 0)]
    public class ResourceSO : ScriptableObject
    {
        [SerializeField] private ResourceType resourceType;
        [SerializeField] private int maximum = int.MaxValue;
        [SerializeField] private int minimum;
        [SerializeField] private int amount;
        [SerializeField] private GameEvent onResourceValueChanged;
        public int Maximum => maximum;

        public int Amount
        {
            get => amount;
            set
            {
                amount = value;
                onResourceValueChanged.Invoke();
            }
        }
        
        public void Increase(int increaseAmount)
        {
            if (amount >= maximum) return;
            increaseAmount = Mathf.Clamp(increaseAmount, minimum, maximum);
            Amount += increaseAmount;
        }
        
        public void Decrease(int count = 1)
        {
            if (amount <= minimum) return;
            Amount -= count;
        }

        public void ResetValue()
        {
            Amount = minimum;
        }
    }
}
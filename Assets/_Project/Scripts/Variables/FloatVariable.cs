using _Project.Scripts.Helpers;
using UnityEngine;

namespace _Project.Variables
{
    [CreateAssetMenu(menuName = "Float")]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField] private float floatValue;
        [SerializeField] private GameEvent onValueChanged;

        public float Value
        {
            get => floatValue;
            set
            {
                floatValue = value;
                if (onValueChanged != null) onValueChanged.Invoke();
            }
        }
    }
}
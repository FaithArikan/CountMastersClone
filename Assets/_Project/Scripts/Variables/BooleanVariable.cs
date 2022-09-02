using _Project.Scripts.Helpers;
using UnityEngine;

namespace _Project.Variables
{
    [CreateAssetMenu(menuName = "Boolean")]
    public class BooleanVariable : ScriptableObject
    {
        [SerializeField] private bool boolValue;
        [SerializeField] private GameEvent onValueChanged;

        public bool Value
        {
            get => boolValue;
            set
            {
                boolValue = value;
                if(onValueChanged != null) onValueChanged.Invoke();
            }
        }

    }
}
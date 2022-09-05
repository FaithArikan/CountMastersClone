using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.Variables
{
    [CreateAssetMenu(menuName = "Variables/Boolean", fileName = "Boolean")]
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
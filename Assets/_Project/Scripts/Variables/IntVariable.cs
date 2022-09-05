using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.Variables
{
    [CreateAssetMenu(menuName = "Variables/Int", fileName = "Int")]
    public class IntVariable : ScriptableObject
    {
        [SerializeField] private int intValue;
        [SerializeField] private GameEvent onValueChanged;

        public int Value
        {
            get => intValue;
            set
            {
                intValue = value;
                if (onValueChanged != null) onValueChanged.Invoke();
            }
        }
    }
}
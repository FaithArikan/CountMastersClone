using _Project.Scripts.Helpers;
using UnityEngine;

namespace _Project.Variables
{
    [CreateAssetMenu(menuName = "Int")]
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
using System.Collections.Generic;
using UnityEngine;

namespace CountMasters.Helpers
{
    [CreateAssetMenu(menuName = "GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new ();

        public void Invoke()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].Invoke();
        }

        public void RegisterListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
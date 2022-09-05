using System.Collections.Generic;
using UnityEngine;

namespace CountMasters.Helpers
{
    [CreateAssetMenu(menuName = "GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener.Listener> listeners = new ();

        public void Invoke()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].Invoke();
            }
        }

        public void RegisterListener(GameEventListener.Listener listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener.Listener listener)
        {
            listeners.Remove(listener);
        }
    }
}
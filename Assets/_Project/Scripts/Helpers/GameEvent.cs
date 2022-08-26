using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Helpers
{
    [CreateAssetMenu(menuName = "GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();
        private List<string> assetLocation = new List<string>();

        public void Invoke()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].Invoke();
        }

        public void RegisterListener(GameEventListener listener)
        {
            listeners.Add(listener);
            assetLocation.Add(
                $"{listener.gameObject.scene.name}/{listener.transform.root.gameObject.name}/{listener.gameObject.name}");
        }

        public void UnregisterListener(GameEventListener listener)
        {
            listeners.Remove(listener);
            assetLocation.Remove(
                $"{listener.gameObject.scene.name}/{listener.transform.root.gameObject.name}/{listener.gameObject.name}");
        }
    }
}
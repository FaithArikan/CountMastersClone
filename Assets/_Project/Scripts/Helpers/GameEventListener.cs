using UnityEngine;
using UnityEngine.Events;

namespace CountMasters.Helpers
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent[] Events;
        public UnityEvent Response;

        private void OnEnable()
        {
            foreach (var e in Events) e.RegisterListener(this);
        }

        private void OnDisable()
        {
            foreach (var e in Events) e.UnregisterListener(this);

        }

        public void Invoke()
        {
            Response.Invoke();
        }
    }

}
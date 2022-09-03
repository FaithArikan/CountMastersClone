using CountMasters.Helpers;
using DG.Tweening;
using UnityEngine;

namespace CountMasters.Gameplay
{
    public class BridgeButton : MonoBehaviour
    {
        [SerializeField] private GameEvent onBridgeButtonPressed;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone"))
            {
                onBridgeButtonPressed.Invoke();
                transform.DOMoveY(-0.5f, 0.5f);
            }
        }
    }
}
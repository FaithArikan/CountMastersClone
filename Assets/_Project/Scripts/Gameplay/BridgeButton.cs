using _Project.Scripts.Helpers;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Gameplay
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
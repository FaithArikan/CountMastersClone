using _Project.Scripts.Helpers;
using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public class FinishLine : MonoBehaviour
    {
        [SerializeField] private GameEvent onBuildTower;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                onBuildTower.Invoke();
            }
        }
    }
}
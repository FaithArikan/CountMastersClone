using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.Gameplay
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
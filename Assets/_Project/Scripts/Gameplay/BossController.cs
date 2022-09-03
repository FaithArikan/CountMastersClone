using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.Gameplay
{
    public class BossController : MonoBehaviour
    {
        [SerializeField] private GameEvent onLevelFinished;
        [SerializeField] private GameEvent onBossPowerChanged;
        [SerializeField] private int bossPower;

        public int BossPower
        {
            get => bossPower;
            set
            {
                bossPower = value;
                onBossPowerChanged.Invoke();
                if (bossPower <= 0)
                {
                    Destroy(gameObject);
                    onLevelFinished.Invoke();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Clone"))
            {
                BossPower--;
            }
        }
    }
}
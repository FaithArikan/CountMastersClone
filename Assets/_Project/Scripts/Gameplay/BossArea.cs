using CountMasters.Helpers;
using DG.Tweening;
using UnityEngine;

namespace CountMasters.Gameplay
{
    public class BossArea : MonoBehaviour
    {
        [SerializeField] private GameEvent onBossFightStarted;
        private Sequence _moveSequence;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.transform.DOMove(new Vector3(transform.position.x, 0, transform.position.z), 1);
                onBossFightStarted.Invoke();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _moveSequence.Append(other.transform.DOMove(new Vector3(transform.position.x, 0, 
                    transform.position.z), 0.5f));
            }
        }
        public void CloneEndState()
        {
            DOTween.Kill(_moveSequence);
        }
    }
}
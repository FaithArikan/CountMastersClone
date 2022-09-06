using CountMasters.Helpers;
using CountMasters.ScriptableObjects;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace CountMasters.Gameplay
{
    public class CloneDestroy : MonoBehaviour
    {
        [SerializeField] private GameEvent onTotalCloneAmountChanged;
        [SerializeField] private GameEvent onEnemyEnded;
        [SerializeField] private CloneSO cloneList;
        
        private Sequence _moveSeq;
        private Rigidbody _rb;
        private NavMeshAgent _agent;
        private CapsuleCollider _col;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _col = GetComponent<CapsuleCollider>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.gameObject.tag)
            {
                case "Obstacle":
                {
                    DestroyClone();
                    break;
                }
                case "Enemy":
                {
                    DestroyClone();
                    DestroyEnemy(other.gameObject);
                    onEnemyEnded.Invoke();
                    break;
                }
                case "BossArea":
                {
                    OnBossFightStarted(other.gameObject);
                    break;
                }
                case "Cliff":
                {
                    FallOfTheCliff();
                    break;
                }
                case "Boss":
                {
                    DestroyClone();
                    break;
                }
            }
        }

        private void DestroyClone()
        {
            cloneList.RemoveClone(GetComponent<Clone>());
            _col.enabled = false;
            transform.parent = null;
            transform.DOKill();
            Destroy(gameObject);
            onTotalCloneAmountChanged.Invoke();
        }

        public void SimpleDestroy()
        {
            cloneList.RemoveClone(GetComponent<Clone>());
            Destroy(gameObject);
        }
        
        private void OnBossFightStarted(GameObject boss)
        {
            var bossPosition = boss.transform.position;
            _agent.SetDestination(bossPosition);
        }
        
        private void DestroyEnemy(GameObject enemy)
        {
            EnemyController enemyController = enemy.GetComponentInParent<EnemyController>();
            enemyController.EnemyList.RemoveAt(0);
            enemyController.EnemyAmountTextControls();
            enemy.GetComponent<CapsuleCollider>().enabled = false;
            enemy.transform.parent = null;
            Destroy(enemy);
        }

        private void FallOfTheCliff()
        {
            transform.DORotate(new Vector3(90,0,0), 1f);
            _rb.drag = 0;
            _rb.mass = 10;
            cloneList.RemoveClone(GetComponent<Clone>());
            _agent.enabled = false;
            _col.enabled = false;
            transform.parent = null;
            Destroy(gameObject, 2);
            onTotalCloneAmountChanged.Invoke();
        }
    }
}
using CountMasters.Helpers;
using CountMasters.ScriptableObjects;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CountMasters.Gameplay
{
    public class CloneDestroy : MonoBehaviour
    {
        [SerializeField] private GameEvent onTotalCloneAmountChanged;
        [SerializeField] private GameEvent onEnemyEnded;
        [SerializeField] private CloneSO cloneList;
        private Sequence _moveSeq;

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
            cloneList.RemoveClone(this);
            GetComponent<CapsuleCollider>().enabled = false;
            transform.parent = null;
            transform.DOKill();
            Destroy(gameObject);
            onTotalCloneAmountChanged.Invoke();
        }
        private void OnBossFightStarted(GameObject boss)
        {
            var bossPosition = boss.transform.position;
            _moveSeq.Append(transform.DOMove(new Vector3(Random.Range(bossPosition.x + 1, bossPosition.x - 1), transform.position.y, 
                Random.Range(bossPosition.z + 1, bossPosition.z - 1)), Random.Range(0.8f, 2f)));
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
            GetComponent<Rigidbody>().drag = 0;
            GetComponent<Rigidbody>().mass = 10;
            cloneList.RemoveClone(this);
            GetComponent<CapsuleCollider>().enabled = false;
            transform.parent = null;
            Destroy(gameObject, 2);
            onTotalCloneAmountChanged.Invoke();
        }
    }
}
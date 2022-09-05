using System.Collections.Generic;
using CountMasters.Player;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CountMasters.Gameplay
{
    [RequireComponent(typeof(BoxCollider))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private int startEnemyAmount;
        private List<GameObject> _enemyList = new();
        [SerializeField] private GameObject enemyPrefab;
        
        public int EnemyAmount => EnemyList.Count;
        [SerializeField] private TextMeshProUGUI enemyCountText;
        private Canvas _enemyCanvas;

        public List<GameObject> EnemyList
        {
            get => _enemyList;
            set => _enemyList = value;
        }
        private void Awake()
        {
            _enemyCanvas = GetComponentInChildren<Canvas>();
            for (int i = 0; i < startEnemyAmount; i++)
            {
                Instantiate(enemyPrefab, GetPosition(i), Quaternion.identity,  transform);
                EnemyList.Add(enemyPrefab);
            }

            EnemyAmountTextControls();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
                
                var otherTransform = other.gameObject.transform;
                playerMovement.StopMovement();
                otherTransform.DOMove(new Vector3(transform.position.x, 0, transform.position.z), 1f).OnComplete((() =>                 
                {
                    if (EnemyAmount != 0)
                        otherTransform.DOMove(new Vector3(transform.position.x, 0, transform.position.z), 0.1f);
                }
                ));
            }
        }

        public void EnemyAmountTextControls()
        {
            enemyCountText.text = EnemyList.Count.ToString();
            if (EnemyList.Count <= 0)
            {
                _enemyCanvas.enabled = false;
            }
        }
        private Vector3 GetPosition(int index)
        {
            float goldenAngle = 137.5f;  

            float x = Mathf.Sqrt(index + 1) * Mathf.Cos(Mathf.Deg2Rad * goldenAngle * (index + 1)) * 0.3f;
            float z = Mathf.Sqrt(index + 1) * Mathf.Sin(Mathf.Deg2Rad * goldenAngle * (index + 1)) * 0.3f;

            Vector3 localPos = new Vector3(x, 0.5f, z);
            Vector3 targetWorldPos = transform.TransformPoint(localPos);

            return targetWorldPos;
        }
    }
}
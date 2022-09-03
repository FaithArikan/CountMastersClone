using CountMasters.Gameplay;
using CountMasters.ScriptableObjects;
using CountMasters.CanvasElement;
using CountMasters.Helpers;
using CountMasters.Variables;
using UnityEngine;

namespace CountMasters.Player
{
    public class Cloner : MonoBehaviour
    {
        [SerializeField] private Player player;
        
        [SerializeField] private HandMovement finishSpawner;

        [SerializeField] private GameObject clonePrefab;

        [SerializeField] private ResourceSO resourceSo;
        private void Start()
        {
            var parent = player.transform;
            Vector3 pos = parent.position;
            for (int i = 0; i < player.StartCloneAmount; i++)
            {
                Instantiate(clonePrefab, GetPosition(i), Quaternion.identity,  parent);
                player.CloneList.Add(clonePrefab);
            }
        }

        private void OnEnable()
        {
            player.CloneAdditionAction += AdditionClone;
            finishSpawner.CloneMultiplicationAction += MultiplicationClone;
            player.CloneMultiplicationAction += MultiplicationClone;
        }

        private void OnDisable()
        {
            player.CloneAdditionAction -= AdditionClone;
            finishSpawner.CloneMultiplicationAction -= MultiplicationClone;
            player.CloneMultiplicationAction -= MultiplicationClone;
        }

        private void MultiplicationClone(int multAmount)
        {
            int cloneAmount = (player.CloneAmount * multAmount) - player.CloneAmount;
            for (int i = 0; i < cloneAmount; i++)
            {
                Instantiate(clonePrefab, GetPosition(i), Quaternion.identity,  transform);
                player.CloneList.Add(clonePrefab);
            }
        }

        public void FinishMultiplicationClone()
        {
            int cloneAmount = (player.CloneAmount * resourceSo.Amount) - player.CloneAmount;
            for (int i = 0; i < cloneAmount; i++)
            {
                Instantiate(clonePrefab, GetPosition(i), Quaternion.identity,  transform);
                player.CloneList.Add(clonePrefab);
            }
        }
        private void AdditionClone(int addAmount)
        {
            for (int i = 0; i < addAmount; i++)
            {
                Instantiate(clonePrefab, GetPosition(i), Quaternion.identity,  transform);
                player.CloneList.Add(clonePrefab);
            }
        }
        private Vector3 GetPosition(int index)
        {
            float goldenAngle = 137.5f;  

            float x = Mathf.Sqrt(index + 1) * Mathf.Cos(Mathf.Deg2Rad * goldenAngle * (index + 1)) * 0.3f;
            float z = Mathf.Sqrt(index + 1) * Mathf.Sin(Mathf.Deg2Rad * goldenAngle * (index + 1)) * 0.3f;

            Vector3 runnerLocalPosition = new Vector3(x, 1, z);
            Vector3 runnerTargetWorldPosition = transform.TransformPoint(runnerLocalPosition);

            return runnerTargetWorldPosition;
        }
    }
}

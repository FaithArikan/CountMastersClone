using CountMasters.Gameplay;
using CountMasters.ScriptableObjects;
using CountMasters.Helpers;
using CountMasters.Variables;
using UnityEngine;

namespace CountMasters.Player
{
    public class Cloner : MonoBehaviour
    {
        [SerializeField] private Player player;

        [SerializeField] private IntVariable startCloneAmount;
        
        [SerializeField] private FinishBarSO finishBar;

        [SerializeField] private GameObject clonePrefab;

        [SerializeField] private CloneSO cloneList;

        [SerializeField] private GameEvent onCloneMemberInstantiateCompleted;

        public void OnLevelLoaded()
        {
            ClearCloneList();
            StartSpawn(startCloneAmount.Value);
        }

        private void ClearCloneList()
        {
            cloneList.InitializeList();
        }
        private void OnEnable()
        {
            player.CloneAdditionAction += AdditionClone;
            player.CloneMultiplicationAction += MultiplicationClone;
        }

        private void OnDisable()
        {
            player.CloneAdditionAction -= AdditionClone;
            player.CloneMultiplicationAction -= MultiplicationClone;
        }

        private void StartSpawn(int startingAmount)
        {
            if (startingAmount <= 1)
            {
                startingAmount = 1;
            }
            for (int i = 0; i < startingAmount; i++)
            {
                Clone clone = Instantiate(clonePrefab, transform).
                    GetComponent<Clone>();
                cloneList.AddClone(clone);
            }
        }

        public void LevelBeginClonesInit()
        {
            foreach (var clone in GetComponentsInChildren<Clone>())
            {
                clone.Init();
            }
        }
        
        private void MultiplicationClone(int multAmount)
        {
            int cloneAmount = (cloneList.CloneAmount * multAmount) - cloneList.CloneAmount;
            for (int i = 0; i < cloneAmount; i++)
            {
                Clone clone = Instantiate(clonePrefab, transform).
                    GetComponent<Clone>();
                cloneList.AddClone(clone);
                clone.Init();
            }
            onCloneMemberInstantiateCompleted.Invoke();
        }

        public void FinishMultiplicationClone()
        {
            int cloneAmount = (cloneList.CloneAmount * finishBar.MultiplicationAmount) - cloneList.CloneAmount;
            for (int i = 0; i < cloneAmount; i++)
            {
                Clone cloneGo = Instantiate(clonePrefab, transform).
                    GetComponent<Clone>();
                cloneList.AddClone(cloneGo);
                cloneGo.Init();
            }
            onCloneMemberInstantiateCompleted.Invoke();
        }
        private void AdditionClone(int addAmount)
        {
            for (int i = 0; i < addAmount; i++)
            {
                Clone cloneGo = Instantiate(clonePrefab, transform).
                    GetComponent<Clone>();
                cloneList.AddClone(cloneGo);
                cloneGo.Init();
            }
            onCloneMemberInstantiateCompleted.Invoke();
        }
    }
}

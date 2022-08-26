using System;
using System.Collections.Generic;
using _Project.Scripts.Gameplay;
using _Project.Scripts.Helpers;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Player
{
    public class Player : MonoBehaviour
    {
        private int _startCloneAmount = 1;
        private int _totalChangeCloneAmount;
        
        private List<GameObject> cloneList = new();
        private BoxCollider boxCol;
        
        [SerializeField] private GameEvent onTotalCloneAmountChanged;
        [SerializeField] private GameEvent onLoseEvent;
        [SerializeField] private GameEvent onFinishAreaEvent;

        public event Action<int> CloneAdditionAction; 
        public event Action<int> CloneMultiplicationAction;

        private void Awake()
        {
            boxCol = GetComponent<BoxCollider>();
        }
        
        public int StartCloneAmount
        {
            get => _startCloneAmount;
            set => _startCloneAmount = value;
        }

        public List<GameObject> CloneList
        {
            get => cloneList;
            set
            {
                cloneList = value;
                onTotalCloneAmountChanged.Invoke();
            }
        }
        
        public void IsClonesFinished()
        {
            if(CloneList.Count > 0) return;
            onLoseEvent.Invoke();
        }

        public int CloneAmount => cloneList.Count;
        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("Finish"))
            {
                onFinishAreaEvent.Invoke();
            }

            var gate = col.GetComponent<Gate>();
            if (gate != null)
            {
                switch (gate.GateSo.Features)
                {
                    case GateFeatures.Addition:
                        if (gate.OtherGate != null)
                            gate.OtherGate.enabled = false;
                        gate.Collider.enabled = false;
                        gate.GetComponentInChildren<Canvas>().enabled = false;
                        CloneAdditionAction?.Invoke(gate.GateSo.Amount);
                        boxCol.size = new Vector3(CloneList.Count / 40, boxCol.size.y, CloneList.Count / 20);
                        break;
                    case GateFeatures.Multiplication:
                        if (gate.OtherGate != null)
                            gate.OtherGate.enabled = false;
                        gate.Collider.enabled = false;
                        gate.GetComponentInChildren<Canvas>().enabled = false;
                        CloneMultiplicationAction?.Invoke(gate.GateSo.Amount);
                        boxCol.size = new Vector3(CloneList.Count / 40, boxCol.size.y, CloneList.Count / 20);
                        break;
                }
                onTotalCloneAmountChanged.Invoke();
            }
        }
    }
}

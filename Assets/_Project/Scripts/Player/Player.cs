using System;
using CountMasters.Helpers;
using CountMasters.Gameplay;
using UnityEngine;

namespace CountMasters.Player
{
    public class Player : MonoBehaviour
    {
        private BoxCollider boxCol;
        
        [SerializeField] private GameEvent onTotalCloneAmountChanged;
        [SerializeField] private GameEvent onFinishAreaEvent;

        public event Action<int> CloneAdditionAction; 
        public event Action<int> CloneMultiplicationAction;

        private void Awake()
        {
            boxCol = GetComponent<BoxCollider>();
        }
        
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
                    //TODO: boxcolSize
                    case GateFeatures.Addition:
                    {
                        gate.Collider.enabled = false;
                        if (gate.OtherGate != null)
                            gate.RemoveOtherGateCollider();
                        gate.RemoveCanvas();
                        CloneAdditionAction?.Invoke(gate.GateSo.Amount);
                        boxCol.size = CombineColliderBounds(GetComponentsInChildren<Collider>()).extents * 2;
                        break;
                    }
                    case GateFeatures.Multiplication:
                    {
                        gate.Collider.enabled = false;
                        if (gate.OtherGate != null)
                            gate.RemoveOtherGateCollider();
                        gate.RemoveCanvas();
                        CloneMultiplicationAction?.Invoke(gate.GateSo.Amount);
                        boxCol.size = CombineColliderBounds(GetComponentsInChildren<Collider>()).extents * 2;
                        break;
                    }
                }
                onTotalCloneAmountChanged.Invoke();
                foreach (var clone in GetComponentsInChildren<Clone>())
                {
                    clone.Init();
                }
            }
        }
        
        private Bounds CombineColliderBounds(Collider[] colliders)
        {
            var bounds = colliders[0].bounds;
        
            foreach (var colliderComponent in colliders)
            {
                bounds.Encapsulate(colliderComponent.bounds);
            }
            return bounds;
        }
    }
}

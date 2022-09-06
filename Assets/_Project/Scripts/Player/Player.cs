using System;
using CountMasters.Helpers;
using CountMasters.Gameplay;
using UnityEngine;

namespace CountMasters.Player
{
    public class Player : MonoBehaviour
    {
        
        [SerializeField] private GameEvent onTotalCloneAmountChanged;
        [SerializeField] private GameEvent onFinishAreaEvent;
        public event Action<int> CloneAdditionAction; 
        public event Action<int> CloneMultiplicationAction;
        
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
                    {
                        gate.Collider.enabled = false;
                        if (gate.OtherGate != null)
                            gate.RemoveOtherGateCollider();
                        gate.RemoveCanvas();
                        CloneAdditionAction?.Invoke(gate.GateSo.Amount);
                        break;
                    }
                    case GateFeatures.Multiplication:
                    {
                        gate.Collider.enabled = false;
                        if (gate.OtherGate != null)
                            gate.RemoveOtherGateCollider();
                        gate.RemoveCanvas();
                        CloneMultiplicationAction?.Invoke(gate.GateSo.Amount);
                        break;
                    }
                }
                onTotalCloneAmountChanged.Invoke();
            }
        }
    }
}

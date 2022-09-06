using System.Collections.Generic;
using CountMasters.Gameplay;
using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GamePlay/Clone", fileName = "Clone")]
    public class CloneSO : ScriptableObject
    {
         [SerializeField] private List<Clone> clonerList = new();
         [SerializeField] private GameEvent onTotalCloneAmountChanged;
         [SerializeField] private GameEvent onLoseEvent;

         public List<Clone> Value
         {
             get => clonerList;
             set
             {
                 clonerList = value;
                 InvokeOnValueChanged();
             }
         }
         public int CloneAmount => clonerList.Count;

         public void InitializeList()
         {
             clonerList = new ();
         }

         public void AddClone(Clone clone)
         {
             if (!clonerList.Contains(clone))
             {
                 clonerList.Add(clone);
                 InvokeOnValueChanged();
             }
         }
         
         public void RemoveClone(Clone clone)
         {
             if (clonerList.Contains(clone))
             {
                 clonerList.Remove(clone);
                 InvokeOnValueChanged();
             }
         }
         private void InvokeOnValueChanged()
         {
             if (onTotalCloneAmountChanged != null)
             {
                 onTotalCloneAmountChanged.Invoke();
                 if(CloneAmount > 0) return;
                 onLoseEvent.Invoke();
             }
         }
    }
}
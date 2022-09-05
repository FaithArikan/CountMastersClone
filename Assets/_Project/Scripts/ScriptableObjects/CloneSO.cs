using System.Collections.Generic;
using CountMasters.Gameplay;
using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GamePlay/Clone", fileName = "Clone")]
    public class CloneSO : ScriptableObject
    {
         [SerializeField] private List<CloneDestroy> clonerList = new();
         [SerializeField] private GameEvent onTotalCloneAmountChanged;
         [SerializeField] private GameEvent onLoseEvent;

         public List<CloneDestroy> Value
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

         public void AddClone(CloneDestroy cloneDestroy)
         {
             if (!clonerList.Contains(cloneDestroy))
             {
                 clonerList.Add(cloneDestroy);
                 InvokeOnValueChanged();
             }
         }
         
         public void RemoveClone(CloneDestroy cloneDestroy)
         {
             if (clonerList.Contains(cloneDestroy))
             {
                 clonerList.Remove(cloneDestroy);
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
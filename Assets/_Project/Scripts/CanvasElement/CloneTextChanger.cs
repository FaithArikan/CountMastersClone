using CountMasters.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace CountMasters.CanvasElement
{
    public class CloneTextChanger : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI cloneText;
        [SerializeField] private CloneSO cloneList;
        
        public void OnCloneAmountChanged()
        {
            cloneText.text = cloneList.CloneAmount.ToString();
        }

    }
}
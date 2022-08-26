using TMPro;
using UnityEngine;

namespace _Project.Scripts.Gameplay.CanvasElement
{
    public class CloneTextChanger : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI cloneText;
        [SerializeField] private Player.Player player;
        
        public void OnCloneAmountChanged()
        {
            cloneText.text = player.CloneAmount.ToString();
        }

    }
}
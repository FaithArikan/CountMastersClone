using CountMasters.Gameplay;
using TMPro;
using UnityEngine;

namespace CountMasters.CanvasElement
{
    public class BossTextChanger : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI bossPowerText;
        [SerializeField] private BossController bossController;

        private void Start()
        {
            OnBossPowerAmountChanged();
        }

        public void OnBossPowerAmountChanged()
        {
            bossPowerText.text = bossController.BossPower.ToString();
        }

    }
}
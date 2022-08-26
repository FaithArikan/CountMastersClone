using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public class BridgeController : MonoBehaviour
    {
        [SerializeField] private Transform bridgeOne;
        [SerializeField] private Transform bridgeTwo;

        [SerializeField] private float bridgeSpeed;

        private Sequence _bridgeOneSeq;
        private Sequence _bridgeTwoSeq;

        private void Start()
        {
            _bridgeOneSeq.Append(bridgeOne
                .DOMove(new Vector3(bridgeTwo.position.x, bridgeOne.position.y, bridgeOne.position.z),
                    bridgeSpeed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear));
            _bridgeTwoSeq.Append(bridgeTwo.
                DOMove(new Vector3(bridgeOne.position.x, bridgeTwo.position.y, bridgeTwo.position.z), 
                    bridgeSpeed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear));
        }

        public void OnBridgeButtonPressed()
        {
            DOTween.Kill(bridgeOne);
            DOTween.Kill(bridgeTwo);
        }
    }
}
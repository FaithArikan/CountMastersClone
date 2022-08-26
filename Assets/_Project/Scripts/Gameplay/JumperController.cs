using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public class JumperController : MonoBehaviour
    {
        [SerializeField] private Transform jumpEndPoint;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.transform.DOJump(jumpEndPoint.position, 1f, 1, 1);
            }
        }

    }
}
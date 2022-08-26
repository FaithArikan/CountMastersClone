using UnityEngine;

namespace _Project.Scripts.Managers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] private Transform cam;
        private Vector3 offset;

        private void Start()
        {
            offset = cam.position - target.position;
        }
        void LateUpdate()
        {
            cam.position = target.position + offset;
        }
    }
}
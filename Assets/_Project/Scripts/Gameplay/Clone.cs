using CountMasters.Helpers;
using UnityEngine;
using UnityEngine.AI;

namespace CountMasters.Gameplay
{
    public class Clone : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent navMeshAgent;
        
        public CloneType type;
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        

        public void Init()
        {
            if (!transform.parent) return;
            navMeshAgent = GetComponent<NavMeshAgent>();
            if (!navMeshAgent.enabled)
            {
                navMeshAgent.enabled = true;
            } 

            StartAnimation();
        }
        private void FixedUpdate()
        {
            if (!navMeshAgent.enabled || !transform.parent) return;
            navMeshAgent.SetDestination(transform.parent.position);
            Quaternion rotation = Quaternion.identity;
            transform.rotation = rotation;
            float dist = Vector3.Distance(transform.localPosition, Vector3.zero);
            float speed = navMeshAgent.speed - Time.deltaTime;
            navMeshAgent.speed = Mathf.Clamp(speed*dist, 0.3f, 6);
        }

        private void StartAnimation()
        {
            animator = GetComponentInChildren<Animator>();
            if (type == CloneType.Player)
            {
                animator.SetBool(IsMoving, true);
            }
        }
    }
}
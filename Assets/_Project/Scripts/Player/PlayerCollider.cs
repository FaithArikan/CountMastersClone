using UnityEngine;

namespace CountMasters.Player
{
    public class PlayerCollider : MonoBehaviour
    {
        private BoxCollider boxCol;
        
        private void Awake()
        {
            boxCol = GetComponent<BoxCollider>();
        }

        public void SetBeginSize()
        {
            boxCol.size = new Vector3(1, 2, 1);
        }
        
        public void SetColliderSize()
        {
            float rad = 0f;
            foreach (var cl in GetComponentsInChildren<CapsuleCollider>())
            {
                rad += cl.radius;
            }

            boxCol.size = new Vector3(rad / 2, boxCol.size.y, rad / 2);
        }
    }
}
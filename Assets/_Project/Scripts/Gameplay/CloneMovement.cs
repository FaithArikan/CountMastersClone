using CountMasters.ScriptableObjects;
using UnityEngine;

namespace CountMasters.Gameplay
{
    public class CloneMovement : MonoBehaviour
    {
        [SerializeField] private CloneSO cloneList;
        [SerializeField] private float radius;

        public void OnLevelLoaded()
        {
            SetFormation();
        }
        
        private void SetFormation()
        {
            for (int i = 0; i < cloneList.Value.Count; i++)
            {
                float angle = i * (2 * Mathf.PI / 10);
                float pos = Mathf.Clamp((float)i/cloneList.Value.Count *Random.Range(-radius,radius), -radius, radius);
                float posX = pos * Mathf.Sin(angle);
                float posZ = pos * Mathf.Cos(angle);
                cloneList.Value[i].transform.localPosition = new Vector3(posX,0,posZ);
            }
        }
    }
}
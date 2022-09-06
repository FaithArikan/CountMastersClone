using System.Collections.Generic;
using CountMasters.Helpers;
using UnityEngine;

namespace CountMasters.LevelManagement
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<Level> levels;
        private Level _currentLevel;
        [SerializeField] private GameObject levelHolder;
        [SerializeField] private GameEvent onLevelLoaded;

        private void Start()
        {
            LoadLevel();
        }

        public void LoadLevel()
        {
            DestroyChildren(levelHolder.transform);
            for (int i = 0; i < levels.Count; i++)
            {
                if (!levels[i].IsLevelDone)
                {
                    _currentLevel = levels[i];
                    break;
                }
            }

            InstantiateGameObject(levelHolder, _currentLevel);
            onLevelLoaded.Invoke();
        }

        public void SetLevelIsDone()
        {
            _currentLevel.IsLevelDone = true;
        }
        private GameObject InstantiateGameObject(GameObject parent, Level prefab)
        {
            Level level = Instantiate(prefab);
            if (level != null && parent != null)
            {
                Transform t = level.transform;
                t.SetParent(parent.transform);
                t.localPosition = Vector3.zero;
                t.localRotation = Quaternion.identity;
                t.localScale = Vector3.one;
                RectTransform rect = level.transform as RectTransform;
                if (rect != null)
                {
                    rect.anchoredPosition = Vector3.zero;
                    rect.localRotation = Quaternion.identity;
                    rect.localScale = Vector3.one;
                    if (rect.anchorMin.x != rect.anchorMax.x && rect.anchorMin.y != rect.anchorMax.y)
                    {
                        rect.offsetMin = Vector2.zero;
                        rect.offsetMax = Vector2.zero;
                    }
                }
                level.gameObject.layer = parent.layer;
            }
            return level.gameObject;
        }

        private void DestroyChildren(Transform t)
        {
            foreach (Transform child in t)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
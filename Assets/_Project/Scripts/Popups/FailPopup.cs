using UnityEngine;
using UnityEngine.SceneManagement;

namespace CountMasters.Popups
{
    public class FailPopup : MonoBehaviour
    {
        public void ReloadScene()
        {
            string gameScene = "ExampleGameScene";
            SceneManager.UnloadSceneAsync(gameScene);
            SceneManager.LoadScene(gameScene, LoadSceneMode.Additive);
        }
    }
}
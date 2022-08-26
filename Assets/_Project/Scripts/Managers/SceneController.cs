using _Project.Scripts.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Managers
{
    public class SceneController : Singleton<SceneController>
    {
        private void Start()
        {
            LoadBeginScenesAdditive();
        }

        private void LoadBeginScenesAdditive()
        {
            SceneManager.LoadScene("ExampleGameScene", LoadSceneMode.Additive);
        }
    }
}
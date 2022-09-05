using CountMasters.Helpers;
using UnityEngine.SceneManagement;

namespace CountMasters.Managers
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
            SceneManager.LoadScene("CanvasScene", LoadSceneMode.Additive);
        }
    }
}
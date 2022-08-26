using UnityEngine;

namespace _Project.Scripts.Managers
{
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField] private string linkedInURL;
        [SerializeField] private string githubURL;
        public void OpenLinkedInProfile()
        {
            Application.OpenURL($"{linkedInURL}");
        }
        public void OpenGithubProfile()
        {
            Application.OpenURL($"{githubURL}");
        }
    }
}
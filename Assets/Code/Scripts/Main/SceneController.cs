using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts.Main
{
    public class SceneController : MonoBehaviour
    {
        public void LoadScene(int id)
        {
            SceneManager.LoadScene(id);
        }
        
        public void Quit()
        {
            Application.Quit();
        }
    }
}

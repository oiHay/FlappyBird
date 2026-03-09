using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus.DeathScreen
{
    public class DeathBehaviour : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}


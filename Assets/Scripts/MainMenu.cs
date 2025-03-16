using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if (SceneManager.GetActiveScene().name.Equals("Gamo Vert"))
        {

            SceneManager.LoadSceneAsync("Level01");
        }
        else
        {
            SceneManager.LoadSceneAsync("AbsoluteKino");
        }

    }
}

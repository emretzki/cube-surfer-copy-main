using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlCenter : MonoBehaviour
{

    
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(1);

        

    }

    public void StartGame()
    {

    }



    public void ResetScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

}
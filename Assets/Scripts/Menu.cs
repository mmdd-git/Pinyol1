using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Final()
    {
        Debug.Log("Button pressed!"); Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
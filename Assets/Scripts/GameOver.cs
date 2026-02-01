using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CubeMover mover = other.GetComponent<CubeMover>();

        if (mover != null)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        // Aquí puedes cargar una escena de victoria:
        SceneManager.LoadScene("Main Menu");

        // O activar un panel de UI:
        // winPanel.SetActive(true);

        // O pausar el juego:
        // Time.timeScale = 0f;
    }
}
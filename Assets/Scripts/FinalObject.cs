using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalObject : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject panel;
    public GameObject panel2;

    private void OnTriggerEnter(Collider other)
    {
        CubeMover mover = other.GetComponent<CubeMover>();
        Debug.Log("aaaaaaaa");

        if (mover != null)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        panel2.SetActive(false);
        panel.SetActive(true);
    }
}
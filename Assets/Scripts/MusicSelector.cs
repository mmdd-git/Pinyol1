using UnityEngine;

public class MusicSelector : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip song1;
    public AudioClip song2;

    private void Start()
    {
        int selected = PlayerPrefs.GetInt("SelectedSong", 0);

        switch (selected)
        {
            case 1:
                audioSource.clip = song1;
                audioSource.Play();
                break;

            case 2:
                audioSource.clip = song2;
                audioSource.Play();
                break;

            case 0:
            default:
                // No music
                break;
        }
    }
}
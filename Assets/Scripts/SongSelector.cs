using UnityEngine;

public class SongSelector : MonoBehaviour
{
    public void SelectSong1()
    {
        PlayerPrefs.SetInt("SelectedSong", 1);
    }

    public void SelectSong2()
    {
        PlayerPrefs.SetInt("SelectedSong", 2);
    }

    public void SelectNoMusic()
    {
        PlayerPrefs.SetInt("SelectedSong", 0);
    }
}
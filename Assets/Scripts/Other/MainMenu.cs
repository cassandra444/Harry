using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Global")]
    [SerializeField] private AudioSource _OnButtonSound;

    [Header("Play Button")]
    public Image playImage;
    public Sprite unselectPlayImage;
    public Sprite selectPlayImage;

    [Header("Quit Button")]
    public Image quitImage;
    public Sprite unselectQuitImage;
    public Sprite selectQuitImage;


    #region Play and Quit
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StopGame()
    {
        Application.Quit();
    }
    #endregion


    #region Change Sprites
    public void ChangePlay()
    {
        playImage.sprite = selectPlayImage;
        _OnButtonSound.Play();
    }

    public void BackPlay()
    {
        playImage.sprite = unselectPlayImage;
    }

    public void ChangeQuit()
    {
        quitImage.sprite = selectQuitImage;
        _OnButtonSound.Play();
    }

    public void BackQuit()
    {
        quitImage.sprite = unselectQuitImage;
    }

  
    #endregion


}

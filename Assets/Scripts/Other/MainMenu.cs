using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Global")]
    //[SerializeField] private AudioSource _OnButtonSound;

    [Header("Play Button")]
    public Image playImage;
    public Sprite unselectPlayImage;
    public Sprite selectPlayImage;
    public GameObject playSound;
    public GameObject quitSound;

    [Header("Quit Button")]
    public Image quitImage;
    public Sprite unselectQuitImage;
    public Sprite selectQuitImage;

    void Start()
    {
        playSound.SetActive(false);
        quitSound.SetActive(false);
    }
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
        playSound.SetActive(true);
       // Debug.LogError("PlayEnter");        //_OnButtonSound.Play();
    }

    public void BackPlay()
    {
        playImage.sprite = unselectPlayImage;
        playSound.SetActive(false);
    }

    public void ChangeQuit()
    {
        quitImage.sprite = selectQuitImage;
        quitSound.SetActive(true);
        //_OnButtonSound.Play();
    }

    public void BackQuit()
    {
        quitImage.sprite = unselectQuitImage;
        quitSound.SetActive(false);
    }

  
    #endregion


}

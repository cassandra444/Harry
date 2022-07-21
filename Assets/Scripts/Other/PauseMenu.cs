using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Global")]
    public GameObject _PauseMenuCanvas;
    [SerializeField] private AudioSource _OnButtonSound;

    [Header("Pause Button")]
    public Image pauseImage;
    public Sprite unselectPauseImage;
    public Sprite selectPauseImage;

    [Header("Resume Button")]
    public Image resumeImage;
    public Sprite unselectResumeImage;
    public Sprite selectResumeImage;

    [Header("Quit BUtton")]
    public Image quitImage;
    public Sprite unselectQuitImage;
    public Sprite selectQuitImage;

    public void Start()
    {
        _PauseMenuCanvas.SetActive(false);
    }

    #region Button Actions
    public void PauseGame()
    {
        _PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

    #region Change Sprites
    public void ChangePause()
    {
        pauseImage.sprite = selectPauseImage;
        _OnButtonSound.Play();
    }

    public void BackPause()
    {
        pauseImage.sprite = unselectPauseImage;
    }
    public void ChangeResume()
    {
        resumeImage.sprite = selectResumeImage;
        _OnButtonSound.Play();
    }

    public void BackResume()
    {
        resumeImage.sprite = unselectResumeImage;
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

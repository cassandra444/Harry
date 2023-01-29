using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool _mouseOnUi;
    public GameObject _AmbiantSound;
    [Header("Global")]
    public GameObject _PauseMenuCanvas;
    public Image _PauseMenuSprite;
    [SerializeField] private GameObject _OnButtonSound;

    [Header("Pause Button")]
    public Image pauseImage;
    public Sprite unselectPauseImage;
    public Sprite selectPauseImage;

    [Header("Resume Button")]
    //public Image resumeImage;
    public Sprite unselectResumeImage;
    public Sprite selectResumeImage;

    [Header("Quit BUtton")]
    //public Image quitImage;
    public Sprite unselectQuitImage;
    public Sprite selectQuitImage;

    public void Start()
    {
        _PauseMenuCanvas.SetActive(false);
        _OnButtonSound.SetActive(false);

    }

    #region Button Actions
    public void PauseGame()
    {
        _PauseMenuCanvas.SetActive(true);
        _mouseOnUi = true;
        Time.timeScale = 0;
        _AmbiantSound.SetActive(false);
    }

    public void ResumeGame()
    {
        _PauseMenuCanvas.SetActive(false);
        _AmbiantSound.SetActive(true);
        _mouseOnUi = false;
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
        _OnButtonSound.SetActive(true);
    }

    public void BackPause()
    {
        pauseImage.sprite = unselectPauseImage;
        _OnButtonSound.SetActive(false);
    }
    public void ChangeResume()
    {
        _PauseMenuSprite.sprite = selectResumeImage;
        _OnButtonSound.SetActive(true);
    }

    public void BackResume()
    {
        _PauseMenuSprite.sprite = unselectResumeImage;
        _OnButtonSound.SetActive(false);
    }


    public void ChangeQuit()
    {
        _PauseMenuSprite.sprite = selectQuitImage;
        _OnButtonSound.SetActive(true);
    }

    public void BackQuit()
    {
        _PauseMenuSprite.sprite = unselectQuitImage;
        _OnButtonSound.SetActive(false);
    }
    #endregion



}

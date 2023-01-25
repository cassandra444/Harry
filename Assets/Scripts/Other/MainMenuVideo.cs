using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MainMenuVideo : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private VideoPlayer m_videoPlayer;
    [SerializeField] private GameObject m_mainMenu;

    


    void Start()
    {
        //m_videoPlayer.playOnAwake = false;
        m_mainMenu.SetActive(false);
        m_videoPlayer.Play();
        StartCoroutine("PlayVideo");
    }

    private IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(2.75f);
       // Debug.LogError("End");
        //m_videoPlayer.Stop();
        m_mainMenu.SetActive(true);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private VideoPlayer m_videoPlayer;
    [SerializeField] private GameObject m_Sound;


    void Start()
    {
        m_videoPlayer.Play();
        m_Sound.SetActive(true);
        StartCoroutine("PlayVideo");
    }

    private IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(7f);

        SceneManager.LoadScene(2);
        //Debug.Log("Load scene");
    }
}

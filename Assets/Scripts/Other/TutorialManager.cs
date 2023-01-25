using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject m_tutoPage1;
    [SerializeField] private GameObject m_tutoPage2;
    [SerializeField] private GameObject m_tutoCanva;
    private bool m_tutoEnded;
    //[SerializeField] private GameObject m_tutoPage3;


    void Start()
    {
        m_tutoEnded = false;
        m_tutoCanva.SetActive(true);
        Time.timeScale = 0f;
        Page1();
    }

    void Page1()
    {
        m_tutoPage1.SetActive(true);
        m_tutoPage2.SetActive(false);
    }

    void Page2()
    {
        m_tutoPage2.SetActive(true);
        m_tutoPage1.SetActive(false);
        m_tutoEnded=true;

    }

    void PlayGame()
    {
        m_tutoCanva.SetActive(false);
        Time.timeScale = 1f;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_tutoEnded == false) Page2();
        else if (Input.GetKeyDown(KeyCode.Space) && m_tutoEnded == true) PlayGame();
        //Debug.Log("Space : " + m_tutoEnded);
    }
}

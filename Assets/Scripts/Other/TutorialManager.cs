using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject m_tutoPage1;
    [SerializeField] private GameObject m_tutoPage2;
    [SerializeField] private GameObject m_tutoCanva;
    [SerializeField] private GameObject _OnButtonSound1; 
    [SerializeField] private GameObject _OnButtonSound2;

    [Header("Next 1 Button")]
    public Image N1Image;
    public Sprite unselectN1Image;
    public Sprite selectN1Image;

    [Header("Next 2 Button")]
    public Image N2Image;
    public Sprite unselectN2Image;
    public Sprite selectN2Image;

    private bool m_tutoEnded;
    //[SerializeField] private GameObject m_tutoPage3;


    void Start()
    {
        m_tutoEnded = false;
        m_tutoCanva.SetActive(true);
        Time.timeScale = 0f;
        Page1();
    }

    public void Page1()
    {
        m_tutoPage1.SetActive(true);
        m_tutoPage2.SetActive(false);
    }

    public void Page2()
    {
        m_tutoPage2.SetActive(true);
        m_tutoPage1.SetActive(false);
        m_tutoEnded=true;

    }

   public void PlayGame()
    {
        m_tutoCanva.SetActive(false);
        Time.timeScale = 1f;

    }

    public void ChangeN1()
    {
       N1Image.sprite = selectN1Image;
        _OnButtonSound1.SetActive(true);
    }

    public void BackN1()
    {
        N1Image.sprite = unselectN1Image;
        _OnButtonSound1.SetActive(false);
    }

    public void ChangeN2()
    {
        N2Image.sprite = selectN2Image;
        _OnButtonSound2.SetActive(true);
    }

    public void BackN2()
    {
        N2Image.sprite = unselectN2Image;
        _OnButtonSound2.SetActive(false);
    }


   
}

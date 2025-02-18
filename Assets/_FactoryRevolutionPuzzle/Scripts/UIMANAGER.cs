using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMANAGER : MonoBehaviour
{
    public static UIMANAGER instance;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        EventsManager.Instance.OnWinPanel += ShowWinPanel;
        HideLosePanel();
        HideWinPanel();
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnWinPanel -= ShowWinPanel;
    }

    private void ShowWinPanel()
    {
        _winPanel.SetActive(true);
    }

    private void ShowLosePanel()
    {
        _losePanel.SetActive(true);
    }

    private void HideWinPanel()
    {
        _winPanel.SetActive(false);
    }

    private void HideLosePanel()
    {
        _losePanel.SetActive(false);
    }
}

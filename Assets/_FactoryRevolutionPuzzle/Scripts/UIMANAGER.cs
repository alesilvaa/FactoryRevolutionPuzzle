using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIMANAGER : MonoBehaviour
{
    public static UIMANAGER instance;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private TextMeshProUGUI _attempsText;
    [SerializeField] private int _attemps = 20;
    
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
        EventsManager.Instance.OnLosePanel += ShowLosePanel;
        EventsManager.Instance.OnTapConveyor += DecreaseAttemps;
        HideLosePanel();
        HideWinPanel();
        _attempsText.text = _attemps.ToString();
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnWinPanel -= ShowWinPanel;
        EventsManager.Instance.OnLosePanel -= ShowLosePanel;
        EventsManager.Instance.OnTapConveyor -= DecreaseAttemps;
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

    private void DecreaseAttemps()
    {
        _attemps -= 1;
        if (_attemps <= 0)
        {
            EventsManager.Instance.LosePanel();
        }
        _attempsText.text = _attemps.ToString();
    }
}

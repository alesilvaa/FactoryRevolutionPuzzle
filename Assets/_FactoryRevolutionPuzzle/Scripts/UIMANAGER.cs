using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIMANAGER : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private TextMeshProUGUI _attempsText;
    [SerializeField] private int _attemps = 20;
    [Header("Conveyor belt Controller")]
    [SerializeField] private ConveyorController _conveyorController;
    public bool hasWon = false;
    public bool hasLost = false;
    
    
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
        if (!hasLost)
        {
            hasWon = true;
            _winPanel.SetActive(true);
            _winPanel.GetComponent<UiWinLose>().ShowWinLoseUI();
            StopTapConveyor();
        }
    }

    private void ShowLosePanel()
    {
        if (!hasWon)
        {
            hasLost = true;
            _losePanel.SetActive(true);
            _losePanel.GetComponent<UiWinLose>().ShowWinLoseUI();
            StopTapConveyor();
        }
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


    public void NextLevel()
    {
        GameManager.Instance.NextLevel();
        HideWinPanel();
    }

    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
        HideLosePanel();
    }

    private void StopTapConveyor()
    {
        _conveyorController.StopTapConveyor();
    }
}

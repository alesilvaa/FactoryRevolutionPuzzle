using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    private static EventsManager instance;
    
    public static EventsManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("EventsManager");
                instance = go.AddComponent<EventsManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }
    
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

    public event Action OnAllBoxesInTruck;
    public event Action<float> OnIsCorrectRadius;
    public event Action OnWinPanel;
    public event Action OnLosePanel;


    public void AllBoxesInTruck()
    {
        OnAllBoxesInTruck?.Invoke();
    }

    public void IsCorrectRadius(float radius)
    {
        OnIsCorrectRadius?.Invoke(radius);
    }
    
    public void WinPanel()
    {
        OnWinPanel?.Invoke();
    }
    
    public void LosePanel()
    {
        OnLosePanel?.Invoke();
    }
   
}
using System;
using UnityEngine;

public class FirstDayGameStateManager : GameStateManager<FirstDayGameState>
{
    public static FirstDayGameStateManager Instance { get; private set; }
    [SerializeField] private GameObject mainRoom;
    [SerializeField] private GameObject clinic;
    [SerializeField] private GameObject office;

    public override void SetCurrentState(FirstDayGameState newState)
    {
        base.SetCurrentState(newState);
        switch (CurrentState)
        {
            case FirstDayGameState.MainRoom:
                mainRoom.SetActive(true);
                clinic.SetActive(false);
                office.SetActive(false);
                break;
            case FirstDayGameState.Clinic:
                mainRoom.SetActive(false);
                clinic.SetActive(true);
                office.SetActive(false);
                break;
            case FirstDayGameState.Office:
                mainRoom.SetActive(false);
                clinic.SetActive(false);
                office.SetActive(true);
                break;
        }
        
    }
    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
        SetCurrentState(FirstDayGameState.MainRoom);
    }
    
    
}

public enum FirstDayGameState
{
    MainRoom,
    Clinic,
    Office
}
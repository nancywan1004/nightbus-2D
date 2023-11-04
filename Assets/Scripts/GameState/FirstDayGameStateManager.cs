using System;
using UnityEngine;

public class FirstDayGameStateManager : GameStateManager<FirstDayGameState>
{
    public static FirstDayGameStateManager Instance { get; private set; }
    [SerializeField] private GameObject mainRoom;
    [SerializeField] private GameObject clinic;
    [SerializeField] private GameObject office;
    [SerializeField] private DialogueTrigger dialogueTrigger;

    public void HandleDialogueFinishedEvent(int index)
    {
        switch (index)
        {
            case 3:
                SetCurrentState(FirstDayGameState.Office);
                break;
        }
    }
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
        dialogueTrigger.OnDialogueFinished += HandleDialogueFinishedEvent;
    }

    private void OnDestroy()
    {
        dialogueTrigger.OnDialogueFinished -= HandleDialogueFinishedEvent;
    }
}

public enum FirstDayGameState
{
    MainRoom,
    Clinic,
    Office
}
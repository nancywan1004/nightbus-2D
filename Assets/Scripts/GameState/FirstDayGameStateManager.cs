using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class FirstDayGameStateManager : GameStateManager<FirstDayGameState>
{
    public static FirstDayGameStateManager Instance { get; private set; }
    [SerializeField] private GameObject mainRoom;
    [SerializeField] private GameObject clinic;
    [SerializeField] private GameObject office;
    [SerializeField] private GameObject transition;
    [SerializeField] private DialogueTrigger dialogueTrigger;

    public void HandleDialogueFinishedEvent(int index)
    {
        switch (index)
        {
            case 3:
                StartCoroutine(SwitchRoom(FirstDayGameState.Office));
                break;
        }
    }

    private IEnumerator SwitchRoom(FirstDayGameState newGameState)
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        transition.SetActive(false);
        SetCurrentState(newGameState);
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
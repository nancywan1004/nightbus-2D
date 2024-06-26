using System.Collections;
using Dialogue;
using UnityEngine;

namespace GameState
{
    public class FirstDayGameStateManager : GameStateManager<FirstDayGameState>
    {
        public static FirstDayGameStateManager Instance { get; private set; }
        [SerializeField] private GameObject mainRoom;
        [SerializeField] private GameObject clinic;
        [SerializeField] private GameObject office;
        [SerializeField] private GameObject transition;
        [SerializeField] private DialogueTrigger dialogueTrigger;
        [SerializeField] private TextAsset officeOpeningInkJson;

        public void HandleDialogueFinishedEvent(int index)
        {
            switch (index)
            {
                case 2:
                    StartCoroutine(SwitchRoom(FirstDayGameState.Office));
                    break;
            }
        }

        private IEnumerator SwitchRoom(FirstDayGameState newGameState)
        {
            if (newGameState is FirstDayGameState.Office)
            {
                transition.SetActive(true);
                yield return new WaitForSeconds(2.0f);
                transition.SetActive(false);
            }
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
                    dialogueTrigger.UpdateDialogueJson(officeOpeningInkJson);
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
}

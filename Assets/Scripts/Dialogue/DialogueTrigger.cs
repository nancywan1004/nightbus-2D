using System;
using Ink.Runtime;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public Action<int> OnDialogueFinished;

    private bool playerInRange;
    private bool isDialogueFinished = false;
    private Story _currentStory;

    public void UpdateDialogueJson(TextAsset newInkJson)
    {
        inkJSON = newInkJson;
        isDialogueFinished = false;
    }

    private void SetCurrentStory(Story story)
    {
        _currentStory = story;
    }

    private void SetStoryFinished(Story story)
    {
        if (_currentStory == story)
        {
            isDialogueFinished = true;
            DialogueManager.Instance.OnStoryStarted -= SetCurrentStory;
            DialogueManager.Instance.OnStoryEnded -= SetStoryFinished;
            OnDialogueFinished?.Invoke((int)_currentStory.variablesState["dialogueIndex"]);
        }
    }

    private void Update() 
    {
        if (inkJSON != null &&
            !isDialogueFinished &&
            !DialogueManager.Instance.dialogueIsPlaying) 
        {
            DialogueManager.Instance.OnStoryStarted += SetCurrentStory;
            DialogueManager.Instance.OnStoryEnded += SetStoryFinished;
            DialogueManager.Instance.EnterDialogueMode(inkJSON);
        }
    }
}
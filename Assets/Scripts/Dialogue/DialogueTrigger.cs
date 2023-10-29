using Ink.Runtime;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;
    private bool isDialogueFinished = false;
    private Story _currentStory;

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
        }
    }

    private void Update() 
    {
        if (
            !isDialogueFinished &&
            !DialogueManager.Instance.dialogueIsPlaying) 
        {
            DialogueManager.Instance.OnStoryStarted += SetCurrentStory;
            DialogueManager.Instance.OnStoryEnded += SetStoryFinished;
            DialogueManager.Instance.EnterDialogueMode(inkJSON);
        }
    }
}
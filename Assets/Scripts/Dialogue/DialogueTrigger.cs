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
            DialogueManager.GetInstance().OnStoryStarted -= SetCurrentStory;
            DialogueManager.GetInstance().OnStoryEnded -= SetStoryFinished;
        }
    }

    private void Update() 
    {
        if (
            !isDialogueFinished &&
            !DialogueManager.GetInstance().dialogueIsPlaying) 
        {
            DialogueManager.GetInstance().OnStoryStarted += SetCurrentStory;
            DialogueManager.GetInstance().OnStoryEnded += SetStoryFinished;
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }
}
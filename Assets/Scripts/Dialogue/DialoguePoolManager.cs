using System.Collections.Generic;
using Dialogue.UI;
using UnityEngine;

namespace Dialogue
{
    public class DialoguePoolManager : MonoBehaviour
    {
        [SerializeField] private List<DialogueBox> dialogueBoxes;
        private int _maxPoolSize = 0;
        private int _currentPoolIndex = 0;
    
        private void Awake()
        {
            _maxPoolSize = dialogueBoxes.Count;
        }
    
        public DialogueBox TryRetrieveDialogueBox()
        {
            DialogueBox box = null;
            if (_currentPoolIndex < _maxPoolSize-1)
            {
                if (_currentPoolIndex == 0)
                {
                    box = dialogueBoxes[_currentPoolIndex];
                    _currentPoolIndex++;
    
                }
                else
                {
                    _currentPoolIndex++;
                    box = dialogueBoxes[_currentPoolIndex];
                }
                box.gameObject.SetActive(true);
                return box;
            }
            else
            {
                box = dialogueBoxes[0];
                box.gameObject.SetActive(false);
                dialogueBoxes.RemoveAt(0);
                dialogueBoxes.Add(box);
                box.gameObject.SetActive(true);
                _currentPoolIndex = 0;
                return box;
            }
        }
    
        public DialogueBox GetCurrentDialogueBox()
        {
            return dialogueBoxes[_currentPoolIndex];
        }
    
        public void ClearPool()
        {
            foreach (var box in dialogueBoxes)
            {
                box.DialogueText.text = "";
                box.gameObject.SetActive(false);
            }
        }
    }

}

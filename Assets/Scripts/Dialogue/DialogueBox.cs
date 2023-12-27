using TMPro;
using UnityEngine;

namespace Dialogue.UI
{
    public class DialogueBox : MonoBehaviour
    {
        public TMP_Text DialogueText => GetComponentInChildren<TMP_Text>();
    }
}
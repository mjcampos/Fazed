using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "DialogueScriptableObject", menuName = "Scriptable Objects/DialogueScriptableObject")]
    public class DialogueScriptableObject : ScriptableObject
    {
        [TextArea(3, 10)]
        [SerializeField] string dialogueText;
        
        public string DialogueText => dialogueText;
    }
}

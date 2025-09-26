using System;
using System.Collections;
using Helpers;
using Singletons;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TypeWriterEffect : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI dialogueText;
        [SerializeField] DialogueScriptableObject[] dialogueLines;
        [SerializeField] float delayBeforeConversation = 0.05f;
        [SerializeField] float letterDelay = 0.05f;
        [SerializeField] float delayBetweenLines = 1f;

        void Start()
        {
            StartCoroutine(PlayDialogue());
        }

        IEnumerator PlayDialogue()
        {
            yield return new WaitForSeconds(delayBeforeConversation);
 
            foreach (DialogueScriptableObject line in dialogueLines)
            {
                string text = line.DialogueText;

                yield return StartCoroutine(TypeLine(text));
                yield return new WaitForSeconds(delayBetweenLines);
            }
            
            SwitchToPlayerCamera();
        }
        
        IEnumerator TypeLine(string text)
        {
            dialogueText.text = "";

            foreach (char c in text)
            {
                dialogueText.text += c;
                yield return new WaitForSeconds(letterDelay);
            }
        }

        void SwitchToPlayerCamera()
        {
            CameraManager.Instance.SetActiveCamera(Cameras.playerFollowCamera);
            Destroy(gameObject);
        }
    }
}

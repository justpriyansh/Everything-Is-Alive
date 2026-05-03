using UnityEngine;

public class Interactable : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] dialogue;

    public bool isSatisfied = false;
    public AudioClip interactClip;

    public float interactDistance = 5f; // distance for interaction


    public virtual void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
         if (interactClip != null)
        {
            AudioSource.PlayClipAtPoint(interactClip, transform.position, 1f);
        }

        if (DialogueManager.instance == null)
        {
            Debug.LogError("DialogueManager missing in scene!");
            return;
        }

        if (DialogueManager.instance.IsActive())
            return;

        if (dialogue != null && dialogue.Length > 0)
        {
            DialogueManager.instance.ShowDialogue(dialogue);
        }
        else
        {
            Debug.LogWarning("No dialogue assigned to " + gameObject.name);
        }
    }
}
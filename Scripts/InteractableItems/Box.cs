using UnityEngine;

public class Box : Interactable
{
    public string[] needCutterDialogue;
    public string[] openedDialogue;

    public override void Interact()
    {
        Debug.Log("Box Interacted");

        // Already opened
        if (isSatisfied)
        {
            DialogueManager.instance.ShowDialogue(openedDialogue);
            return;
        }

        // Has cutter → open box
        if (PlayerInventory.instance.hasCutter)
        {
            Debug.Log("Box opened with cutter");

            PlayerInventory.instance.hasCutter = false;

            isSatisfied = true;
            GameManager.instance.boxDone = true;

            DialogueManager.instance.ShowDialogue(openedDialogue);

            // Optional: play animation here
        }
        else
        {
            Debug.Log("No cutter");

            DialogueManager.instance.ShowDialogue(needCutterDialogue);
        }
    }
}
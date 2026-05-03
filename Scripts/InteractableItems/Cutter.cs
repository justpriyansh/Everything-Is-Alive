using UnityEngine;

public class Cutter : Interactable
{
    public override void Interact()
    {
        Debug.Log("Cutter picked");

        PlayerInventory.instance.hasCutter = true;

        DialogueManager.instance.ShowDialogue(new string[]
        {
            "You picked up a cutter."
        });

        gameObject.SetActive(false);
    }
}
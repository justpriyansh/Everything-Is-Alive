using UnityEngine;

public class Battery :Interactable
{
    public override void Interact()
    {
        if (!PlayerInventory.instance.hasBattery)
        {
            PlayerInventory.instance.hasBattery = true;

            DialogueManager.instance.ShowDialogue(new string[]
            {
                "You picked up a battery."
            });

            gameObject.SetActive(false); // remove from scene
        }
    }
}

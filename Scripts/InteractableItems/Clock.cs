using UnityEngine;

public class Clock : Interactable
{
    public string[] needBatteryDialogue;
    public string[] completedDialogue;

    public override void Interact()
    {

        Debug.Log("Clock Interacted"); 

        if (PlayerInventory.instance == null)
        {
            Debug.LogError("Inventory missing!");
            return;
        }
        // If already fixed
        if (isSatisfied)
        {
            DialogueManager.instance.ShowDialogue(completedDialogue);
            return;
        }

        // Player has battery
        if (PlayerInventory.instance.hasBattery == true)
        {
            Debug.Log("Battery accepted!");
           // PlayerInventory.instance.hasBattery = false;

            isSatisfied = true;
            GameManager.instance.clockDone = true;

            DialogueManager.instance.ShowDialogue(completedDialogue);
        }
        else
        {
            DialogueManager.instance.ShowDialogue(needBatteryDialogue);
        }
    }
}
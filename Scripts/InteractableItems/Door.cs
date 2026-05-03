using UnityEngine;

public class Door : Interactable
{
    public bool unlocked = false;

    public override void Interact()
    {
        Debug.Log("Door Interacted");

        bool clock = GameManager.instance.clockDone;
        bool box = GameManager.instance.boxDone;
        bool chair = GameManager.instance.chairDone;

        // 🔍 DEBUG (very important)
        Debug.Log("Clock: " + clock + " | Box: " + box + " | Chair: " + chair);

        // ✅ ALL COMPLETED
        if (clock && box && chair)
        {
            if (!unlocked)
            {
                unlocked = true;

                DialogueManager.instance.ShowDialogue(new string[]
                {
                    "Door: ...",
                    "Door: The room is satisfied.",
                    "Door: You may leave."
                });

                Invoke(nameof(OpenDoor), 1.5f); // delay feels better
            }
            else
            {
                // Already unlocked → just open
                OpenDoor();
            }
        }
        else
        {
            ShowLockedDialogue(clock, box, chair);
        }
    }

    void ShowLockedDialogue(bool clock, bool box, bool chair)
    {
        // ❗ Show ALL missing tasks instead of just one
        string message = "Door:";

        if (!clock) message += "\n- Time is broken.";
        if (!box) message += "\n- Something remains unopened.";
        if (!chair) message += "\n- You lack focus.";

        DialogueManager.instance.ShowDialogue(new string[]
        {
            message
        });
    }

    void OpenDoor()
    {
        Debug.Log("YOU ESCAPED!");

        transform.Rotate(0, 90, 0);

        // Optional win trigger
        if (GameManager.instance != null)
        {
            GameManager.instance.WinGame();
        }
    }
}
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            DialogueManager.instance.ShowDialogue(new string[]
            {
                "Hello Player!",
                "This is a test dialogue.",
                "Everything is working."
            });
        }
    }
}
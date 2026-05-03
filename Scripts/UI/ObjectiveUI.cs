using UnityEngine;
using TMPro;

public class ObjectiveUI : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;

    void Update()
    {
        if (GameManager.instance == null) return;

        string text = "Objectives:\n";

        text += GameManager.instance.gameWon 
            ? "✔ Escape the door" 
            : "✖ Escape the door";

        objectiveText.text = text;
    }
}
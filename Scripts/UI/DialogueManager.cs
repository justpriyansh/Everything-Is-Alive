using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [Header("UI")]
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;

    [Header("Settings")]
    public float typingSpeed = 0.03f;

    string[] currentLines;
    int currentIndex;
    Coroutine typingCoroutine;
    bool isTyping = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            NextLine();
        }
    }

    // Start dialogue
    public void ShowDialogue(string[] lines)
    {
        currentLines = lines;
        currentIndex = 0;

        dialoguePanel.SetActive(true);
        StartTyping();
    }

    void StartTyping()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeLine(currentLines[currentIndex]));
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void NextLine()
    {
        // Skip typing instantly
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = currentLines[currentIndex];
            isTyping = false;
            return;
        }

        currentIndex++;

        if (currentIndex < currentLines.Length)
        {
            StartTyping();
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }

    public bool IsActive()
    {
        return dialoguePanel.activeSelf;
    }
}
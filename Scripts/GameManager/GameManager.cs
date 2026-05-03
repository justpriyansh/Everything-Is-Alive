using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameWon = false;

    public bool chairDone;
    public bool clockDone;
    public bool boxDone;

    [Header("UI")]
    public GameObject winPanel;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public bool AreAllTasksDone()
    {
        return chairDone && clockDone && boxDone;
    }

    public void WinGame()
{
    Debug.Log("GAME WON!");

    gameWon = true;

    if (winPanel != null)
        winPanel.SetActive(true);

    Time.timeScale = 0f;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}
}
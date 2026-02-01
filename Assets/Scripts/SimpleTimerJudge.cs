using UnityEngine;
using TMPro;


public class SimpleTimerJudge : MonoBehaviour
{
    public float timeLimit = 60f;
    private float timer;
    public TMP_Text timerText;
    private bool ended = false;

    // Drag the X objects here
    public GameObject crossOutA;
    public GameObject crossOutB;
    public GameObject crossOutC;

    // Panels
    public GameObject winPanel;
    public GameObject losePanel;

    // Set this in Inspector: A, B, or C
    public string correctSuspect = "B";

    void Start()
    {
        timer = timeLimit;

        if (winPanel) winPanel.SetActive(false);
        if (losePanel) losePanel.SetActive(false);
    }

    void Update()
    {
        if (ended) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            ended = true;
            Judge();
        }

        if (timerText != null)
            timerText.text = "Time: " + (int)timer;
    }

    void Judge()
    {
        int remaining = 0;
        string last = "";

        if (!crossOutA.activeSelf) { remaining++; last = "A"; }
        if (!crossOutB.activeSelf) { remaining++; last = "B"; }
        if (!crossOutC.activeSelf) { remaining++; last = "C"; }

        bool win = (remaining == 1 && last == correctSuspect);

        if (win)
            winPanel.SetActive(true);
        else
            losePanel.SetActive(true);
    }
    public void PlayAgain()
    {
        // Reset timer
        timer = timeLimit;
        ended = false;

        // Turn OFF all Xs
        crossOutA.SetActive(false);
        crossOutB.SetActive(false);
        crossOutC.SetActive(false);

        // Hide panels
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }
}
//     void Judge()
//     {
//         int remaining = 0;
//         string last = "";
//
//         if (!crossOutA.activeSelf) { remaining++; last = "A"; }
//         if (!crossOutB.activeSelf) { remaining++; last = "B"; }
//         if (!crossOutC.activeSelf) { remaining++; last = "C"; }
//
//         if (remaining == 1 && last == correctSuspect)
//         {
//             SceneManager.LoadScene("WinScene");
//         }
//         else
//         {
//             SceneManager.LoadScene("LoseScene");
//         }
//     }
// }
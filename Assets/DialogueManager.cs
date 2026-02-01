using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public GameObject promptText;

    [Header("Optional")]
    public MonoBehaviour playerMovementScript; // drag your movement script here to disable it while talking

    private WitnessDialogue currentWitness;

    void Start()
    {
        if (dialoguePanel != null) dialoguePanel.SetActive(false);
        if (promptText != null) promptText.SetActive(false);
    }

    public bool IsAnyDialogueOpen()
    {
        return currentWitness != null && dialoguePanel != null && dialoguePanel.activeSelf;
    }

    public bool IsOpenFor(WitnessDialogue witness)
    {
        return currentWitness == witness && dialoguePanel != null && dialoguePanel.activeSelf;
    }

    public void ShowPrompt(bool show)
    {
        if (promptText != null) promptText.SetActive(show);
    }

    public void OpenDialogue(WitnessDialogue witness, string line)
    {
        // Close whoever was open before
        if (currentWitness != null && currentWitness != witness)
            currentWitness.ForceClose();

        currentWitness = witness;

        if (dialoguePanel != null) dialoguePanel.SetActive(true);
        if (promptText != null) promptText.SetActive(false);
        if (dialogueText != null) dialogueText.text = line;

        // Optional: freeze movement while talking
        if (playerMovementScript != null) playerMovementScript.enabled = false;
    }

    public void CloseDialogue(WitnessDialogue witness)
    {
        // Only close if the one asking is the active witness
        if (currentWitness != witness) return;

        if (dialoguePanel != null) dialoguePanel.SetActive(false);
        currentWitness = null;

        // Optional: re-enable movement
        if (playerMovementScript != null) playerMovementScript.enabled = true;
    }

    // Optional convenience: close from elsewhere (like elimination/win)
    public void ForceCloseAny()
    {
        if (currentWitness != null)
        {
            currentWitness.ForceClose();
            currentWitness = null;
        }
        if (dialoguePanel != null) dialoguePanel.SetActive(false);
        if (promptText != null) promptText.SetActive(false);
        if (playerMovementScript != null) playerMovementScript.enabled = true;
    }
}

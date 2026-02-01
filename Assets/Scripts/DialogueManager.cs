using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    // public TMP_Text promptText;

    private WitnessDialogue currentWitness;

    private PlayerScript playerScript;
    void Start()
    {
        if (dialoguePanel != null) dialoguePanel.SetActive(false);
        // if (promptText != null) promptText.gameObject.SetActive(false);

        
    }

    // ===== PROMPT =====
    // public void SetPrompt(string text)
    // {
    //     if (promptText == null) return;
    //
    //     promptText.gameObject.SetActive(true);
    //     promptText.text = text;
    // }

    // public void HidePrompt()
    // {
    //     if (promptText == null) return;
    //     promptText.gameObject.SetActive(false);
    // }

    // ===== DIALOGUE =====
    public void OpenDialogue(WitnessDialogue witness, string line)
    {
        // close previous witness if needed
        if (currentWitness != null && currentWitness != witness)
            currentWitness.ForceClose();

        currentWitness = witness;

        if (dialoguePanel != null) dialoguePanel.SetActive(true);
        if (dialogueText != null) dialogueText.text = line;

        // SetPrompt("Press E to close");
    }

    public void CloseDialogue(WitnessDialogue witness)
    {
        if (currentWitness != witness) return;

        if (dialoguePanel != null) dialoguePanel.SetActive(false);
        currentWitness = null;
    }

    public bool IsOpenFor(WitnessDialogue witness)
    {
        return currentWitness == witness && dialoguePanel.activeSelf;
    }

    public bool IsAnyDialogueOpen()
    {
        return currentWitness != null && dialoguePanel.activeSelf;
    }
}


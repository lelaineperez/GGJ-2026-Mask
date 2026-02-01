using UnityEngine;

public class WitnessDialogue : MonoBehaviour
{
    [TextArea(2, 6)]
    public string witnessLine = "I saw someone run toward the alley!";

    public DialogueManager dialogueManager;

    private bool playerInRange;

    void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Toggle: if this witness is open, close it; otherwise open it
            if (dialogueManager.IsOpenFor(this))
            {
                dialogueManager.CloseDialogue(this);
                dialogueManager.ShowPrompt(true); // show prompt again if still in range
            }
            else
            {
                dialogueManager.OpenDialogue(this, witnessLine);
            }
        }
    }

    public void ForceClose()
    {
        dialogueManager.CloseDialogue(this);

        // If player is still nearby, the prompt can show again
        if (playerInRange && !dialogueManager.IsAnyDialogueOpen())
            dialogueManager.ShowPrompt(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;

        // Only show prompt if no one else is currently talking
        if (!dialogueManager.IsAnyDialogueOpen())
            dialogueManager.ShowPrompt(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = false;
        dialogueManager.ShowPrompt(false);

        // If this witness was talking, close it
        dialogueManager.CloseDialogue(this);
    }
}


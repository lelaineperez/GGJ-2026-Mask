using UnityEngine;

public class WitnessDialogue : MonoBehaviour
{
    [TextArea(2, 6)]
    public string witnessLine = "I saw someone run toward the alley.";

    public DialogueManager dialogueManager;

    [Header("Optional visuals")]
    public GameObject promptIcon; // dots above head (optional)
    public SpriteRenderer witnessSprite;
    public Color talkedColor = new Color(0.6f, 0.6f, 0.6f, 1f);

    private bool playerInRange;
    private bool hasTalked;

    void Awake()
    {
        if (dialogueManager == null)
            dialogueManager = FindObjectOfType<DialogueManager>();

        if (witnessSprite == null)
            witnessSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // CLOSE if this witness is already open
            if (dialogueManager.IsOpenFor(this))
            {
                dialogueManager.CloseDialogue(this);
                dialogueManager.SetPrompt("Press E to talk");

                if (promptIcon != null)
                    promptIcon.SetActive(true);
            }
            // OPEN
            else
            {
                dialogueManager.OpenDialogue(this, witnessLine);

                if (!hasTalked)
                {
                    hasTalked = true;
                    if (witnessSprite != null)
                        witnessSprite.color = talkedColor;
                }

                if (promptIcon != null)
                    promptIcon.SetActive(false);
            }
        }
    }

    public void ForceClose()
    {
        dialogueManager.CloseDialogue(this);

        if (playerInRange && !dialogueManager.IsAnyDialogueOpen())
        {
            dialogueManager.SetPrompt("Press E to talk");
            if (promptIcon != null)
                promptIcon.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;

        if (!dialogueManager.IsAnyDialogueOpen())
        {
            dialogueManager.SetPrompt("Press E to talk");
            if (promptIcon != null)
                promptIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = false;

        dialogueManager.HidePrompt();
        if (promptIcon != null)
            promptIcon.SetActive(false);

        dialogueManager.CloseDialogue(this);
    }
}



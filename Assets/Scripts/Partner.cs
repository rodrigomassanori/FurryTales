using UnityEngine;

public class Partner : MonoBehaviour
{
    public string[] Dialogue;

    public DialoguePartner DPartner;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player01"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartDialogue();
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player01"))
        {
            DPartner.enabled = false;

            DPartner.DialogueText.gameObject.SetActive(false);
        }
    }

    void StartDialogue()
    {
        FindObjectOfType<DialoguePartner>().StartDialogue(Dialogue);
    }
}
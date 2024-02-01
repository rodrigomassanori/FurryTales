using UnityEngine;

public class Partner : MonoBehaviour
{
    public string[] Dialogue;

    DialoguePartner DPartner;

    void Awake()
    {
        DPartner = GetComponent<DialoguePartner>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartDialogue();
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DPartner.enabled = false;
        }
    }

    void StartDialogue()
    {
        FindObjectOfType<DialoguePartner>().StartDialogue(Dialogue);
    }
}
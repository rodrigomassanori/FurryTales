using UnityEngine;

public class Partner : MonoBehaviour
{
    public string[] Dialogue;

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

    void StartDialogue()
    {
        FindObjectOfType<DialoguePartner>().StartDialogue(Dialogue);
    }
}
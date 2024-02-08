using UnityEngine;
using TMPro;

public class MissionController2 : MonoBehaviour
{
    public TextMeshProUGUI Mission3;

    KeyCode E = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(E))
        {
            if (Mission3.gameObject.CompareTag("Player"))
            {
                Mission3.enabled = true;

                Mission3.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyUp(E))
        {
            if (Mission3.gameObject.CompareTag("Player"))
            {
                Mission3.enabled = false;

                Mission3.gameObject.SetActive(false);
            }
        }
    }
}
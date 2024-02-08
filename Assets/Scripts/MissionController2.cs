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
            Mission3.enabled = true;

            Mission3.gameObject.SetActive(true);
        }

        if (Input.GetKeyUp(E))
        {
            Mission3.enabled = false;

            Mission3.gameObject.SetActive(false);
        }
    }
}
using UnityEngine;
using TMPro;
using System.Collections;

public class MissionController2 : MonoBehaviour
{
    public TextMeshProUGUI Mission3;

    void Start()
    {
        StartCoroutine(ShowQuest2());
    }

    IEnumerator ShowQuest2()
    {
        yield return new WaitForSeconds(15.0f);

        Mission3.enabled = true;

        Mission3.gameObject.SetActive(true);

        Mission3.text = "Find all three gears and after pick all of them, \n go to door on this floor, to leave it";

        yield return new WaitForSeconds(15.0f);

        Mission3.enabled = false;

        Mission3.gameObject.SetActive(false);
    }
}
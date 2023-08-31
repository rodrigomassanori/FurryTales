using System.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    readonly KeyCode e = KeyCode.E;

    public GameObject[] CherGear;

    void Update()
    {
        if (Input.GetKeyDown(e) && CherGear[0].name == "ChernobylGear"
        && CherGear[1].name == "ChernobylGear" && CherGear[2].name == "ChernobylGear")
        {
            StartCoroutine(CollectedGears());
        }
    }

    IEnumerator CollectedGears()
    {
        yield return new WaitForSeconds(4.0f);

        CherGear[0].SetActive(false);

        CherGear[1].SetActive(false);

        CherGear[2].SetActive(false);
    }
}
using System.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    readonly KeyCode e = KeyCode.E;

    public GameObject CherGear;

    void Update()
    {
        if (Input.GetKeyDown(e) && CherGear.name == "ChernobylGear")
        {
            StartCoroutine(CollectedGears());
        }
    }

    IEnumerator CollectedGears()
    {
        yield return new WaitForSeconds(4.0f);

        CherGear.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    readonly KeyCode e = KeyCode.E;

    public GameObject CherGear;

    List<GameObject> items;

    void Update()
    {
        if (Input.GetKeyDown(e) && CherGear.name == "ChernobylGear" && items.Count > 3)
        {
            StartCoroutine(CollectedGears());
        }
    }

    IEnumerator CollectedGears()
    {
        yield return new WaitForSeconds(4.0f);

        items.Remove(CherGear);

        //CherGear.SetActive(false);
    }
}
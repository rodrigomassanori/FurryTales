using UnityEngine;

public class Inventory : MonoBehaviour
{
    readonly KeyCode e = KeyCode.E;

    public GameObject CherGear;

    void Update()
    {
        if (Input.GetKeyDown(e) && CherGear.name == "ChernobylGear")
        {
            CherGear.SetActive(false);
        }
    }
}
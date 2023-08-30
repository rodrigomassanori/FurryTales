using UnityEngine;

public class Inventory : MonoBehaviour
{
    void OnCollisionEnter(Collision CherGear)
    {
        if (CherGear.gameObject.name == "ChernobylGear")
        {
            CherGear.gameObject.SetActive(false);
        }
    }
}
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "VHSEffectMaterialPointer", 
menuName = "VHS Effect/VHSEffectMaterialPointer")]
public class VHSEffectMaterialPointer : ScriptableObject
{
    public Material VHSEffectMaterial;

    static VHSEffectMaterialPointer Instance;

    public static VHSEffectMaterialPointer instance
    {
        get
        {
            if (Instance != null)
            {   
                return Instance;
            }

            Instance = Resources.Load("VHSEffectMaterialPointer") as VHSEffectMaterialPointer;
            
            return Instance;
        }
    }
}
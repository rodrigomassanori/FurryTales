using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "VHSEffectMaterialPointer", 
menuName = "VHS Effect/VHSEffectMaterialPointer")]
public class VHSEffectMaterialPointer : UnityEngine.ScriptableObject
{
    public Material VHSEffectMaterial;

    static VHSEffectMaterialPointer _instance;

    public static VHSEffectMaterialPointer Instance
    {
        get
        {
            if (_instance != null)
            {   
                return _instance;
            }

            _instance = Resources.Load("VHSEffectMaterialPointer") as VHSEffectMaterialPointer;
            
            return _instance;
        }
    }
}
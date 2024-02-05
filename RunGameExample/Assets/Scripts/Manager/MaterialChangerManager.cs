using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangerManager : MonoBehaviour
{
    public Material newMaterial; // 교체할 새로운 메터리얼
    public bool isChangeMaterial;

    void Awake()
    {
        if (isChangeMaterial)
        {
            ChangeMaterial();
        }
        
    }
    void ChangeMaterial()
    {
        // 렌더러 컴포넌트 가져오기
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in childRenderers)
        {
            // 새로운 메터리얼을 렌더러에 할당
            renderer.material = newMaterial;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangerManager : MonoBehaviour
{
    public Material newMaterial; // ��ü�� ���ο� ���͸���
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
        // ������ ������Ʈ ��������
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in childRenderers)
        {
            // ���ο� ���͸����� �������� �Ҵ�
            renderer.material = newMaterial;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    //Runner.cs���� ����...���������� ������ �� �ְ� ���⼭ ������
    //���ҽ� �Ŵ��� ����

    // ������ ��ο��� ���ҽ��� �ε��ϴ� ���׸� �޼���
    // ���׸� Ÿ�� T�� Object�� ����ϴ� Ÿ���̾�� ��
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    // ������ ��ο��� �������� �ε��ϰ� �ν��Ͻ��� �����ϴ� �޼���
    // �θ� Transform�� �������� ������ �⺻������ null�� ������
    public GameObject Create(string path, Transform parent = null)
    {
        // ������ ��ο��� �������� �ε�
        GameObject prefab = Resources.Load<GameObject>(path);

        // �ε尡 ������ ���
        if (prefab == null)
        {
            Debug.Log("Failed to Load Prefab :" + path);
            return null;
        }

        // �������� �����ϰ� �θ� Transform�� �߰��Ͽ� ������ ���� ������Ʈ ��ȯ
        return Instantiate(prefab, parent);
    }

    // ���� ������Ʈ�� �����ϴ� �޼���
    public void Release(GameObject prefab)
    {
        // ���ڷ� ���޵� ���� ������Ʈ�� null�� ��� �ƹ� �۾��� �������� ����
        if (prefab == null)
        {
            return;
        }

        // ���� ������Ʈ�� �ı��Ͽ� �޸𸮿��� ����
        Destroy(prefab);
    }
}


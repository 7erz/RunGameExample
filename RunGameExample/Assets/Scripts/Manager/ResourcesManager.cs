using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    //Runner.cs에서 참고...여러가지를 가져올 수 있게 여기서 정리함
    //리소스 매니저 생성

    // 지정된 경로에서 리소스를 로드하는 제네릭 메서드
    // 제네릭 타입 T는 Object를 상속하는 타입이어야 함
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    // 지정된 경로에서 프리팹을 로드하고 인스턴스를 생성하는 메서드
    // 부모 Transform이 지정되지 않으면 기본적으로 null로 설정됨
    public GameObject Create(string path, Transform parent = null)
    {
        // 지정된 경로에서 프리팹을 로드
        GameObject prefab = Resources.Load<GameObject>(path);

        // 로드가 실패한 경우
        if (prefab == null)
        {
            Debug.Log("Failed to Load Prefab :" + path);
            return null;
        }

        // 프리팹을 복제하고 부모 Transform에 추가하여 생성된 게임 오브젝트 반환
        return Instantiate(prefab, parent);
    }

    // 게임 오브젝트를 해제하는 메서드
    public void Release(GameObject prefab)
    {
        // 인자로 전달된 게임 오브젝트가 null인 경우 아무 작업도 수행하지 않음
        if (prefab == null)
        {
            return;
        }

        // 게임 오브젝트를 파괴하여 메모리에서 해제
        Destroy(prefab);
    }
}


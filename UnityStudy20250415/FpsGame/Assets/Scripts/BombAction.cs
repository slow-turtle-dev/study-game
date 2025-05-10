using UnityEngine;

public class BombAction : MonoBehaviour
{
    // 폭발 이펙트 프리팹 변수
    public GameObject bombEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 충돌했을 때의 처리
    private void OnCollisionEnter(Collision collision)
    {
        // 이펙트 프리팹을 생성한다.
        GameObject eff = Instantiate(bombEffect);

        // 이펙트 프리팹의 위치는 수류탄 오브젝트 자신의 위치와 동일하다.
        eff.transform.position = transform.position;

        // 이펙트 제거
        Destroy(eff, 0.5f);

        // 자기 자신을 제거한다.
        Destroy(gameObject);
    }
}

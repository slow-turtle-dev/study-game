using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 필요 속성: 이동 속도
    public float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 방향을 구한다.
        Vector3 dir = Vector3.up;

        // 2. 이동하고 싶다. 공식 P = PO + vt
        transform.position += dir * speed * Time.deltaTime;
    }
}

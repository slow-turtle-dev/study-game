using UnityEngine;

public class DestoryZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 영역 안에 다른 물체가 감지될 경우
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet") ||
            other.gameObject.name.Contains("Enemy")) {
            // 2. 부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);
        }
    }
}

using UnityEngine;

public class Background : MonoBehaviour
{
    // 배경 머티리얼
    public Material bgMaterial;
    // 스크롤 속도
    public float scrollSpeed = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // 1. 살아 있는 동안 계속 하고 싶다.
    void Update()
    {
        // 2. 방향이 필요하다
        Vector2 direction = Vector2.up;

        // 3. 스크롤하고 싶다. P = PO + vt
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}

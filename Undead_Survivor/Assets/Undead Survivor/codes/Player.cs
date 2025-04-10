using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;
    public Hand[] hands;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // inputVec.x = Input.GetAxis("Horizontal");
        // inputVec.y = Input.GetAxis("Vertical");
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>(true);
    }

    void FixedUpdate()
    {
        // // 1. 힘을 준다
        // rigid.AddForce(inputVec);

        // // 2. 속도 제어
        // rigid.linearVelocity = inputVec;

        // // 3. 위치 이동
        // rigid.MovePosition(rigid.position + inputVec);

        // Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        // rigid.MovePosition(rigid.position + nextVec);

        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        
        if (inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0;
        }
    }
}

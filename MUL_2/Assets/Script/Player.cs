using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 5.0f;
    public float rotateSpeed = 5.0f;
    public float jumpForce = 5.0f;
    bool isGround = true;
    
    public Rigidbody rigid;
    public Animator animator; 

    public float h, v;
    public int col = 0;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>(); //body object에 Rigidbody 넣기
    }

    // 이동 관련 함수 짤 때 Update 보다 FixedUpdate가 더 효율이 좋다고 함.
    void FixedUpdate()
    {
        Move();
        Jump();

        rigid = GetComponent<Rigidbody>();
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal"); //가로축, 부드러운 이동 위해 float 형 사용
        v = Input.GetAxisRaw("Vertical"); //세로축, 키보드 값 눌렀을 때 즉시 반응하기 위해 GetAxisRaw 사용

        Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0))
        {
            transform.position += dir * Speed * Time.deltaTime; //이동과 회전 같이 처리

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }

    }


    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGround) //스페이스 누르고 캐릭터 땅에 있으면
        {
            Debug.Log("add force");
            rigid.AddForce((Vector3.up * jumpForce), ForceMode.Impulse); //space누르면 jumpforce에 중력값(vector)만큼 더해져서 점프
            isGround = false;

        }
        if (Input.GetKey(KeyCode.Space))
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
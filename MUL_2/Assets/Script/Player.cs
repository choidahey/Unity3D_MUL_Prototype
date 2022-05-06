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
        rigid = GetComponent<Rigidbody>(); //body object�� Rigidbody �ֱ�
    }

    // �̵� ���� �Լ� © �� Update ���� FixedUpdate�� �� ȿ���� ���ٰ� ��.
    void FixedUpdate()
    {
        Move();
        Jump();

        rigid = GetComponent<Rigidbody>();
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal"); //������, �ε巯�� �̵� ���� float �� ���
        v = Input.GetAxisRaw("Vertical"); //������, Ű���� �� ������ �� ��� �����ϱ� ���� GetAxisRaw ���

        Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0))
        {
            transform.position += dir * Speed * Time.deltaTime; //�̵��� ȸ�� ���� ó��

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }

    }


    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGround) //�����̽� ������ ĳ���� ���� ������
        {
            Debug.Log("add force");
            rigid.AddForce((Vector3.up * jumpForce), ForceMode.Impulse); //space������ jumpforce�� �߷°�(vector)��ŭ �������� ����
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
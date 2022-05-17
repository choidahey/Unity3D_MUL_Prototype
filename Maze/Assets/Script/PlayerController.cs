using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController SelectPlayer; // ������ ĳ���� ��Ʈ�ѷ�
    public float Speed;  // �̵��ӵ�
    private float Gravity; // �߷�   
    private Vector3 MoveDir; // ĳ������ �����̴� ����.

    Rigidbody rigid;
    public bool isGround;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        // �⺻��
        Speed = 5.0f;
        Gravity = 10.0f;
        MoveDir = Vector3.zero;
        jumpForce = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        if (SelectPlayer == null) return;
        // ĳ���Ͱ� �ٴڿ� �پ� �ִ� ��츸 �۵��մϴ�.
        // ĳ���Ͱ� �ٴڿ� �پ� ���� �ʴٸ� �ٴ����� �߶��ϰ� �ִ� ���̹Ƿ�
        // �ٴ� �߶� ���߿��� ���� ��ȯ�� �� �� ���� �����Դϴ�.
        if (SelectPlayer.isGrounded)
        {
            // Ű���忡 ���� X, Z �� �̵������� ���� �����մϴ�.
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // ������Ʈ�� �ٶ󺸴� �չ������� �̵������� ������ �����մϴ�.
            MoveDir = SelectPlayer.transform.TransformDirection(MoveDir);
            // �ӵ��� ���ؼ� �����մϴ�.
            MoveDir *= Speed;

            // �����̽� ��ư�� ���� ����
            if (Input.GetButton("Jump")) MoveDir.y = jumpForce;
        }
        // ĳ���Ͱ� �ٴڿ� �پ� ���� �ʴٸ�
        else
        {
            // �߷��� ������ �޾� �Ʒ������� �ϰ��մϴ�.
            // �� �� �ٴڿ� ���� ������ -y���� ��� �������� ��ġ �߷°��ӵ� ���� ��ó�� �ۿ��մϴ�.
            MoveDir.y -= Gravity * Time.deltaTime;
        }
        // �� �ܰ������ ĳ���Ͱ� �̵��� ���⸸ �����Ͽ�����,
        // ���� ĳ������ �̵��� ���⼭ ����մϴ�.
        SelectPlayer.Move(MoveDir * Time.deltaTime);
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
}
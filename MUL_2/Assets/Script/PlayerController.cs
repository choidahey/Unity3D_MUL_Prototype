using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController SelectPlayer; // 제어할 캐릭터 컨트롤러
    public float Speed;  // 이동속도
    private float Gravity; // 중력   
    private Vector3 MoveDir; // 캐릭터의 움직이는 방향.

    Rigidbody rigid;
    public bool isGround;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        // 기본값
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
        // 캐릭터가 바닥에 붙어 있는 경우만 작동합니다.
        // 캐릭터가 바닥에 붙어 있지 않다면 바닥으로 추락하고 있는 중이므로
        // 바닥 추락 도중에는 방향 전환을 할 수 없기 때문입니다.
        if (SelectPlayer.isGrounded)
        {
            // 키보드에 따른 X, Z 축 이동방향을 새로 결정합니다.
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // 오브젝트가 바라보는 앞방향으로 이동방향을 돌려서 조정합니다.
            MoveDir = SelectPlayer.transform.TransformDirection(MoveDir);
            // 속도를 곱해서 적용합니다.
            MoveDir *= Speed;

            // 스페이스 버튼에 따른 점프
            if (Input.GetButton("Jump")) MoveDir.y = jumpForce;
        }
        // 캐릭터가 바닥에 붙어 있지 않다면
        else
        {
            // 중력의 영향을 받아 아래쪽으로 하강합니다.
            // 이 때 바닥에 닿을 떄까지 -y값이 계속 더해져서 마치 중력가속돠 붙은 것처럼 작용합니다.
            MoveDir.y -= Gravity * Time.deltaTime;
        }
        // 앞 단계까지는 캐릭터가 이동할 방향만 결정하였으며,
        // 실제 캐릭터의 이동은 여기서 담당합니다.
        SelectPlayer.Move(MoveDir * Time.deltaTime);
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
}
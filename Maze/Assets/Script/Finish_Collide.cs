using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_Collide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("FinishBlock"))  //finish block�� �����ϸ� �浹 ���� �� �� ��ȯ �Լ� ȣ��
        {
            ChangeScene();
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(0); //����â �����ʿ� �ִ� �� ��ȣ�� �̿��� �� ��ȯ
        //SceneManager.LoadScene("main");  //�� �̸����� �� ��ȯ
    }
}

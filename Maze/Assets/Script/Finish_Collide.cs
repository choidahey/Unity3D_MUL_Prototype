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
        if (collision.collider.CompareTag("FinishBlock"))  //finish block에 도달하면 충돌 감지 후 씬 전환 함수 호출
        {
            ChangeScene();
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(0); //빌드창 오른쪽에 있는 씬 번호를 이용해 씬 전환
        //SceneManager.LoadScene("main");  //씬 이름으로 씬 전환
    }
}

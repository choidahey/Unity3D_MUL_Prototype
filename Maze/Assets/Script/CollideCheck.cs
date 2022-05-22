using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("FinishBlock"))  //finish box에 도달하면 씬 변환
        {
            ChangeScene();
        }
    }
    public void ChangeScene()
    {
        //SceneManager.LoadScene(0); //build 창 오른쪽에 있는 번호로 씬 전환
        SceneManager.LoadScene("CharacterMoveScene");  //씬 이름으로 씬 전환
    }
}

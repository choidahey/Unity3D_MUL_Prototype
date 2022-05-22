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
        if (collision.collider.gameObject.CompareTag("FinishBlock"))  //finish box�� �����ϸ� �� ��ȯ
        {
            ChangeScene();
        }
    }
    public void ChangeScene()
    {
        //SceneManager.LoadScene(0); //build â �����ʿ� �ִ� ��ȣ�� �� ��ȯ
        SceneManager.LoadScene("CharacterMoveScene");  //�� �̸����� �� ��ȯ
    }
}

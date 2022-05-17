using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Controller : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //나중에 다시 수정하기
        if (Input.GetKey(KeyCode.W) == true)
        {
            animator.SetBool("isRun", true);
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            animator.SetBool("isRun", true);
        }
        else if (Input.GetKey(KeyCode.A) == true)
        {
            animator.SetBool("isRun", true);
        }
        else if (Input.GetKey(KeyCode.D) == true)
        {
            animator.SetBool("isRun", true);
        }
        //else
        //{
            //animator.SetBool("isRun", false);
            //animator.SetBool("isBack", false);
        //}

        if(Input.GetKeyUp(KeyCode.Space) == true)
        {
            animator.SetBool("isSpace", true);
        }

    }
}

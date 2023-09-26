using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnCollisionStay(Collision collision)
    {
        animator.SetBool("Down", true);
        Renderer render = GetComponent<Renderer>();
        render.material.color = Color.green;
        Debug.Log("��ư ����");
    }

    private void OnCollisionExit(Collision collision)
    {
        animator.SetBool("Down", false);
        Renderer render = GetComponent<Renderer>();
        render.material.color = Color.red;
        Debug.Log("��ư �ȴ���");
    }


}

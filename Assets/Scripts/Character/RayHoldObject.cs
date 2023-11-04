using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayHoldObject : MonoBehaviour
{
    public float distance = 2.0f;
    public string[] pickableTags = { "CloneOfClone","HoldableObject" };

    private GameObject pickedObject;
    private Rigidbody pickedObjectRb;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư�� Ŭ������ ��
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            int layerMask = ~LayerMask.GetMask("Glass"); // "Glass" ���̾ ������ ��� ���̾ �����ϴ� ���̾� ����ũ

            if (Physics.Raycast(ray, out hit, distance, layerMask))
            {
                //Debug.Log(hit.collider.gameObject.name);
                foreach (string tag in pickableTags)
                {
                    if (hit.collider.CompareTag(tag))
                    {
                        PickObject(hit.collider.gameObject);
                        break; // �±׸� ã�����Ƿ� �ݺ����� �������ɴϴ�.
                    }
                }
                if (hit.collider.CompareTag("Clone"))
                {

                    hit.collider.GetComponent<CopyCloneObject>().copyClone();
                    //PickObject(CopyCloneObject.cloneOfClone);
                    //offset = pickedObject.transform.position - hit.point;
                }
            }
            
        }
        if (pickedObject != null)
        {
            Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * distance;
            pickedObject.transform.position = Vector3.Lerp(pickedObject.transform.position, targetPosition, Time.deltaTime * 10);
        }


        if (Input.GetMouseButtonUp(0)) // ���콺 ���� ��ư�� ������ ��
        {
            DropObject();
        }
    }
    
    private void PickObject(GameObject obj)
    {
        pickedObject = obj;
        pickedObjectRb = obj.GetComponent<Rigidbody>();
        if (pickedObjectRb != null)
        {
            pickedObjectRb.isKinematic = true;
        }
    }

    private void DropObject()
    {
        if (pickedObjectRb != null)
        {
            pickedObjectRb.isKinematic = false;
            pickedObjectRb.velocity = Vector3.zero;
            pickedObjectRb.angularVelocity = Vector3.zero;
        }
        pickedObject = null;
        pickedObjectRb = null;
    }
   
}

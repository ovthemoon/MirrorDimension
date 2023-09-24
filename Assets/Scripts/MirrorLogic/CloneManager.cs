using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManager : MonoBehaviour
{
    public Transform mirrorSurface;
    public GameObject playerClonePrefab;

    private string targetLayerName = "StencilLayer1";
    private GameObject playerClone;
    private Vector3 mirrorNormal;
    private Dictionary<GameObject, GameObject> reflectedObjects=new Dictionary<GameObject, GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
       mirrorNormal = mirrorSurface.forward;
    }
    private void ClonePosition(Collider other,GameObject reflectedObj)
    {
        Vector3 directionToOriginal = other.transform.position - mirrorSurface.position;
        

        // ���� ���͸� �ſ��� ���� ���Ϳ� ���� �ݻ��ŵ�ϴ�.
        Vector3 reflectedDirection = Vector3.Reflect(directionToOriginal, mirrorNormal);

        // �ݻ�� ��ġ�� ����մϴ�.
        Vector3 reflectedPosition = mirrorSurface.position + reflectedDirection.normalized * directionToOriginal.magnitude;
        reflectedObj.transform.position = reflectedPosition;
    }
    private void CloneRotation(Collider other,GameObject reflectedObj)
    {
        Vector3 reflectedForward = Vector3.Reflect(other.transform.forward, mirrorNormal);
        Vector3 reflectedUp = Vector3.Reflect(other.transform.up, mirrorNormal);
        reflectedObj.transform.rotation = Quaternion.LookRotation(reflectedForward, reflectedUp);
    }
    public void ChangeLayer(GameObject other)
    {
        int layerIndex = LayerMask.NameToLayer(targetLayerName);

        if (layerIndex == -1) // ��ȿ�� ���̾� �̸����� Ȯ��
        {
            Debug.LogWarning("Layer " + targetLayerName + " does not exist!");
            return;
        }

        other.layer = layerIndex;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            playerClone = Instantiate(playerClonePrefab);
            ChangeLayer(playerClone);
        }
        else
        {
            GameObject cloneObject = Instantiate(other.gameObject);
            ChangeLayer(cloneObject);
            reflectedObjects[other.gameObject] = cloneObject;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (playerClone != null)
        {
            ClonePosition(other, playerClone);
            CloneRotation(other, playerClone);
        }
        if(reflectedObjects.TryGetValue(other.gameObject,out GameObject reflectedObj))
        {
            ClonePosition(other,reflectedObj);
            CloneRotation(other, reflectedObj);
            // �ſ� ǥ�����κ��� ��ü������ ���� ���� ���
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(playerClone);
        }
        if (reflectedObjects.TryGetValue(other.gameObject, out GameObject reflectedObj))
        {
            Destroy(reflectedObj);
            reflectedObjects.Remove(other.gameObject);
        }
    }
}

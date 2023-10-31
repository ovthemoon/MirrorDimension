using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MakeReflectionSurface : MonoBehaviour
{
    public GameObject mirrorPrefab;
    public GameObject collidEffect;
    public Vector3 offset = new Vector3(0, 1, 0);
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("MirrorableWall"))
        {
            // ��ü ����
            GameObject planeObject = Instantiate(mirrorPrefab, transform.position, Quaternion.identity);
            GameObject effect=Instantiate(collidEffect, transform.position+offset, Quaternion.identity);
            // ��ü ȸ��
            planeObject.transform.forward = collision.contacts[0].normal;
            effect.transform.forward = collision.contacts[0].normal;
            Destroy(effect, 1f);

        }
        Destroy(gameObject);
        if (collision.collider.CompareTag("Mirror"))
        {
            Destroy(collision.gameObject);

        }
        
    }
}



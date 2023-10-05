using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorEffectReflection : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        
        Vector3 quadGlobalNormal = GetGlobalNormal(this.transform);
        Debug.Log(quadGlobalNormal);
    }
    Vector3 GetGlobalNormal(Transform quadTransform)
    {
        // ���� �븻 ���� (Quad�� ���)
        Vector3 localNormal = this.transform.forward;

        // ���� �븻�� �۷ι� �븻�� ��ȯ
        Vector3 globalNormal = quadTransform.TransformDirection(localNormal);

        return globalNormal;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Effect"))
        {
            Vector3 normalCol = collision.contacts[0].normal;

        }
    }
}

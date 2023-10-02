using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRelfect : MonoBehaviour
{
    public float effectSpeed = 10f;
    public LayerMask mirrorLayer; // �ſ� ���̾ ���⿡ �����մϴ�.

    private Vector3 currentDirection;
    private Renderer effectRenderer;

    private void Start()
    {
        currentDirection = new Vector3(1,0,0); // �ʱ� ���� ����
        effectRenderer = GetComponent<Renderer>(); // ����Ʈ�� �������� �����ɴϴ�.
    }

    private void Update()
    {
        EffectReflection();
    }

    private void EffectReflection()
    {
        // ����Ʈ�� ���� �������� �̵�
        transform.position += currentDirection * effectSpeed * Time.deltaTime;

        // ����ĳ�����Ͽ� �ſ���� �������� ã���ϴ�.
        if (Physics.Raycast(transform.position, currentDirection, out RaycastHit hit, Mathf.Infinity, mirrorLayer))
        {
            // �ſ��� ǥ�� ������ ����Ͽ� �ݻ� ������ ����մϴ�.
            currentDirection = Vector3.Reflect(currentDirection, hit.normal);

            // �ſ��� ���� ���� ������ ����Ʈ�� ������ �����մϴ�.
            MirrorColor mirrorColorComponent = hit.collider.gameObject.GetComponent<MirrorColor>();
            if (mirrorColorComponent != null && effectRenderer != null)
            {
                effectRenderer.material.color = mirrorColorComponent.mirrorColor;
            }
        }
    }
}

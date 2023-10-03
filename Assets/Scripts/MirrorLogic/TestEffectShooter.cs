using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEffectShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // �߻��� ������Ʈ Ÿ��(��ü)
    public Transform spawnPoint;
    public float shootForce = 10f; // �߻�Ǵ� ��

    // Update�� �����Ӹ��� �� ���� ȣ��˴ϴ�
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire1�� �⺻������ ���콺 ���� ��ư�� �ǹ��մϴ�.
        {
            Debug.Log("Shoot");
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation); // ���� ��ġ�� ȸ������ ������Ʈ�� �����մϴ�.
        Destroy(projectile,2f);
        Rigidbody rb = projectile.GetComponent<Rigidbody>(); // Rigidbody ������Ʈ�� �����մϴ�.
        
        if (rb)
        {
            rb.AddForce(transform.up * shootForce, ForceMode.Impulse); // forward vector�� ����Ͽ� ��ü�� �߻��մϴ�.
        }
    }
}

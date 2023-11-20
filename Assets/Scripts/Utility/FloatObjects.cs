using UnityEngine;

public class FloatObjects : MonoBehaviour
{
    public Vector3 floatOffset = new Vector3(0, 2, 0);
    public float amplitude = 1f;
    public float floatSpeed = 1f;
    public float rotationSpeed = 50f; // ȸ�� �ӵ�

    private Vector3 startPosition;
    private Vector3 randomRotation;

    void Start()
    {
        startPosition = transform.position;
        randomRotation = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized; // ������ ȸ�� ������ �����մϴ�.
    }

    void Update()
    {
        // �յ� �ߴ� ȿ��
        float sinWave = Mathf.Sin(Time.time * floatSpeed) * amplitude;
        transform.position = startPosition + floatOffset * sinWave;

        // ���� ȸ��
        transform.Rotate(randomRotation, rotationSpeed * Time.deltaTime);
    }
}

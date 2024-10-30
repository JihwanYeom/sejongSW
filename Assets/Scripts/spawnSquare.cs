using UnityEngine;

public class spawnSquare : MonoBehaviour
{
    public GameObject shapePrefab; // ������ ���� ������
    private bool isDragging = false; // �巡�� ������ Ȯ��
    private Vector3 spawnPosition; // ������ ������ ��ġ

    void Start()
    {
        shapePrefab = Resources.Load<GameObject>("Units/Square");
    }

    void FixedUpdate()
    {
        // �巡�� ���� �� ���콺 ��ġ ������Ʈ
        if (isDragging)
        {
            spawnPosition = GetMouseWorldPosition();
            spawnPosition.y = 0; // Y ��ǥ�� 0���� ����
        }

        // ���콺 ���� ��ư�� ���� �巡�� ���� �� ���� ����
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            Instantiate(shapePrefab, spawnPosition, Quaternion.identity); // ������ ��ġ�� ���� ����
        }
    }

    private void OnMouseDown()
    {
        // ��ü�� Ŭ���Ǹ� �巡�� ����
        isDragging = true;
        spawnPosition = GetMouseWorldPosition();
        spawnPosition.y = 0; // Y ��ǥ�� 0���� ����
    }

    private void OnMouseUp()
    {
        // ���콺 ��ư�� ���� �巡�� ����
        if (isDragging)
        {
            isDragging = false;
            Instantiate(shapePrefab, spawnPosition, Quaternion.identity); // ������ ��ġ�� ���� ����
        }
    }

    // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ�ϴ� �޼���
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z); // Z �Ÿ� ����
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
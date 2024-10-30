using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public Transform hpBarTransform;
    
    public void Start()
    {
        hpBarTransform = gameObject.transform;
    }

    // ü�� ������ �����Ͽ� HP�� ũ�� ����
    public void SetHealth(float currentHealth, float maxHealth)
    {
        float hpRatio = currentHealth / maxHealth; // ü�� ���� ���
        hpBarTransform.localScale = new Vector3(hpRatio, 0.2f, 0); // X�� ũ�⸦ ü�� ������ �°� ����
    }
}

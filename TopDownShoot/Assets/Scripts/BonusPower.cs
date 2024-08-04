using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPower : MonoBehaviour
{
    public string bonusType; 

    void Start()
    {
        Destroy(gameObject, 5); //����������� ����� 5 ������
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.OnBonusPower(bonusType); //�������� ������
            Destroy(gameObject);
        }
    }
}

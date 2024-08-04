using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWeapon : MonoBehaviour
{
    public Weapon weapon; //��� ������    
    void Start()
    {
        Destroy(gameObject, 5);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.currentWeapon = weapon; //�������� ������ ������
            Destroy(gameObject);
        }
    }

}

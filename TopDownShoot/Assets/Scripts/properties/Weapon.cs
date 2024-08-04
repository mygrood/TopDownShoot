using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public int damage;
    public float fireRate;

    //��������
    public int shotBulletsCount;
    public float shotAngle; //����
    public float shotRange; // ���������

    //���������
    public float grenadeRadius; 
}


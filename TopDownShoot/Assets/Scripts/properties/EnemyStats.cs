using UnityEngine;

[CreateAssetMenu(menuName ="Enemy")]
public class EnemyStats :ScriptableObject
{
    public int HP; 
    public int Speed;
    public int Points; //���������� ����� �� ��������
    public int SpawnWeight; //���� ������
}

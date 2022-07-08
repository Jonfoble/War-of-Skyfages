using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Player Data", order = 0)]
public class PlayerData : ScriptableObject
{
    public int health;
    public int gold;
    public int exp;
}
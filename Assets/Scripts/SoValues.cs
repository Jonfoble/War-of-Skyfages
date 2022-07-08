using UnityEngine;

[CreateAssetMenu(fileName = "New Values", menuName = "Values", order = 0)]
public class SoValues : ScriptableObject
{
    public int health;
    public int damage;
    public int speed;
    public int range;
}
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public abstract void Attack(Player player);
}
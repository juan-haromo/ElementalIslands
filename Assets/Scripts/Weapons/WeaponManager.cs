using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [SerializeField] List<Weapon> weapons;

    public void Attack(int weaponID, Player player)
    {
        if(Mathf.Abs(weaponID) < weapons.Count)
        {
            weapons[weaponID].Attack(player);
        }
    }
}
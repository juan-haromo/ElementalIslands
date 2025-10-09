using UnityEngine;

public class Collectable : MonoBehaviour, IDamageable
{
    [SerializeField] int itemID;
    [SerializeField] int amount;
    public void Damage(GameObject damager)
    {
        if(damager.TryGetComponent<Inventory>(out Inventory inventory))
        {
            Debug.Log(name + " was damaged by " + damager);
            inventory.AddResource(itemID, amount);
            gameObject.SetActive(false);
        }
    }
}
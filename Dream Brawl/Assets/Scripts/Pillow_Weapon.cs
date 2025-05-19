using UnityEngine;

public class Pillow_Weapon : Weapon
{
    
    void Awake()
    {
        weaponName = "Pillow";
    }

    public override void Attack()
    {
        // Implement attack logic here
        Debug.Log("Pillow Attack!");
    }
}

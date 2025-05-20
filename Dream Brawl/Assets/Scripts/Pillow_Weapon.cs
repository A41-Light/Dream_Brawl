using UnityEngine;

public class Pillow_Weapon : Weapon
{
    public float attackRange = 1f;
    public

    void Awake()
    {
        weaponName = "Pillow";
    }

    public override void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // Apply damage to the enemy
                Debug.Log("Hit " + enemy.name + " with " + weaponName);
                // Add your damage logic here
            }
        }

    }
}

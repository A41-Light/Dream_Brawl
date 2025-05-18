using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    public List<GameObject> weapons_in_range = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (weapons_in_range.Count > 0)
            {
                float min_distance = Mathf.Infinity;
                GameObject closest_weapon = null;
                for (int i = 0; i < weapons_in_range.Count; i++)
                {
                    if (weapons_in_range[i] != null)
                    {
                        if (i == 0 || Vector2.Distance(transform.position, weapons_in_range[i].transform.position) < min_distance)
                        {
                            min_distance = Vector2.Distance(transform.position, weapons_in_range[i].transform.position);
                            closest_weapon = weapons_in_range[i];
                        }
                    }
                }
                if (closest_weapon != null)
                {
                    Hold_Weapon(closest_weapon);
                }
            }
        }
    }

    void Attack()
    {
        // Implement attack logic here
        Debug.Log("Attack!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Pickup Zone")
        {
            // Implement enemy hit logic here
            if (other.transform.parent != null)
            {
                weapons_in_range.Add(other.transform.parent.gameObject);
                Debug.Log("Picked :" + other.transform.parent.name);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Pickup Zone")
        {
            // Implement enemy hit logic here
            if (other.transform.parent != null)
            {
                weapons_in_range.Remove(other.transform.parent.gameObject);
                Debug.Log("Removed :" + other.transform.parent.name);
            }
        }
    }
    
    void Hold_Weapon(GameObject weapon)
    {
        Debug.Log("Eqiuped :" + weapon.name);
        weapons_in_range.Remove(weapon);
        GameObject held_weapon = Instantiate(weapon, transform.position, Quaternion.identity);
        held_weapon.transform.SetParent(transform, false);
        weapon.SetActive(false);
    }
}

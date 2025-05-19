using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    public List<GameObject> weapons_in_range = new List<GameObject>();

    private GameObject current_weapon = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (current_weapon != null)
            {
                current_weapon.GetComponent<Weapon>().Attack();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (current_weapon != null)
            {
                Drop_Weapon(current_weapon);
                UpdateText("Bare Hands");
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Pickup Zone")
        {
            // Implement enemy hit logic here
            if (other.transform.parent != null)
            {
                weapons_in_range.Add(other.transform.parent.gameObject);
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
            }
        }
    }

    void Hold_Weapon(GameObject weapon)
    {
        Debug.Log("Eqiuped :" + GetWeaponName(weapon));

        if (current_weapon != null)
        {
            Drop_Weapon(current_weapon);
        }

        current_weapon = weapon;
        UpdateText(GetWeaponName(current_weapon));
        weapons_in_range.Remove(weapon);
        weapon.transform.SetParent(transform, false);
        weapon.transform.localPosition = new Vector3(0, 0, 0);
    }

    void Drop_Weapon(GameObject weapon)
    {
        Debug.Log("Dropped :" + GetWeaponName(weapon));

        weapon.transform.SetParent(null, false);
        weapon.transform.position = transform.position;
        current_weapon = null;
    }

    void UpdateText(string text)
    {
        FindAnyObjectByType<TextManager>().UpdateText(text);
    }

    
    string GetWeaponName(GameObject weapon)
    {
        Weapon weaponScript = weapon.GetComponent<Weapon>();
        if (weaponScript == null)
        {
            Debug.LogError("❌ Weapon component not found on: " + weapon.name);
            return "Unknown Weapon";
        }
        return weaponScript.ReturnName();
}   
}

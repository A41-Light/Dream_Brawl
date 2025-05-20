using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected GameObject trigger;
    protected GameObject wielder;
    protected string weaponName = "Weapon";
    protected SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trigger = transform.Find("Pickup Zone").gameObject;
        trigger.GetComponent<CircleCollider2D>().isTrigger = true;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null && transform.parent.CompareTag("Player"))
        {
            wielder = transform.parent.gameObject;
            trigger.SetActive(false);
            spriteRenderer.sortingOrder = 1;
        }
        else
        {
            wielder = null;
            trigger.SetActive(true);
            spriteRenderer.sortingOrder = -1;
        }
    }

    public abstract void Attack();

    public virtual string ReturnName()
    {
        return weaponName;
    }
}

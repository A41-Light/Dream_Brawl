using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float frequency = 2f;      // How many cycles per second
    public float amplitude = 0.5f;    // How high it floats
    public float bobSpeed = 2f;       // Speed of following the sine wave

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Float();
    }

    void Float()
    {
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        Vector3 targetPos = startPos + new Vector3(0, yOffset, 0);

        // Lerp to create a smoother float (like gentle flapping, instead of snappy)
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * bobSpeed);
    }
}

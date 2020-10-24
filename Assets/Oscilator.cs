using UnityEngine;

[DisallowMultipleComponent]
public class Oscilator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    float movementFactor;   // 0 for not moved, 1 for fully moved
    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // protect against period is zero
        if (period <= Mathf.Epsilon) { return; }
        const float tau = Mathf.PI * 2f; // about 6.28

        // set movement factor automatically
        float cycles = Time.time / period;  // grows continually from 0
        float rawSineWave = Mathf.Sin(cycles * tau);    // goes from -1 to +1
        movementFactor = rawSineWave / 2f +0.5f;    // goes from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}


using UnityEngine;

public class RotarCubo : MonoBehaviour
{
    public float velocidad = 100f;

    void Update()
    {
        transform.Rotate(0f, velocidad * Time.deltaTime, 0f);
    }
}

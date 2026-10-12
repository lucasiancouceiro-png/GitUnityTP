
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (collected || !other.CompareTag("Player"))
            return;

        collected = true;

        GameManager.Instance.CollectItem();

        Destroy(gameObject);
    }
}

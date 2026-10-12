
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset = new Vector3(0f, 5f, -7f);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (Player == null) return;

        Vector3 desiredPosition = Player.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.LookAt(Player);
    }
}

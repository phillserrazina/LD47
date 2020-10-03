using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerMovement player;

    private void Start() {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void LateUpdate() {
        var newPos = player.transform.position;
        newPos.y = 0.5f;
        newPos.z = -10f;
        transform.position = newPos;
    }
}

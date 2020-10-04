using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // VARIABLES
    private PlayerManager player;

    // EXECUTION FUNCTIONS
    private void Start() => player = PlayerManager.instance;

    private void FixedUpdate() {
        var newPos = player.transform.position;
        newPos.y = 1.5f;
        newPos.z = -10f;

        var smoothPos = Vector3.Lerp(transform.position, newPos, 0.125f);

        transform.position = smoothPos;
    }
}

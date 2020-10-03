using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // VARIABLES
    private PlayerManager player;

    // EXECUTION FUNCTIONS
    private void Start() => player = PlayerManager.instance;

    private void LateUpdate() {
        var newPos = player.transform.position;
        newPos.y = 1.5f;
        newPos.z = -10f;
        transform.position = newPos;
    }
}

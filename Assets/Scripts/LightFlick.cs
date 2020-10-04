using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlick : MonoBehaviour
{
    private Light2D myLight;

    private float timer;

    private void Awake() {
        myLight = GetComponent<Light2D>();
    }

    void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
            return;
        }

        timer = Random.Range(0.01f, 0.2f);
        myLight.intensity = Random.Range(0.2f, 0.5f);
    }
}

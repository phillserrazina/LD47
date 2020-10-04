using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public void Trigger() {
        Destroy(gameObject);
        UIManager.instance.GetComponent<Animator>().Play("Achievement");
    }
}

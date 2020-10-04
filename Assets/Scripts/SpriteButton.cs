using UnityEngine;

public class SpriteButton : MonoBehaviour
{
    [SerializeField] private GameObject highlight = null;

    private void OnMouseEnter() {
        transform.localScale *= 1.02f;
        highlight.SetActive(true);
    }

    private void OnMouseExit() {
        transform.localScale /= 1.02f;
        highlight.SetActive(false);
    }

    private void OnMouseDown() {
        FindObjectOfType<CusceneHelper>().animator.Play("OnClick");
        AudioManager.instance.Play("DoorOn");
    }
}

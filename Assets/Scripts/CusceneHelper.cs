using UnityEngine;
using UnityEngine.SceneManagement;

public class CusceneHelper : MonoBehaviour
{
    public Animator animator;
    private void Awake() => animator = GetComponent<Animator>();

    private void Start() {
        if (!AudioManager.instance.IsPlaying("MainTheme")) AudioManager.instance.Play("MainTheme");
    }

    public void Transition() {
        SceneManager.LoadScene("GameScene");
    }

    public void Credits() => animator.Play("Credits");
    public void Menu() => animator.Play("Menu");
    public void Exit() => Application.Quit();
    public void URL(string url) => Application.OpenURL(url);
}

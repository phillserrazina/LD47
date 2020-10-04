using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private Text currentLoopText = null;

    public static UIManager instance { get; private set; }

    // EXECUTION FUNCTIONS
    private void Awake() {
        instance = this;
    }

    private void Start() {
        UpdateLoopText(0);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
    }

    // METHODS
    public void UpdateLoopText(int val) => currentLoopText.text = val.ToString();

    public void TriggerInitLight() => DoorHighlight.instance.SetLoop(0);

    public void Menu() => SceneManager.LoadScene("MainMenu");
}

using UnityEngine;
using UnityEngine.UI;

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

    // METHODS
    public void UpdateLoopText(int val) => currentLoopText.text = val.ToString();
}

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private ItemSO triggerItem = null;
    [SerializeField] private UnityEvent onSuccessEvent = null;

    public static ButtonManager instance { get; private set; }
    private List<string> activatedButtons = new List<string>();

    private LoopButton[] allButtons;

    // EXECUTION FUNCTIONS
    private void Awake() => instance = this;

    private void Start() {
        allButtons = FindObjectsOfType<LoopButton>();
    }

    // METHODS
    public void ReceiveInfo(string info) {
        activatedButtons.Add(info);

        if (activatedButtons.Count < 4) return;

        if (activatedButtons.Contains("M0") && 
            activatedButtons.Contains("L1") &&
            activatedButtons.Contains("R-1") &&
            activatedButtons.Contains("R2")) {
            // Play a sound
            StartCoroutine(SuccessCoroutine());
        }
        else {
            // Play sound
            StartCoroutine(FailCoroutine());
        }

        activatedButtons.Clear();
    }

    private IEnumerator SuccessCoroutine() {
        yield return new WaitForSeconds(1f);
        AudioManager.instance.Play("Pickup");

        foreach (var b in allButtons) {
            b.GetComponent<Animator>().Play("OnDisable");
        }

        yield return new WaitForSeconds(0.5f);

        PlayerInventory.instance.Remove(triggerItem);
        onSuccessEvent?.Invoke();
        DoorHighlight.instance.SetLoop(0);
    }

    private IEnumerator FailCoroutine() {
        yield return new WaitForSeconds(1f);

        foreach (var b in allButtons) {
            b.ResetButton();
        }

        AudioManager.instance.Play("WrongButton");
    }
}

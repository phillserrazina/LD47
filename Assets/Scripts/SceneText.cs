using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SceneText : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private LoopDialogue myDialogue = null;
    private Text myText;
    private Animator animator;

    private Dictionary<int, LoopDialogueObject> dialogueMap = new Dictionary<int, LoopDialogueObject>();

    // EXECUTION FUNCTIONS
    private void Awake() {
        myText = GetComponent<Text>();
        animator = GetComponent<Animator>();

        gameObject.SetActive(false);

        if (myDialogue != null) {
            myDialogue = ScriptableObject.Instantiate(myDialogue);

            foreach (var dobj in myDialogue.content) {
                dialogueMap.Add(dobj.loop, dobj);
            }
        }
    }

    // METHODS
    public void ActivateText() {
        if (myDialogue == null) return;
        if (!dialogueMap.ContainsKey(RoomManager.instance.CurrentLoop)) return;

        var mapLoop = dialogueMap[RoomManager.instance.CurrentLoop];

        if (!mapLoop.IsAvailable()) return;

        var next = "Default";

        if (gameObject.activeInHierarchy) {
            if (!dialogueMap.ContainsKey(RoomManager.instance.CurrentLoop)) return;
            next = mapLoop.NextLine();
            
            if (myText.text == next) {
                if (!string.IsNullOrEmpty(dialogueMap[RoomManager.instance.CurrentLoop].myEvent))
                    Invoke(dialogueMap[RoomManager.instance.CurrentLoop].myEvent, 0f);
                animator.Play("OnDisable");
                dialogueMap.Remove(RoomManager.instance.CurrentLoop);

                return;
            }

            myText.text = next;
            return;
        }

        myText.text = mapLoop.NextLine();
        if (mapLoop.item != null) dialogueItem = mapLoop.item;
        gameObject.SetActive(true);

        animator.Play("OnEnable");
    }

    public void ActivateTextSimple(string text) {
        myText.text = text;
        gameObject.SetActive(true);

        animator.Play("OnEnable");
    }

    public void SwitchDialogues(LoopDialogue newDialogue) {
        myDialogue = newDialogue;

        if (myDialogue != null) {
            myDialogue = ScriptableObject.Instantiate(myDialogue);
            dialogueMap.Clear();

            foreach (var dobj in myDialogue.content) {
                dialogueMap.Add(dobj.loop, dobj);
            }
        }
    }

    public ItemSO dialogueItem;
    public void GiveItemToPlayer() => PlayerInventory.instance.Add(dialogueItem);
}

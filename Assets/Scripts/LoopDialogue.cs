using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName="Loop Dialogue", fileName="New Loop Dialogue")]
public class LoopDialogue : ScriptableObject {
    public LoopDialogueObject[] content;
}

[System.Serializable]
public class LoopDialogueObject {
    public int requiredLoops = 0;
    public int currentLine = -1;
    public int loop;
    [SerializeField] [TextArea(1, 3)] private string[] lines = null;
    public string myEvent;
    public bool setDoorLight;
    public ItemSO item;
    public int doorLoop;

    public bool IsAvailable() {
        if (!RoomManager.instance.HasVisited(requiredLoops)) {
            return false;
        }

        return true;
    }

    public string NextLine() {
        if (currentLine < lines.Length-1) currentLine++;
        return lines[currentLine];
    }
}

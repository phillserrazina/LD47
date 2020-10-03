using UnityEngine;
using System.Collections.Generic;

public class LoopButton : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private string roomDirection = "";
    [SerializeField] private Sprite activatedSprite = null;
    private List<string> activated = new List<string>();

    private SpriteRenderer myRenderer;
    private Sprite originalSprite;

    private string info { get { return roomDirection + RoomManager.instance.CurrentLoop.ToString(); } }

    // EXECUTION FUNCTION
    private void Start() {
        myRenderer = GetComponent<SpriteRenderer>();
        originalSprite = myRenderer.sprite;
    }

    private void Update() {
        myRenderer.sprite = activated.Contains(info) ? activatedSprite : originalSprite;
    }

    // METHODS
    public void SendInfo() {
        if (activated.Contains(info)) return;

        activated.Add(info);
        ButtonManager.instance.ReceiveInfo(info);
    }

    public void ResetButton() {
        activated.Clear();
    }
}

using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private GameObject actionTrigger = null;

    public PlayerMovement movement { get; private set; }
    public static PlayerManager instance { get; private set; }  // Probably don't do this in a real life scenario

    private float cooldown = 0f;
    private bool inRangeOfObject = false;

    public Animator animator { get; private set; }

    // EXECUTION MOVEMENT
    private void Awake() {
        movement = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();

        instance = this;
    }

    private void Update() {
        if (cooldown > 0f) {
            actionTrigger.SetActive(false);
            cooldown -= Time.deltaTime;
            return;
        }

        if (inRangeOfObject && !actionTrigger.activeInHierarchy) actionTrigger.SetActive(true);
    }

    // METHODS
    public void OnObjectChange(bool val) {
        actionTrigger.SetActive(val);
        inRangeOfObject = val;
    }

    public void BeginCooldown() => cooldown = 0.5f;
}

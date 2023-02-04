using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerClassPrefab
{
    public PlayerClass playerClass;
    public Player playerPrefab;
}

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; } = null;

    [SerializeField] private PlayerClassPrefab[] playerClassPrefabs;
    private Dictionary<PlayerClass, Player> playerClassPool;

    [Header("Player 1 Spawn Variables")]
    [SerializeField] private GameObject p1SpawnPoint;
    [SerializeField] private Vector3 p1ForwardVector;
    [SerializeField] private KeyCode p1AttackKey = KeyCode.D;
    [SerializeField] private KeyCode p1DodgeKey = KeyCode.A;
    [SerializeField] private KeyCode p1SpecialKey = KeyCode.W;
    [Header("Player 2 Spawn Variables")]
    [SerializeField] private GameObject p2SpawnPoint;
    [SerializeField] private Vector3 p2ForwardVector;
    [SerializeField] private KeyCode p2AttackKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode p2DodgeKey = KeyCode.RightArrow;
    [SerializeField] private KeyCode p2SpecialKey = KeyCode.UpArrow;

    // reference to Player1 and Player2 objects in the scene
    private Player player1;
    private Player player2;
    private Collider2D player1Col;
    private Collider2D player2Col;

    [SerializeField] private CombatUI_Player combatUIPlayer;

    private void Awake()
    {
        // initialise singleton
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.Log("PlayerManager already exists in " + Instance.gameObject.name + ", destroying copy in " + gameObject.name);
            Destroy(this);
        }

        playerClassPool = new Dictionary<PlayerClass, Player>();
        foreach (PlayerClassPrefab p in playerClassPrefabs)
        {
            playerClassPool.Add(p.playerClass, p.playerPrefab);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void LoadPlayers(PlayerClass p1, PlayerClass p2)
    {
        // instantiate p1 and p2 at spawn points
        player1 = Instantiate(playerClassPool[p1], p1SpawnPoint.transform.position, Quaternion.identity);
        player2 = Instantiate(playerClassPool[p2], p2SpawnPoint.transform.position, Quaternion.identity);

        // set control attributes depending on p1 or p2
        player1.SetPlayerNumber(true, p1ForwardVector, p1AttackKey, p1DodgeKey, p1SpecialKey);
        player2.SetPlayerNumber(false, p2ForwardVector, p2AttackKey, p2DodgeKey, p2SpecialKey);

        // update combat UI
        combatUIPlayer.SetPlayer1(p1);
        combatUIPlayer.SetPlayer2(p2);

        // get colliders
        player1Col = player1.GetComponent<Collider2D>();
        player2Col = player2.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player1.SetXBounds(player2Col.bounds.min.x);
        player2.SetXBounds(player1Col.bounds.max.x);
    }
}

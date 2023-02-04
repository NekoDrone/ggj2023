using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; } = null;

    [SerializeField] private Player player1;
    [SerializeField] private Player player2;

    private Collider2D player1Col;
    private Collider2D player2Col;

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
    }

    // Start is called before the first frame update
    void Start()
    {
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

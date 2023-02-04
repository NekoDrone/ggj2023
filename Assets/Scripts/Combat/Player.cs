using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey = KeyCode.A; // also moves forward
    [SerializeField] private KeyCode dodgeKey = KeyCode.D;  // iframe, stay in position
    [SerializeField] private KeyCode specialKey = KeyCode.W;  // cast special ability
    //[SerializeField] private float thrust = 1f;

    private Collider2D playerCollider;
    [SerializeField] private PlayerAttackCollider attackCollider;

    [SerializeField] private Vector3 forwardDir = new Vector3(1,0,0);
    [SerializeField] private float forwardMoveSpeed = 1f;

    private IEnumerator moveCoroutine = null;

    [SerializeField] private Animator spriteAnimator;
    [SerializeField] private SpriteRenderer playerSprite;

    private bool attackInputEnabled = true;
    private bool checkAttackHit = false;

    private bool dodgeInputEnabled = true;

    [SerializeField] private CharacterClass specialMove;
    [SerializeField] private bool isPlayerOne = true;
    private float xBound;

    public void SetPlayerNumber(bool isPlayerOne, Vector3 forward, KeyCode attackKey, KeyCode dodgeKey, KeyCode specialKey)
    {
        // set isPlayerOne bool
        this.isPlayerOne = isPlayerOne;

        // assign their forward vectors
        forwardDir = forward;

        // assign action keys
        this.attackKey = attackKey;
        this.dodgeKey = dodgeKey;
        this.specialKey = specialKey;

        // flip p1 (x scale = -1)
        if (isPlayerOne)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    private void GetHit()
    {
        // if currently mid-attack, cancel attack
        /// NOTE: don't need to cancel dodge since dodge is iframe, player cannot get hit
        CancelAttack();

        // apply knockback
        moveCoroutine = MoveBackward();
        StartCoroutine(moveCoroutine);

        // change to hurt animation
        spriteAnimator.SetTrigger("Hurt");

        // apply stun duration (disable inputs)
        attackInputEnabled = false;
        dodgeInputEnabled = false;

        // visualisation: stun duration
        playerSprite.color = Color.red;
    }
    public void RecoverFromStun()
    {
        // stop knockback
        CancelMove();

        // apply stun duration (enable inputs)
        attackInputEnabled = true;
        dodgeInputEnabled = true;

        // end visualisation
        playerSprite.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkAttackHit)
        {
            bool collision = (attackCollider.CollidedEntity != null);

            if (collision)  // opponent player is hit
            {
                // TODO: apply attack hit/knockback on enemy
                Player hit = attackCollider.CollidedEntity.GetComponent<Player>();
                if (hit != null)
                    hit.GetHit();
            }
        }

        if (attackInputEnabled)
        {
            if (Input.GetKeyDown(attackKey))
            {
                // perform on-hit collision check for attack -- only perform it during mid-swing
                /// TBD: code here, or based on animation (can trigger Animation Event)
                //StartCoroutine(CheckAttackHit());
                //bool collision = (attackCollider.CollidedEntity == null);

                // move forward (for now, just move by position?)
                /// TBD: change to using codes to translate Sprite instead of animation clip+Event
                moveCoroutine = MoveForward();
                StartCoroutine(moveCoroutine);

                // change to attack animation
                spriteAnimator.SetTrigger("Attack");

                // disable attack input
                attackInputEnabled = false;
            }
            if (Input.GetKeyDown(specialKey))
            {
                
            }
        }

        if (dodgeInputEnabled)
        {
            if (Input.GetKeyDown(dodgeKey))
            {
                // if currently mid-attack, cancel attack
                CancelAttack();

                // activate dodge animation
                spriteAnimator.SetTrigger("Dodge");

                // disable dodge input
                dodgeInputEnabled = false;

                // enable iframe
                playerCollider.enabled = false;

                // visualisation: dodge duration
                playerSprite.color = Color.green;
            }
        }
    }

    /// <summary>
    /// To be called when interrupted/stunned:
    ///  1. When hit by an attack
    ///  2. When dodging during an attack
    /// </summary>
    private void CancelAttack()
    {
        // stop moving forward
        CancelMove();

        // end visualisation
        playerSprite.color = Color.white;
    }

    [SerializeField] private float dodgeDuration = 0.1f;

    private void FinishDodge()
    {
        // disable iframe
        playerCollider.enabled = true;

        // re-enable attack input
        attackInputEnabled = true;

        // re-enable dodge input
        dodgeInputEnabled = true;

        // end visualisation
        playerSprite.color = Color.white;
    }

    private IEnumerator MoveForward()
    {
        while (true) {
            transform.position += forwardDir * forwardMoveSpeed * Time.deltaTime;
            float xPos;
            if (isPlayerOne) {
                xPos = Mathf.Min(transform.position.x, xBound);
            }
            else {
                xPos = Mathf.Max(transform.position.x, xBound);
            }
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

            yield return null;
        }
    }
    private IEnumerator MoveBackward()
    {
        while (true)
        {
            transform.position -= forwardDir * forwardMoveSpeed * Time.deltaTime;
            yield return null;
        }
    }


    public void CancelMove()
    {
        if (moveCoroutine != null) {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
    }

    public void AttackComplete()
    {
        // stop moving forward
        CancelMove();

        // re-enable attack input
        attackInputEnabled = true;
    }

    public void EnableAttackHitCheck()
    {
        checkAttackHit = true;

        // visualisation: attack collision duration
        playerSprite.color = Color.cyan;
    }

    public void DisableAttackHitCheck()
    {
        checkAttackHit = false;

        // end visualisation
        playerSprite.color = Color.white;
    }

    public void SetXBounds(float xBound)
    {
        this.xBound = xBound;
    }
}

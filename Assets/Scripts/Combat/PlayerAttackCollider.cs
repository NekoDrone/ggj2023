using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    public Collider2D collidedEntity = null;
    public Collider2D CollidedEntity
    {
        get { return collidedEntity; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidedEntity = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collidedEntity = null;
    }
}

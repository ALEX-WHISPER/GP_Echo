using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenHealth : EnemyHealth {
    protected override void EnemyDestroy()
    {
        base.EnemyDestroy();
        Destroy(gameObject);
    }
}

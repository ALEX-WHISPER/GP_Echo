using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHealth : EnemyHealth {
    protected override void EnemyDestroy()
    {
        Destroy(gameObject);
    }
}

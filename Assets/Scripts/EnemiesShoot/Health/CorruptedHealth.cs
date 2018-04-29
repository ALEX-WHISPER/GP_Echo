using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedHealth : EnemyHealth {
    public CorruptedShoot shoot;
    protected override void EnemyDestroy()
    {
        base.EnemyDestroy();
        shoot.ifStopShoot = true;
    }
}

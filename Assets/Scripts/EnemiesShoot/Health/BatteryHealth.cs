using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryHealth : EnemyHealth {
    public BatteryShoot shoot;
    protected override void EnemyDestroy()
    {
        base.EnemyDestroy();
        shoot.ifStopShoot = true;
    }
}

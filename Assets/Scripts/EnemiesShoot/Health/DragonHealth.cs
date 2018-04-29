using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHealth : EnemyHealth {
    //public DragonShoot shoot;
    
    protected override void EnemyDestroy()
    {
        base.EnemyDestroy();
        if(GetComponent<DragonShoot>() != null)
        {
            GetComponent<DragonShoot>().StopShooting();
        }
    }
}

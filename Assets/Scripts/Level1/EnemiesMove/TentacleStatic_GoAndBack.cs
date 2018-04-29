using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleStatic_GoAndBack : MonoBehaviour {
    public float tentacleGoDuation;  //  触手变大(向外戳)的持续时间
    public float tentacleBackDuration;  //  触手变小(向内收)的持续时间
    public Vector3 tentacleEndPositionValue;  //  触手在变化终点时的position
    public Vector3 tentacleStartPositionValue; //  触手在变化起点时的position
    public float tentacleStayDuration;      //  触手停留的时间
    public float tentacleHitDelay;          //  触手向外戳的延迟时间

	void Start () {
        StartCoroutine(HitAndBack());
	}

    IEnumerator HitAndBack()
    {
        yield return new WaitForSeconds(tentacleHitDelay);
        TentacleGo();
        yield return new WaitForSeconds(tentacleStayDuration);
        TentacleBack();
    }

    private void TentacleGo()
    {
        TweenPosition.Begin(gameObject, tentacleGoDuation, tentacleEndPositionValue);
    }

    private void TentacleBack()
    {
        TweenPosition.Begin(gameObject, tentacleBackDuration, tentacleStartPositionValue);
    }
}

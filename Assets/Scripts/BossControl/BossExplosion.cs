using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExplosion : MonoBehaviour {
    public GameObject explosion;
    public List<Transform> explosionPos = new List<Transform>();
    public float delayMin;
    public float delayMax;

    public void CreateExplosion()
    {
        List<Transform> explosionPosList = new List<Transform>();
        explosionPosList = explosionPos;

        StartCoroutine(StartExplode(explosionPosList));
    }

    IEnumerator StartExplode(List<Transform> posList)
    {
        int i = posList.Count;
        while (i > 0)
        {
            int n = Random.Range(0, posList.Count);
            Instantiate(explosion, posList[n].position, Quaternion.identity);
            i--;
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
        }
    }
}

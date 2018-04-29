using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt3_Radial_Single : MonoBehaviour {
    public GameObject bolt3_Prefab;
    public float shootAngle_Min;
    public float shootAngleGap;
    public float shootAngle_Max;

    private List<float> shootRotation_Bolt3 = new List<float>();
    void Start()
    {
        ShootRadialBolt();
    }

    void ShootRadialBolt()
    {
        ShotSpawnRotate();
        InitShootRotation_Bolt3();
        
        foreach (float shootRotation in shootRotation_Bolt3)
        {
            Vector3 instancePosition = transform.position;
            Quaternion instanceRotation = Quaternion.identity;
            instanceRotation.eulerAngles = new Vector3(0, 0, shootRotation);

            GameObject bolt3_Radial = Instantiate(bolt3_Prefab, instancePosition, instanceRotation) as GameObject;
            bolt3_Radial.transform.SetParent(gameObject.transform);
        }
    }

    private void InitShootRotation_Bolt3()
    {
        float shootRotation_z = shootAngle_Min + transform.rotation.eulerAngles.z;

        do
        {
            shootRotation_Bolt3.Add(shootRotation_z);
            shootRotation_z += shootAngleGap;

        } while (shootRotation_z <= shootAngle_Max + transform.rotation.eulerAngles.z);
    }

    private void ShotSpawnRotate()
    {
        float randomRotate = Random.Range(-1 * (shootAngleGap / 2), (shootAngleGap / 2));
        transform.Rotate(new Vector3(0, 0, randomRotate));
    }
}

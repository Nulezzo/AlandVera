using UnityEngine;
using System.Collections;

public class AlController : MonoBehaviour {
    public GameObject spawnedWaterDrop;
    public float Speed;
    public int jumpForce;
    public GameObject currentActionPad;

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!UseActionPad())
            {
                ReleaseAllCharges();
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
	}
    bool UseActionPad()
    {
        if (currentActionPad == null)
        {
            return false;
        }
        currentActionPad.GetComponent<ActionPad>().DoAction(this.gameObject);
        return true;
    }

    bool ReleaseAllCharges()
    {
        if (AlWaterManager.Instance.GetCharges() <= 0)
        {
            return false;
        }
        for (int i = 0; i < AlWaterManager.Instance.GetCharges(); i++)
        {
            GameObject WaterParent = new GameObject();
            for (int numberOfDrops = 0; numberOfDrops < AlWaterManager.Instance.numberOfWaterDropsInCharge; numberOfDrops++)
            {
                GameObject newWaterDrop = GameObject.Instantiate(spawnedWaterDrop, transform.position + Random.onUnitSphere, Quaternion.identity) as GameObject;
                newWaterDrop.transform.parent = WaterParent.transform;
            }
        }
        AlWaterManager.Instance.ClearCharges();
        return true;
    }
}

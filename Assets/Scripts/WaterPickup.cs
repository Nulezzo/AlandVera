using UnityEngine;
using System.Collections;

public class WaterPickup : MonoBehaviour {
    public bool PickupByPlayer;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (PickupByPlayer &&  col.gameObject.tag == "Al")
        {
            AlWaterManager.Instance.AddCharge();
            RemoveWater(col.gameObject);
        }
        if (col.gameObject.tag == "WaterTarget")
        {
            col.gameObject.GetComponent<WaterTarget>().AddCharge();
            RemoveWater(col.gameObject);
        }
    }

    void RemoveWater(GameObject PullToThis)
    {
        foreach (Transform waterDrop in transform.parent.GetComponentInChildren<Transform>())
        {
            SpringJoint2D joint = waterDrop.gameObject.AddComponent<SpringJoint2D>();
            joint.connectedBody = PullToThis.GetComponent<Rigidbody2D>();
            joint.distance = 0f;
            joint.dampingRatio = 20f;
            joint.frequency = 5;
            joint.enableCollision = true;
            waterDrop.GetComponent<ParticleSystem>().Stop();
            waterDrop.GetComponent<ParticleSystem>().loop = false;
            waterDrop.GetComponent<ParticleSystem>().Play();
            Destroy(waterDrop.GetComponent<Collider2D>());
            Destroy(this.gameObject, 2f);
        }
        Destroy(transform.parent.gameObject, 2f);
    }
}

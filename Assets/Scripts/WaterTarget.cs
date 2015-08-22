using UnityEngine;
using System.Collections;

public class WaterTarget : MonoBehaviour {

    public int chargesToActivate;
    int collectedCharges;
    public GameObject[] connectionActionObjects;


    public void AddCharge()
    {
        collectedCharges++;
        if (collectedCharges >= chargesToActivate)
        {
            foreach (GameObject actionObject in connectionActionObjects)
            {
                actionObject.GetComponent<WaterTargetAction>().DoAction();
            }
            collectedCharges = 0;
        }
    }
	
}

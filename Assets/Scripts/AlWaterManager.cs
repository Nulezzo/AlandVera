using UnityEngine;
using System.Collections;

public class AlWaterManager : MonoBehaviour {
    public static AlWaterManager Instance;

    public int maxNumberOfCharges;
    public int numberOfWaterDropsInCharge;

    int numberOfCharges;
    int numberOfDrops;


    void Awake()
    {
        Instance = this;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public int GetCharges()
    {
        return numberOfCharges;
    }
    public void ClearCharges()
    {
        numberOfCharges = 0;
        numberOfDrops = 0;
    }
    public bool IsFull()
    {
        return numberOfCharges >= maxNumberOfCharges;
    }
    public bool AddCharge()
    {
        if(!IsFull()){
        numberOfCharges++;
            if (numberOfCharges > maxNumberOfCharges)
            {
                numberOfCharges = maxNumberOfCharges;
            }
        return true;
        }
        return false;

    }
}

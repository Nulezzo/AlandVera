using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {
    public float secondsToDestroy;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, secondsToDestroy);
	}

}

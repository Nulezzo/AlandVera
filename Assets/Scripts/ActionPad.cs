using UnityEngine;
using System.Collections;

public class ActionPad : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Al")
        {
            col.gameObject.GetComponent<AlController>().currentActionPad = this.gameObject;
        }
        /*
        if (col.gameObject.tag == "Vera")
        {
            col.gameObject.GetComponent<AlController>().currentActionPad = this.gameObject;
        }*/
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Al")
        {
            if (col.gameObject.GetComponent<AlController>().currentActionPad == this.gameObject)
            {
                col.gameObject.GetComponent<AlController>().currentActionPad = null;
            }
        }
        /*
        if (col.gameObject.tag == "Vera")
        {
            if (col.gameObject.GetComponent<VeraController>().currentActionPad == this.gameObject)
            {
                col.gameObject.GetComponent<VeraController>().currentActionPad = null;
            }
        }*/
    }

    public virtual void DoAction(GameObject target){
        Debug.Log("Default Action, Should not see this..");
    }
}

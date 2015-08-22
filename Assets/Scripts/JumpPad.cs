using UnityEngine;
using System.Collections;

public class JumpPad : ActionPad {

    public override void DoAction(GameObject target){
        if (target.tag == "Al")
        {
            target.GetComponent<Rigidbody2D>().AddForce(Vector2.up * target.GetComponent<AlController>().jumpForce);
        }
        /*
        if (target.tag == "Vera")
        {
            
        }*/
    }
}

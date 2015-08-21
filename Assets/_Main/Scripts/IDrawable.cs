using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;

[SelectionBase]
public class IDrawable : MonoBehaviour {

    public bool IsAddingOrDeleting = true;
    public float RoundFactor = 50f;
    public LayerMask OnlyDrawable;
    public LayerMask OnlyBlock;
    public GameObject PFB_Block;
    public Transform LevelOverseer;

    public void DrawAction(RaycastHit2D hitData)
    {
        if (IsAddingOrDeleting && hitData.collider.gameObject.layer == (int)Mathf.Log(OnlyDrawable.value, 2))
        {
            Vector2 levelPiece = new Vector2(Mathf.RoundToInt(hitData.point.x / RoundFactor) * RoundFactor, Mathf.RoundToInt(hitData.point.y / RoundFactor) * RoundFactor);
            GameObject prefab = (GameObject)Instantiate(PFB_Block, levelPiece, Quaternion.identity);
            prefab.transform.parent = LevelOverseer;
        }
        else if (!IsAddingOrDeleting && hitData.collider.gameObject.layer == (int)Mathf.Log(OnlyBlock.value, 2))
        {
            DestroyImmediate(hitData.collider.gameObject);
        }
    }

    void OnDrawGizmos()
    {/*
        foreach (Vector3 roadPoint in RoadEdgePoints)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(new Vector3(roadPoint.x, 0, roadPoint.y), 2f);
            //Handles.PositionHandle(new Vector3(roadPoint.x, 0, roadPoint.y), Quaternion.identity);
            //Gizmos.DrawSphere(roadPoint, 3f);
        }*/
    }
}

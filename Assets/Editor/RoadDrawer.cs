using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(IDrawable))]
public class RoadDrawer : Editor {

    private bool isFiring;
    private IDrawable m_Target;

    public override void OnInspectorGUI()
    {
        m_Target = (IDrawable)target;
        base.OnInspectorGUI();

        if (GUILayout.Button((m_Target.IsAddingOrDeleting) ? "Adding, toggle to delete blocks" : "Deleting, toggle to add blocks"))
        {
            m_Target.IsAddingOrDeleting = !m_Target.IsAddingOrDeleting;
        }

        GUILayout.Space(10f);
        GUI.color = Color.red;

        if (GUILayout.Button("Clear Blocks"))
        {
            IBlock[] blocks = (IBlock[])FindObjectsOfType(typeof(IBlock));
            foreach (IBlock block in blocks)
            {
                DestroyImmediate(block.gameObject);
            }
            EditorUtility.SetDirty(m_Target);
        }

        GUI.color = Color.white;
    }

    void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseDown)
        {
            GatherPoints();
            isFiring = !isFiring;
        }
        else if (Event.current.type == EventType.MouseMove)
        {
            GatherPoints();
        }
    }

    private void GatherPoints()
    {
        if (!isFiring) return;
        //isFiring = false; // Disable for continuous drawing

        Vector3 viewportPoint = Camera.current.ScreenToViewportPoint(Event.current.mousePosition);
        //Debug.Log(viewportPoint);
        viewportPoint = new Vector3(viewportPoint.x, 1 - viewportPoint.y, viewportPoint.z); // Invert the Y
        //Debug.Log(viewportPoint);

        Ray ray = Camera.current.ViewportPointToRay(viewportPoint);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
            m_Target.DrawAction(hit);

        /*
        //Debug.DrawRay(ray.origin, ray.direction * 100000000f, Color.yellow, 5f);
        if (Physics.Raycast(ray, out hit, 100000.0f))
        {
            m_Target.DrawAction(hit);
            //Debug.Log("Yay3");

            EditorUtility.SetDirty(m_Target);


            //Debug.Log(Event.current.mousePosition);
            //Debug.DrawLine(Camera.current.transform.position, hit.point, Color.yellow, 30f);
            
            //m_Target.RoadTest.Add(hit.point);
        }*/
    }
}

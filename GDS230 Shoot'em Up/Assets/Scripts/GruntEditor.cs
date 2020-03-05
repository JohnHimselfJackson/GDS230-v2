using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GruntScript))]
public class GruntEditor : Editor
{
    private void OnSceneGUI()
    {
        GruntScript GE = target as GruntScript;
        Handles.ArrowHandleCap(0, GE.transform.position, Quaternion.LookRotation(-GE.transform.right), 0.4f, EventType.Repaint);
        if (GE.enemySpotted)
        {
            Handles.color = Color.red;
        }
        else
        {

            Handles.color = Color.green;
        }
        Handles.SphereHandleCap(0, GE.transform.position + new Vector3(0, 0.4f), Quaternion.identity, 0.1f, EventType.Repaint);

        #region MoveChecks

        //if (Physics2D.BoxCastAll(GE.transform.position + new Vector3(-0.18f, 0, 0), new Vector3(0.05f, 0.6f, 0), 0f, Vector3.zero,0,8).Length == 0)
        if(!BoxCastForBarrier(GE.transform.position + new Vector3(-0.18f, 0, 0), new Vector3(0.05f, 0.6f, 0), "Barrier"))
        {
            Handles.color = Color.green;
        }
        else
        {
            Handles.color = Color.red;
        }
        Handles.DrawWireCube(GE.transform.position + new Vector3(-0.18f, 0, 0), new Vector3(0.05f, 0.6f, 0));

        //if (Physics2D.BoxCastAll(GE.transform.position + new Vector3(0.18f, 0, 0), new Vector3(0.05f, 0.6f, 0), 0f, Vector3.zero).Length <= 2)
        if (!BoxCastForBarrier(GE.transform.position + new Vector3(0.18f, 0, 0), new Vector3(0.05f, 0.6f, 0), "Barrier"))
        {
            Handles.color = Color.green;
        }
        else
        {
            Handles.color = Color.red;
        }
        Handles.DrawWireCube(GE.transform.position + new Vector3(0.18f, 0, 0), new Vector3(0.05f, 0.6f, 0));

        RaycastHit2D[] leftHitGround = Physics2D.RaycastAll(GE.transform.position + new Vector3(-0.15f, -0.31f, 0), Vector3.down, 0.2f);
        RaycastHit2D[] rightHitGround = Physics2D.RaycastAll(GE.transform.position + new Vector3(0.15f, -0.31f, 0), Vector3.down, 0.2f);
        if (leftHitGround.Length > 0)
        {
            if (GroundCastHitBarrier(leftHitGround))
            {
                Handles.color = Color.green;
            }
            else
            {
                Handles.color = Color.red;
            }
        }
        else
        {
            Handles.color = Color.red;
        }
        Handles.ArrowHandleCap(0,GE.transform.position + new Vector3(-0.15f, -0.3f, 0), Quaternion.LookRotation(Vector3.down), 0.2f, EventType.Repaint);
        if (rightHitGround.Length > 0)
        {
            if (GroundCastHitBarrier(rightHitGround))
            {
                Handles.color = Color.green;
            }
            else
            {
                Handles.color = Color.red;
            }
        }
        else
        {
            Handles.color = Color.red;
        }
        Handles.ArrowHandleCap(0, GE.transform.position + new Vector3(0.15f, -0.3f, 0), Quaternion.LookRotation(Vector3.down), 0.2f, EventType.Repaint);
        #endregion                                 
    }

    #region Misc Functions
    bool BoxCastForBarrier(Vector3 bCOrigin, Vector3 size, string tagTested)
    {
        bool returnthis = false;
        {
            RaycastHit2D[] hits = Physics2D.BoxCastAll(bCOrigin, size, 0f, Vector3.zero);
            for (int cc = 0; cc < hits.Length; cc++)
            {
                if (hits[cc].collider.gameObject.CompareTag(tagTested))
                {
                    returnthis = true;
                }
            }
        }
        return returnthis;
    }

    bool GroundCastHitBarrier(RaycastHit2D[] hits)
    {
        bool returnThis = false;
        for (int cc = 0; cc < hits.Length; cc++)
        {
            if (hits[cc].collider.gameObject.CompareTag("Barrier"))
            {
                returnThis = true;
            }
        }
        return returnThis;
    }
    #endregion
}

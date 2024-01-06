using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

// Represents a path for patrolling behavior, consisting of a list of waypoints.
public class Path : MonoBehaviour
{
    // List of waypoints defining the path
    public List<Transform> waypoints;

    // Draw path settings
    [SerializeField] private bool alwaysDrawPath;
    [SerializeField] private bool drawAsLoop;
    [SerializeField] private bool drawNumbers;
    
    // Debug color used for drawing the path in the editor
    public Color debugColour = Color.white;

    // Draw Gizmos when the GameObject is selected in the editor
    public void OnDrawGizmosSelected()
    {
        // Draw the path if set to always draw or when explicitly called
        if (alwaysDrawPath)
            return;
        else
            DrawPath();
    }

    // Draw Gizmos when the GameObject is not selected in the editor
    public void OnDrawGizmos()
    {
        // Draw the path if set to always draw
        if (alwaysDrawPath)
            DrawPath();
    }

    // Draw the path with Gizmos in the scene view
    public void DrawPath()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            // Create a GUIStyle for label display
            GUIStyle labelStyle = new GUIStyle();
            labelStyle.fontSize = 30;
            labelStyle.normal.textColor = debugColour;

            // Display waypoint numbers if set to do so
            if (drawNumbers)
                Handles.Label(waypoints[i].position, i.ToString(), labelStyle);

            // Draw lines between points
            if (i >= 1)
            {
                Gizmos.color = debugColour;
                Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);

                // Draw a line connecting the last waypoint to the first if set to loop
                if (drawAsLoop)
                    Gizmos.DrawLine(waypoints[waypoints.Count - 1].position, waypoints[0].position);
            }
        }
    }
}
#endif

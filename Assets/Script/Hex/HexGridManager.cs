using UnityEngine;
using System.Collections.Generic;
using _Scripts.Tiles;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class HexGridManager : MonoBehaviour
{
    [Header("Settings")]
    const  float CONNECT_DISTANCE = 27.71242f;
    private Color colorNow = Color.red;
    [Header("Debug")]
    public bool ShowConnections = true;
    public Color ConnectionColor = Color.green;

    void Start()
    {
        ConnectAllHexes();
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (!ShowConnections) return;

        var allHexes = FindObjectsOfType<NodeBase>();

        foreach (var hex in allHexes)
        {
            if (hex.Neighbors == null) continue;

            foreach (var neighbor in hex.Neighbors)
            {
                if (neighbor != null)
                {
                    Gizmos.DrawLine(hex.transform.position, neighbor.transform.position);
                }
            }
        }
    }
#endif
    public static void ResetColor() 
    {
        var allHexes = FindObjectsOfType<NodeBase>();

        foreach (var hex in allHexes)
        {
            if (hex.Neighbors == null) continue;

            foreach (var neighbor in hex.Neighbors)
            {
                if (neighbor != null)
                {
                    hex.SetColor(Color.white);
                }
            }
        }
    }
    public void ConnectAllHexes()
    {
        // Находим все гексы на сцене
        var allHexes = FindObjectsOfType<NodeBase>();
        Debug.Log($"Found {allHexes.Length} hexes on scene");

        int totalConnections = 0;

        // Для каждого гекса ищем соседей
        foreach (var hex in allHexes)
        {
           //hex.SetColor(Color.white);
            if (hex.Neighbors == null)
                hex.Neighbors = new List<NodeBase>();
            else
                hex.Neighbors.Clear();

            Vector3 hexPos = hex.transform.position;

            // Ищем потенциальных соседей
            foreach (var otherHex in allHexes)
            {
                if (otherHex == hex) continue;

                float distance = Vector3.Distance(hexPos, otherHex.transform.position);
                // Если гекс достаточно близко - это сосед
                if (distance <= CONNECT_DISTANCE * 1.1f) // +10% допуск
                {
                    hex.Neighbors.Add(otherHex);
                    totalConnections++;
                }
            }

        }

        Debug.Log($"Total connections established: {totalConnections}");
        Debug.Log("Hex grid connection complete!");

#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
#endif
    }

    [ContextMenu("Clear All Connections")]
    public void ClearAllConnections()
    {
        var allHexes = FindObjectsOfType<NodeBase>();

        foreach (var hex in allHexes)
        {
            if (hex.Neighbors != null)
                hex.Neighbors.Clear();
        }
    }

}
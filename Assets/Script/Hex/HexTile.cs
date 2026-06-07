using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    public HexTile hexConnection { get; private set; }
    public float G;
    public float H;
    public float F => H + G;

    public void SetConnection(HexTile hexBase) => hexConnection = hexBase;

    public void setG(float g) => G = g;
    public void setH(float h) => H = h;
    private void OnMouseDown()
    {
        Debug.Log("Red");
    }
}

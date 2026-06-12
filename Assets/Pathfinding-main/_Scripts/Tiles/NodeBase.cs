using System;
using System.Collections.Generic;
using Tarodev_Pathfinding._Scripts;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

namespace _Scripts.Tiles 
{
    public abstract class NodeBase : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private Color _obstacleColor;
        bool isRoad = false;
        [SerializeField] private Gradient _walkableColor;
        [SerializeField] protected Color _colorNow;
        [SerializeField] private NodeBase _goalNodeBase;
        public static List<NodeBase> selectedPath;
        [SerializeField]  Material child;
        public static NodeBase now;
        
        [SerializeField] protected int steep;

        public ICoords Coords;
        public float GetDistance(NodeBase other)
        {
            if (other == null)
            {
                return float.MaxValue;
            }

            if (Coords == null)
            {
                return Vector3.Distance(transform.position, other.transform.position); // fallback
            }

            if (other.Coords == null)
            {
                return Vector3.Distance(transform.position, other.transform.position); // fallback
            }

            return Coords.GetDistance(other.Coords);
        }
        [SerializeField] public bool Walkable = true;
        [SerializeField] private bool _walkable;
        private bool _selected;
        private Color _defaultColor;

        private void Start()
        {
            _colorNow = GetComponentInChildren<SpriteRenderer>().color;
        }

        public static event Action<NodeBase> OnHoverTile;
        private void OnEnable() => OnHoverTile += OnOnHoverTile;
        private void OnDisable() => OnHoverTile -= OnOnHoverTile;
        private void OnOnHoverTile(NodeBase selected) => _selected = selected == this;

        protected virtual void OnMouseDown()
        {
            HexGridManager.ResetColor();
            if (!_walkable) return;
            Debug.Log("nodeBase.Coords.Pos");
            selectedPath = Pathfinding.FindPath(this, _goalNodeBase);
            if (selectedPath != null)
            {
                now = this; // выбранный 
                Debug.Log($"SUCCESS! Path found with {selectedPath.Count} steps");

                // Визуализация
                int i = 0;
                foreach (var node in selectedPath)
                {
                    i++;
                    if (i <= steep) 
                    {
                        node.SetColor(Color.gray);
                    }
                    else node.SetColor(Color.red);
                }
                SetColor(Color.cyan);
            }
            else
            {
                Debug.LogError("FAILED! No path found");
            }
        }
       
        #region Pathfinding
        [Header("Pathfinding")] [SerializeField]
        private TextMeshPro _fCostText;

        [SerializeField] private TextMeshPro _gCostText, _hCostText;
        public List<NodeBase> Neighbors;
        public NodeBase Connection { get; private set; }
        public float G { get; private set; }
        public float H { get; private set; }
        public float F => G + H;

        public abstract void CacheNeighbors();

        public void SetConnection(NodeBase nodeBase) => Connection = nodeBase;

        public void SetG(float g) => G = g;

        public void SetH(float h) => H = h;

        private void SetText()
        {
            if (_selected) return;
            _gCostText.text = G.ToString();
            _hCostText.text = H.ToString();
            _fCostText.text = F.ToString();
        }

        public void SetColor(Color color) => GetComponentInChildren<SpriteRenderer>().material.color = color;
        public void RevertTile()
        {
            _colorNow = _defaultColor;
            _gCostText.text = "";
            _hCostText.text = "";
            _fCostText.text = "";
        }

        #endregion
    }
}
public interface ICoords
{
    public float GetDistance(ICoords other);
    public Vector2 Pos { get; set; }
}

public interface ICoords3D
{
    public float GetDistance3D(ICoords3D other);
    public Vector3 Pos { get; set; }
}
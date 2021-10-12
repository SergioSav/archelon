using System.Collections.Generic;
using UnityEngine;

public class EnemyRoute : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _routePoints;

    public List<Transform> Points => _routePoints;
}

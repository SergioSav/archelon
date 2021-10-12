using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyRoute))]
public class RouteEditorDrawer : Editor
{
    private const float ROUTE_NODE_RADIUS = 0.5f;

    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    public static void ShowEnemyRoutes(EnemyRoute enemyRoute, GizmoType type)
    {
        Gizmos.color = Color.cyan;
        var prevPos = enemyRoute.Points[0].position;
        foreach (var routePoint in enemyRoute.Points)
        {
            Gizmos.DrawSphere(routePoint.position, ROUTE_NODE_RADIUS);
            Gizmos.DrawLine(prevPos, routePoint.position);
            prevPos = routePoint.position;
        }
        Gizmos.color = Color.clear;
    }
}

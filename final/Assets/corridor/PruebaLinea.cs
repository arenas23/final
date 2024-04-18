using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class PruebaLinea : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public List<Vector3> pathPoints;

 // Distancia mínima requerida para agregar un punto

    private void OnDrawGizmos()
    {
        if (pathPoints != null && pathPoints.Count > 1)
        {
            Gizmos.color = Color.green;

            for (int i = 0; i < pathPoints.Count - 1; i++)
            {
                Gizmos.DrawLine(pathPoints[i], pathPoints[i + 1]);
                
            }
        }

        

    }
}

[CustomEditor(typeof(PruebaLinea))]
public class PruebaLineaEditor : Editor
{
    private readonly float minDistanceToAddPoint = 6f;
 // Referencia al prefab que deseas instanciar

    public override string GetInfoString()
    {
        if (!target)
            return null;

        return base.GetInfoString();
    }
    private void OnSceneGUI()
    {
        PruebaLinea pruebaLinea = (PruebaLinea)target;

        Handles.color = Color.green;

        // Obtener la posición actual del objeto
        Vector3 currentPosition = pruebaLinea.transform.position;

        // Agregar la posición actual al array de puntos solo si es lo suficientemente lejos del último punto
        if (pruebaLinea.pathPoints == null)
        {
            pruebaLinea.pathPoints = new List<Vector3>
            {
                currentPosition // Agregar el primer punto
            };
        }
        else
        {
            // Verifica si el último punto está lo suficientemente lejos de la posición actual
            if (pruebaLinea.pathPoints.Count > 0 && Vector3.Distance(pruebaLinea.pathPoints[pruebaLinea.pathPoints.Count - 1], currentPosition) >= minDistanceToAddPoint)
            {
                pruebaLinea.pathPoints.Add(currentPosition); // Agregar el nuevo punto
                if (pruebaLinea.prefabToInstantiate != null)
                {
                    GameObject newPrefabInstance = (GameObject)PrefabUtility.InstantiatePrefab(pruebaLinea.prefabToInstantiate);
                    if(newPrefabInstance != null)
                    {
                        newPrefabInstance.transform.position = currentPosition;
                    }
                    
                }
            }
        }

        // Marcar el objeto como modificado para que los cambios se guarden
        // EditorUtility.SetDirty(pruebaLinea);
    }
}
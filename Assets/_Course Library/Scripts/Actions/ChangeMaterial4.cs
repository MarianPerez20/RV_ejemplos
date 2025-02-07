using UnityEngine;

public class ChangeMaterial4 : MonoBehaviour
{
    // Referencia al MeshRenderer del GameObject
    private MeshRenderer meshRenderer;

    // Array de materiales disponibles
    public Material[] materials;

    // Índice del material actual
    private int currentMaterialIndex = 0;

    void Start()
    {
        // Obtén el MeshRenderer del GameObject
        meshRenderer = GetComponent<MeshRenderer>();

        // Asegúrate de que hay materiales disponibles
        if (materials.Length > 0)
        {
            // Asigna el primer material como predeterminado
            meshRenderer.material = materials[currentMaterialIndex];
        }
        else
        {
            Debug.LogWarning("No se han asignado materiales en el array.");
        }
    }

    // Método para cambiar al siguiente material
    public void ChangeToNextMaterial()
    {
        if (materials.Length > 0)
        {
            // Incrementa el índice del material de forma cíclica
            currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;

            // Cambia el material del MeshRenderer
            meshRenderer.material = materials[currentMaterialIndex];
        }
        else
        {
            Debug.LogWarning("No hay materiales disponibles para cambiar.");
        }
    }
}
using System.Collections;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    // Duración de la rotación (puedes ajustarla según prefieras)
    public float rotationDuration = 0.5f;

    // Bandera para evitar iniciar otra rotación mientras se está animando
    private bool isRotating = false;

    // Se ejecuta cuando se hace clic/toca sobre el objeto (necesita Collider)
    private void OnMouseDown()
    {
        if (!isRotating)
        {
            StartCoroutine(RotatePiece());
        }
    }

    // Corrutina para rotar el objeto 90° en el eje Y de forma suave
    private IEnumerator RotatePiece()
    {
        isRotating = true;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 90, 0);

        float elapsed = 0f;
        while (elapsed < rotationDuration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsed / rotationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de llegar exactamente a la rotación final
        transform.rotation = endRotation;
        isRotating = false;
    }
}
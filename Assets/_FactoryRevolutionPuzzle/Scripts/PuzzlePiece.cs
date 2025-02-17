using System.Collections;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [Header("Parámetros de Rotación")]
    public float rotationDuration = 0.5f;

    [Header("Parámetros del Salto")]
    public float jumpHeight = 0.2f;
    public float jumpDuration = 0.2f;
    
    private bool isAnimating = false;

    // Se invoca al hacer clic/tocar sobre el objeto (requiere Collider)
    private void OnMouseDown()
    {
        if (!isAnimating)
        {
            StartCoroutine(AnimatePiece());
        }
    }

    // Corrutina combinada para rotar y hacer el salto
    private IEnumerator AnimatePiece()
    {
        isAnimating = true;

        // Cacheamos la referencia al transform para mejorar la performance
        Transform trans = transform;
        Quaternion startRotation = trans.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0, 90, 0);
        Vector3 startPosition = trans.position;

        // Duración total es la máxima entre la rotación y el salto
        float totalDuration = Mathf.Max(rotationDuration, jumpDuration);
        float elapsed = 0f;

        while (elapsed < totalDuration)
        {
            // Actualización de la rotación (suave hasta completar rotationDuration)
            if (elapsed < rotationDuration)
            {
                trans.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsed / rotationDuration);
            }
            else
            {
                trans.rotation = targetRotation;
            }

            // Actualización del salto (efecto "juicy" durante jumpDuration)
            if (elapsed < jumpDuration)
            {
                float t = elapsed / jumpDuration;
                float newY = startPosition.y + jumpHeight * Mathf.Sin(Mathf.PI * t);
                // Se evita crear un nuevo Vector3 innecesariamente
                Vector3 pos = startPosition;
                pos.y = newY;
                trans.position = pos;
            }
            else
            {
                trans.position = startPosition;
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Aseguramos que se alcancen los valores finales exactos
        trans.rotation = targetRotation;
        trans.position = startPosition;
        isAnimating = false;
        
        //llamar al evento para que verifique si la rotacion es correcta
        float yRotation = trans.eulerAngles.y;
        EventsManager.Instance.IsCorrectRadius(yRotation);

    }
}

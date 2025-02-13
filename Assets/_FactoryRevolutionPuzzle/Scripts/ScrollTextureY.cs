using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ScrollBaseMapY : MonoBehaviour
{
    [Header("Velocidad de desplazamiento")]
    [SerializeField] private float scrollSpeed = 0.1f;

    // Nombre de la propiedad en el URP Lit Shader (por defecto es "_BaseMap")
    [SerializeField] private string texturePropertyName = "_BaseMap";

    // Referencia interna al Material instanciado
    private Material materialInstance;

    // Offset inicial (por si quieres modificarlo en el Inspector o Resetearlo en Start)
    private Vector2 offset;

    private void Start()
    {
        // Obtenemos el Renderer en este GameObject
        Renderer rend = GetComponent<Renderer>();
        if (rend == null)
        {
            Debug.LogError("No se encontró Renderer en " + gameObject.name);
            return;
        }

        // Creamos una instancia del material para no modificar el original compartido
        materialInstance = new Material(rend.sharedMaterial);
        // Asignamos la instancia al Renderer
        rend.material = materialInstance;

        // Tomamos el offset inicial
        offset = materialInstance.GetTextureOffset(texturePropertyName);
    }

    private void Update()
    {
        if (materialInstance == null) return;

        // Incrementamos el valor de Y en función de la velocidad y el tiempo transcurrido
        offset.y += scrollSpeed * Time.deltaTime;

        // Asignamos el nuevo offset al material
        materialInstance.SetTextureOffset(texturePropertyName, offset);
    }
}
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ScrollBaseMapY : MonoBehaviour
{
    [Header("Velocidad de desplazamiento")]
    [SerializeField] private float scrollSpeed = 0.1f;
    [SerializeField] private string texturePropertyName = "_BaseMap";
    private Material materialInstance;
    private Vector2 offset;
    public float ScrollSpeed
    {
        get => scrollSpeed;
        set => scrollSpeed = value;
    }
    private void Start()
    {
        // Obtenemos el Renderer en este GameObject
        Renderer rend = GetComponent<Renderer>();
        if (rend == null)
        {
            Debug.LogError("No se encontró Renderer en " + gameObject.name);
            return;
        }
        
        materialInstance = new Material(rend.sharedMaterial);
        rend.material = materialInstance;
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
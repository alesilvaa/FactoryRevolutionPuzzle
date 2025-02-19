using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    [SerializeField] private List<GameObject> conveyors;
    [SerializeField] private List<ConveyorBehaviour> correctsConveyors;
    [SerializeField] private List<Transform> waypoints;
    
    [SerializeField] private float startY = 40f;             // Altura inicial de los conveyors
    [SerializeField] private float dropDuration = 0.2f;        // Duración de la animación de caída
    [SerializeField] private float delayBetweenDrops = 0.05f;   // Retardo entre la caída de cada conveyor

    void Start()
    {
        AnimateConveyor();
        CheckCorrectOrderByName();
    }

    private void AnimateConveyor()
    {
        float delay = 0f;
        foreach (GameObject conveyor in conveyors)
        {
            // Posicionar el conveyor en la altura inicial
            Vector3 pos = conveyor.transform.position;
            pos.y = startY;
            conveyor.transform.position = pos;
            
            // Animar la caída a Y=0 con un efecto de rebote (Ease.OutBounce)
            conveyor.transform.DOMoveY(0, dropDuration)
                .SetDelay(delay)
                .SetEase(Ease.InOutSine);
            
            delay += delayBetweenDrops; // Incrementar el retardo para el siguiente conveyor
        }
    }

    public void AddCorrectConveyor(ConveyorBehaviour conveyor)
    {
        correctsConveyors.Add(conveyor);    
        OrdenarConveyorsPorJerarquia();
    }

    public void RemoveCorrectConveyor(ConveyorBehaviour conveyor)
    {
        correctsConveyors.Remove(conveyor);
        OrdenarConveyorsPorJerarquia();
    }
    public void OrdenarConveyorsPorJerarquia()
    {
        // Ordena la lista según el índice de jerarquía de cada objeto
        correctsConveyors.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));
        
        // Verifica si el orden es el correcto y, de ser así, activa el panel de victoria.
        CheckCorrectOrder();
    }
    
    
    private void CheckCorrectOrder()
    {
        // Primero se verifica que ambas listas tengan la misma cantidad de elementos
        if (conveyors.Count != correctsConveyors.Count)
            return;
        
        // Se compara cada elemento en el mismo índice
        for (int i = 0; i < conveyors.Count; i++)
        {
            if (conveyors[i] != correctsConveyors[i].gameObject)
                return;
        }

        StartCoroutine(DelayShowWinPanel());

    }

    private IEnumerator DelayShowWinPanel()
    {
        yield return new WaitForSeconds(2);
        // Si se llega hasta aquí, ambas listas son iguales en cantidad y orden
        //qEventsManager.Instance.WinPanel();
    }
    
    private void CheckCorrectOrderByName()
    {
        
        // Compara cada objeto por su nombre
        for (int i = 0; i < conveyors.Count; i++)
        {
            if (conveyors[i].name != correctsConveyors[i].gameObject.name)
            {
                return;
            }
            else if (conveyors[i].name == correctsConveyors[i].gameObject.name)
            {
                Debug.Log($" primero {conveyors[i].name} y segundo {correctsConveyors[i].gameObject.name}");
                //correctsConveyors[i].IsReadyToScrolling();
            }
        }

        // Si se llega hasta aquí, todos los nombres coinciden
        StartCoroutine(DelayShowWinPanel());
    }
    
}

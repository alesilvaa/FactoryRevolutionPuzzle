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
        correctsConveyors.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));
    }
    
}

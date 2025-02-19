using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  // Asegúrate de tener DOTween instalado

public class UiWinLose : MonoBehaviour
{
    [SerializeField] private GameObject iconWinLose;
    [SerializeField] private GameObject BtnNextTryAgain;

    private void Start()
    {
        // Inicializamos las escalas a 0 para que no se vean al inicio
        iconWinLose.transform.localScale = Vector3.zero;
        BtnNextTryAgain.transform.localScale = Vector3.zero;
    }

    public void ShowWinLoseUI()
    {
        // Anima el icono: pasa de escala 0 a 1 en 0.5 segundos usando InOutSine
        iconWinLose.transform.DOScale(1f, 0.5f)
            .SetEase(Ease.InOutSine)
            .OnComplete(() =>
            {
                // Una vez que el icono aparece, animamos el botón de la misma forma
                BtnNextTryAgain.transform.DOScale(1f, 0.5f)
                    .SetEase(Ease.InOutSine)
                    .OnComplete(() =>
                    {
                        // Luego, el botón se queda en un bucle de escala para lograr un efecto "bounce"
                        BtnNextTryAgain.transform.DOScale(1.2f, 0.9f)
                            .SetEase(Ease.InOutSine)
                            .SetLoops(-1, LoopType.Yoyo);
                    });
            });
    }
}
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    private Tween _currentTween;
    private Vector3 _defaultScale; // variável que vai salvar amanho botão

    private void Awake() {
        _defaultScale = transform.localScale; // salvando tamanho botão
    }

    public float finalScale = 1.2f, scaleDuration = .1f;

    public void OnPointerEnter(PointerEventData eventData){
        Debug.Log("Enter");
        //transform.localScale = Vector3.one * 1.2f;
        _currentTween = transform.DOScale(_defaultScale * finalScale, scaleDuration);
    }

    public void OnPointerExit(PointerEventData eventData){
        Debug.Log("Exit");
        // matando o tween para quando usuária passar mouse muito rápido nos botos eles nao volta ao tamanho original pq nao deu tempo para ele sair do método OnPointerExit
        _currentTween.Kill();
        transform.localScale = _defaultScale; //set tamanho botão
    }
}
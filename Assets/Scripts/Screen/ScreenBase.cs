using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

namespace Screens{

    public enum ScreenType{
        Panel, Info_Panel, Shop
    }
    
    public class ScreenBase : MonoBehaviour{
        
        public ScreenType screenType;

        public List<Transform> listOfObjects;
        public List<Typper> listOfPhrases;

        public Image uiBackGround;
        public bool startHided = false;

        [Header("Animation")]
        public float animationDuration = .3f;
        public float delayBetweenObjects = .05f;

        private void Start(){

            if(startHided){
                HideObjects();
            }
        }

        [Button] // <-- utilizando essa declaração da NaughtyAttributes, declaração cria um botão quando for add
        public virtual void Show(){ // protected virtual e para se pode estender esta class ele poso acessar
            ShowObjects();
            Debug.Log("Show");
        }


        [Button] // <-- utilizando essa declaração da NaughtyAttributes, declaração cria um botão quando for add
        public virtual void Hide(){ // protected virtual e para se pode estender esta class ele poso acessar
            HideObjects();
            Debug.Log("Hide");
        }

        private void ShowObjects(){

            for (int i = 0; i < listOfObjects.Count; i++){

                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(StartType), delayBetweenObjects * listOfObjects.Count);
            uiBackGround.enabled = true;
        }

        private void StartType(){

            for (int i = 0; i < listOfPhrases.Count; i++){ // passando todo list frases
                listOfPhrases[i].StartType();
            }
        }

        private void ForceShowObjects(){
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
            uiBackGround.enabled = true;
        }

        private void HideObjects(){
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
            uiBackGround.enabled = false;
        }
    }
}
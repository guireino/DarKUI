using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

namespace Screens{
    
    public class ScreenManager : Singleton<ScreenManager>{

        private ScreenBase _currentBase;
        public List<ScreenBase> screenBases;

        public ScreenType startScreen = ScreenType.Panel;

        private void Start() {

            transform.Scale(2); // <-- Scale e da class SkullUtils
            gameObject.Scale(2); // <-- Scale e da class SkullUtils
            //screenBases.GetRandomButNotSame(ScreenType.Panel);

            HideAll();
            ShowByType(startScreen);
        }


        private void GetRandom(){
            screenBases[Random.Range(0, screenBases.Count)].animationDuration = 1; // Assim que gerar um numero ou item randômico dentro de um list
        }

        /*
        private void Scale(Transform t, float size = 1.2f){
            t.localScale = Vector3.one * size;
        }
        */

        public void ShowByType(ScreenType type){

            _currentBase?.Hide();

            var nextScreen = screenBases.Find(i => i.screenType == type);

            nextScreen.Show();
            _currentBase = nextScreen;
        }

        public void HideAll(){
            screenBases.ForEach(i => i.Hide());
        }

    }
}
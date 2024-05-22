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
            HideAll();
            ShowByType(startScreen);
        }

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

namespace Screens{
    
    public class ScreenHelper : MonoBehaviour{

        public ScreenType screenType;

        public void OnClick(){

            ScreenManager.Instance.ShowByType(screenType);
        }
    
    }
}
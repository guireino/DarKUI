using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkullUtils{


#if UNITY_EDITOR // <-- esse code e if significa so vai funcionar no editor

    [UnityEditor.MenuItem("Ebac/Test")] // <-- UnityEditor.MenuItem vai criar um botão no menu da unity
    public static void Test(){
        Debug.Log("Test");
    }

     [UnityEditor.MenuItem("Ebac/Test2 %g")] // <-- %g vai add tecla de atalho "contro g"
    public static void Test2(){
        Debug.Log("Test2");
    }

#endif

    public static void Scale(this Transform t, float size = 1.2f){
        t.localScale = Vector3.one * size;
    }

     public static void Scale(this GameObject g, float size = 1.2f){
        g.transform.localScale = Vector3.one * size;
    }

    public static void ScaleVector(this Vector3 v, float size = 1.2f){
        //t.localScale = Vector3.one * size;
    }

    #region RANDOM STUFF

    //public static Screens.ScreenBase GetRandom<Screens.ScreenBase>(this List<Screens.ScreenBase> list)

    // Assim que gerar um numero ou item randômico dentro de um array
    public static T GetRandom<T>(this T[] array){ // T e um object genérico

        if(array.Length == 0){ // verificando o tamanho array
            return default(T);
        }

        return array[Random.Range(0, array.Length)];
    }

    // Assim que gerar um numero ou item randômico dentro de um list
    public static T GetRandom<T>(this List<T> list){
        return list[Random.Range(0, list.Count)];
    }

    // Assim que gerar um numero ou item randômico dentro de um list ser repetir o mesmo valor
    public static T GetRandomButNotSame<T>(this List<T> list, T unique){

        if(list.Count == 1){ // verificando o tamanho list
            return unique;
        }

        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }

    #endregion

}
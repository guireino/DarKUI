using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Car))]
public class CarEditor : Editor{

    

    public override void OnInspectorGUI(){
        //base.OnInspectorGUI();
        Car myTarget = (Car)target;

        myTarget.carPrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.carPrefab, typeof(GameObject), true); // add cast pq typeof nao conseguir intender GameObject e transforma em GameObject
        myTarget.speed = EditorGUILayout.IntField("Minha Velocidade", myTarget.speed); // IntField vai na inspector na unity mostrar variável com name da variável
        myTarget.gear = EditorGUILayout.IntField("Marcha", myTarget.gear);

        EditorGUILayout.LabelField("Velocidade total", myTarget.TotalSpeed.ToString());
        EditorGUILayout.HelpBox("Calcule e velocidade total do carro!", MessageType.Info);

        if(myTarget.TotalSpeed > 200){
            EditorGUILayout.HelpBox("Velocidade acima do permitido!", MessageType.Error);
        }

        //myTarget.CreateCar();
        GUI.color = Color.blue;
        if (GUILayout.Button("Create Car")){
            myTarget.CreateCar();
        }


        GUI.color = Color.yellow;
        if (GUILayout.Button("Create Car")){
            myTarget.CreateCar();
        }

        //Debug.Log("Update GUI");
    }
}
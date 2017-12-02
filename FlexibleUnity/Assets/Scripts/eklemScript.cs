using UnityEngine;
using System.Collections;
using System.IO.Ports;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class eklemScript : MonoBehaviour {

    private Animator armsControllerAnim;
    private bool isSwing;
    private int counter = 0;
    private float timeCounter = 0.1f;
    SerialPort stream = new SerialPort("COM3", 9600);

	void Start () {
        armsControllerAnim = GetComponent<Animator>();
        stream.Open();
	}
	
	
	void Update () {
       
        if (stream.IsOpen)
        {
           
            string value = stream.ReadLine();
            int valueInt= int.Parse(value);
            Debug.Log(valueInt);
            float newFloat = valueInt * timeCounter;
            armsControllerAnim.Play("swing", -1,newFloat);
            armsControllerAnim.speed = 0.0f; 

        }
        
        if (Input.GetKey("up"))
        {
            counter++;
            if (counter > 5)
            {
                armsControllerAnim.speed = 0.0f;
            }
            armsControllerAnim.Play("swing");        
        }

	
	}
}

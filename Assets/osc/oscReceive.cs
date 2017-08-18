using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class oscReceive : MonoBehaviour {
    

	private string UDPHost = "127.0.0.1";
	private int listenerPort = 5001;
	private int broadcastPort = 57131;
	private Osc oscHandler;

	public float incomeValue = 0;


	void Start () {
		
		UDPPacketIO udp = GetComponent<UDPPacketIO>();
		udp.init(UDPHost,broadcastPort,listenerPort);
		oscHandler = GetComponent<Osc>();
		oscHandler.init(udp);
        oscHandler.SetAllMessageHandler(getInput);
	}


	void Update(){

	}

	public void getInput(OscMessage oscMessage) {
		OscMessage m = oscMessage;

		Osc.OscMessageToString(m);

		if (m.Address == "/soundVol") {
			incomeValue = (float)(m.Values [0]);
		} 

	}

//	public void getTouchingForehead(OscMessage oscMessage) {
//		Osc.OscMessageToString(oscMessage);
//		touchingForehead = (int)(oscMessage.Values [0]);
////		Debug.Log ("touching forehead: " + (int)(oscMessage.Values [0]));// Int32.Parse(oscMessage.Values[0]);
//	}
//
//	public void getBatteryPer(OscMessage oscMessage){
//		batteryPercentage = (int)oscMessage.Values[0];
//		batteryPercentage = CustomFunc.Map (batteryPercentage, 0, 10000, 0, 100);
////		Debug.Log ("battery%: "+ batteryPercentage);
//	}
//
//	public void getBlink(OscMessage oscMessage){
//		blink = (Boolean)oscMessage.Values[0];
//		Debug.Log (blink);
//	}


}

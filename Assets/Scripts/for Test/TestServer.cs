using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestServer : MonoBehaviour {

	private static TestServer _instance;
	public static TestServer Instance { get { return _instance; } }

	[HideInInspector]
	public List<double> latitude = new List<double>();
	[HideInInspector]
	public List<double> longitude = new List<double>();
	[HideInInspector]
	public List<string> text = new List<string>();

	void Awake(){
		_instance = this;
	}
}
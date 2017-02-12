using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	[SerializeField]
	SkinnedMeshExporter se;
	[SerializeField]
	SimpleMeshExporter e;


	[SerializeField]
	string fileName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("s")){
			se.StartRecord ();
		}else if(Input.GetKeyDown("p")){
			se.StopRecord ();
			se.Export (Application.streamingAssetsPath + "/" + fileName);
		}else if(Input.GetKeyDown("e")){
			e.Export (Application.streamingAssetsPath + "/" + fileName);
		}
	}
}

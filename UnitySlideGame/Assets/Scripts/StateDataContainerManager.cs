using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDataContainerManager : SimpleMonoBehaviourSingleton<StateDataContainerManager> {

	public GameObject MoveObject { get; set; }
	
	public GameObject StartObject { get; set; }
	
	public GameObject EndObject { get; set; }
	
	// なぞって当たることで獲得できるオブジェクトのリスト
	public List<GameObject> PostObjectList { get; set; }

}

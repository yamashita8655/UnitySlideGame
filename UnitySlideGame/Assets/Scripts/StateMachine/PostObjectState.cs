using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostObjectState : StateBase {
	/// <summary>
	/// 初期化後処理.
	/// </summary>
	override public void OnAfterInit()
	{
		List<GameObject> list = StateDataContainerManager.Instance.PostObjectList;

		//for (int i = 0; i < 3; i++) {
		//	list.Add();
		//}
	}

	/// <summary>
	/// メイン更新処理.
	/// </summary>
	/// <param name="delta">経過時間</param>
	override public void OnUpdateMain(float delta)
	{
	}

	/// <summary>
	/// メイン後処理.
	/// </summary>
	override public void OnAfterMain()
	{
	}

	/// <summary>
	/// ステート解放時処理.
	/// </summary>
	override public void OnRelease()
	{
	}
}

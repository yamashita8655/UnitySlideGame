﻿/*
 * @file StateMachineManager_define.cs
 * ステートマシンの種類を記載する定義クラス.
 * @author 山下
 */

using UnityEngine;
using System.Collections;

/// <summary>
///	ステートマシンの種類を記載する定義クラス.
/// </summary>
public enum StateMachineName : int
{
	Test,
	InGame,
	Max,
};

/// <summary>
///	ステート名
/// </summary>
public enum StateNumber : int
{
	DrawLine,
	MoveObject,
};


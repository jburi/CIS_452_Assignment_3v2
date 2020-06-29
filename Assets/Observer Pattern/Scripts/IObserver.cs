/*
* Jake Buri
* IObserver.cs
* Assignment 3
* Observer Interface
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
	//Methods
	void UpdateSubject(ISubject subject);
}

/*
* Jake Buri
* ISubject.cs
* Assignment 3
* Subject Interface
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
	//Methods
	void Attach(IObserver observer);
	void Detach(IObserver observer);
	void Notify();
}

using UnityEngine;
using System.Collections;
using Universe.Core.DependencyInjection;


public class TestIocBehaviour : MonoBehaviour {

    [Dependency]
    public IInjectedClass injectedClass { get; private set; }

	// Use this for initialization
	void Start () {
        this.Inject();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(injectedClass.TheString);
	}
}

using UnityEngine;

namespace Universe.Core.DependencyInjection
{
	public abstract class AbstractBootstrapper : MonoBehaviour
	{
		void Awake ()
		{
			DontDestroyOnLoad (this.gameObject);

			var container = new Unity3dIoCContainer ();
	
			container.SetSingletonGameObject (this.gameObject.name);
			MonobehaviourExtensions.SetDependencyInjector (container);
			this.Configure (container);
		}
	
		public abstract void Configure (IIoCContainer container);
	}
}

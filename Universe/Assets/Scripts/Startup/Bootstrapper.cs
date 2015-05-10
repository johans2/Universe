using UnityEngine;
using System.Collections;
using Universe.Core.DependencyInjection;
using Universe.Game;

public class Bootstrapper : AbstractBootstrapper
{
	public override void Configure(IIoCContainer container)
	{
        container.Register<IGameConstants, GameConstants>();
        container.Register<ISpaceCraft, SpaceCraft>();

		// Example code
		/*
		// non  singleton
		container.Register<IColorItem, ColorItem>();
		
		// singletons
		
		// multiple  implementations
		container.RegisterSingleton<IColorFactory, RedColorFactory>("red");
		container.RegisterSingleton<IColorFactory, GreenColorFactory>("green");
		container.RegisterSingleton<IColorFactory, BlueColorFactory>("blue");
		
		// monobehaviour
		container.RegisterSingleton<IColorHistory, ColorHistory>();
		*/
	}
}
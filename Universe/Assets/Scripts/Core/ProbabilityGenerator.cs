using System;
using System.Collections.Generic;
using System.Linq;
using Universe.Core.Collections;

namespace Universe.Core.Generation
{
	public static class ProbabilityGenerator
	{
		/// <summary>
		/// Generates the intervalls for each IProbabilityItem. A random number created form Randomgenerator will be used to check against these intervals.
		/// </summary>
		/// <returns>
		/// returns a dictionary containing the IProbabilityItem (key) and a Tuple of two integers (value) representing the start and stop of the interval.
		/// </returns>
		/// <param name='items'>
		/// The IProbabilityItems to create intervals for.
		/// </param>
		/// <param name='totalInterval'>
		/// The top of the interval (eg. 1000 for intervals between 0-1000).
		/// </param>
		public static Dictionary<IProbabilityItem, Tuple<int,int>> GenerateIntervalls(List<IProbabilityItem> items, int totalInterval) 
		{
			Dictionary<IProbabilityItem, Tuple<int,int>> intervalCollection = new Dictionary<IProbabilityItem, Tuple<int, int>>();
			
			// Get the sum of all the relative probabilitites.
			double totalProbability = items.Sum(x => x.RelativeProbability);
			
			// Set interval start.
			int currentIntervalStart = 0;
			
			foreach (IProbabilityItem item in items) 
			{
				// Get the probability of the item relative the total probability.
				double itemProbability = item.RelativeProbability / totalProbability;
				
				// Calculate the length of the interval for the item.
				int intervalLength = (int)(Math.Floor(totalInterval * itemProbability));
				
				// Add item, currentIntervalStart and intervalLength to the dictionary. 
				intervalCollection.Add(item, new Tuple<int, int>(currentIntervalStart, currentIntervalStart + intervalLength));
				
				// Set a new currentIntervalStart for the next item in the loop.
				currentIntervalStart = currentIntervalStart + intervalLength;
			}
			
			return intervalCollection;
		}
	
	}
}


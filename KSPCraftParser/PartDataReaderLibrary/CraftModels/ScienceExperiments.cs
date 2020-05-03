using PartDataReaderLibrary.Exceptions;
using PartDataReaderLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.CraftModels
{
    public class ScienceExperiments : IJson
	{
		#region - Fields & Properties
		public List<ScienceModel> Experiments { get; set; }
		public List<string> CrewExperiments { get; set; }
		#endregion

		#region - Constructors
		public ScienceExperiments( ) { }
		#endregion

		#region - Methods
		public void SortExperiments( Craft craft )
		{
			craft.Experiments.AddRange(FindExperiment(craft.Science));
			craft.Experiments.AddRange(FindExperiment(craft.Scanners));

			foreach (var part in craft.CommandPods)
			{
				if (part.GetValue("Crewed"))
				{
					foreach (var expName in CrewExperiments)
					{
						craft.Experiments.Add(GetExperiment(expName));
					}
					break;
				}
			}
		}

		private List<ScienceModel> FindExperiment( List<Part> parts )
		{
			List<ScienceModel> output = new List<ScienceModel>();

			foreach (var part in parts)
			{
				try
				{
					var experiment = part.GetValue("ScienceExp");
					foreach (var exp in Experiments)
					{
						if (experiment == exp.Name)
						{
							output.Add(exp);
							break;
						}
					}
				}
				catch (PartNotFoundException e) { }
				catch (Exception e)
				{
					throw e;
				}
				
			}

			return output;
		}

		public ScienceModel GetExperiment( string name )
		{
			ScienceModel output = null;
			foreach (var exp in Experiments)
			{
				if (exp.Name == name)
				{
					output = exp;
					break;
				}
			}
			return output;
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}

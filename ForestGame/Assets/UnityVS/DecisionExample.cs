using System;

namespace AssemblyCSharp
{
	public class DecisionExample
	{
		private Decision decision;
		private Influences influences;

		public DecisionExample ()
		{
			
		}

		public Decision Decision1(){
			return DecisionExp (1, "We want to clearcut 4 fields of old forest. \n Income: 10000K if lable, 11000K if lable", new Influences(5,2,5));
		}
		public Decision Decision2(){
			return DecisionExp (1, "Clearcut? That will keep our guests away! Please choose selective cut!. \n Income: 6000K, 6600K if lable", new Influences(5,2,5));
		}

		void DecisionExp(int factionId = decision.setFactionID, string requestText = decision.setRequestText, Influences influences = default(Influences)){
			decision.setInfluences (influences);
	
		}

		void InfluenceExp(byte envInfluence, byte indInfluence, byte touInfluence){
			influences.setEnvironmentalInfluence(envInfluence);
			influences.setIndustrialInfluence(indInfluence);
			influences.setTouristicalInfluence(touInfluence);
		}
	}
}


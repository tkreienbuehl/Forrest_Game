using System;
using System.Collections;

namespace AssemblyCSharp
{
	public class DecisionExample
	{
		private Decision decision;
		private Influences influences;

		public DecisionExample ()
		{
			
		}

        public ArrayList GetDecision(ArrayList decisions) {

            ArrayList decArray = new ArrayList();

            Influences influences1 = new Influences();
            influences1.setEnvironmentalInfluence(10);
            influences1.setIndustrialInfluence(2);
            influences1.setTouristicalInfluence(5);

            Decision decision1 = new Decision(1);
            decision1.setFactionID(1);
            decision1.setInfluences(influences1);
            decision1.setRequestText("We want to clearcut 4 fields of old forest. \n Income: 10000K if lable, 11000K if lable");

            Influences influences2 = new Influences();
            influences2.setEnvironmentalInfluence(5);
            influences2.setIndustrialInfluence(2);
            influences2.setTouristicalInfluence(5);

            Decision decision2 = new Decision(1);
            decision2.setFactionID(1);
            decision2.setInfluences(influences2);
            decision2.setRequestText("Clearcut? That will keep our guests away! Please choose selective cut!. \n Income: 6000K, 6600K if lable");

            decArray.Add(decision1);
            decArray.Add(decision2);

            return decArray;

        }
	}
}


﻿
public class DecisionExample
{
	private Decision decision;
	private Influences influences;

	public DecisionExample ()
	{
        influences = new Influences();
        decision = new Decision(1);
	}

	public Decision Decision1(){
        InfluenceExp(-5, 5, -2);
		return DecisionExp(1, "We want to clearcut 4 fields of old forest. \n Income: 10000K if lable, 11000K if lable");
	}
	public Decision Decision2(){
        InfluenceExp(-2, -2, 2);
        return DecisionExp(2, "Clearcut? That will keep our guests away! Please choose selective cut!. \n Income: 6000K, 6600K if lable");
	}

    public Decision SingleDecision() {
        InfluenceExp(3, 3, 3);
        return DecisionExp(4, "Mayor, let us build a more modern hospital to increise health level in town");
    }

	Decision DecisionExp(short factionId, string requestText){
		decision.setInfluences(influences);
        decision.setRequestText(requestText);
        decision.setFactionID(factionId);
        return decision;
	}

	void InfluenceExp(short envInfluence, short indInfluence, short touInfluence){
		influences.setEnvironmentalInfluence(envInfluence);
		influences.setIndustrialInfluence(indInfluence);
		influences.setTouristicalInfluence(touInfluence);
	}
}

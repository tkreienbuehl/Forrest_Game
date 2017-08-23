using UnityEngine;
using UnityEngine.UI;

public class Party : MonoBehaviour
{
    public static int partyID;
    public static int sloganID;
    public static float industry;
    public static float tourism;
    public static float nature;

	private string party_name;
	private string slogan;

    public float getIndustry() {
        return industry;
    }

    public float getTourism() {
        return tourism;
    }

    public float getNature() {
        return nature;
    }

    public void setParty(int id) {
        partyID = id;
    }

	public void SetSlogan(string input){
		slogan = input;
	}

	public string GetSlogan(){
		return slogan;
	}

	public string GetPartyName(){
		
		string name = "";

		// checks which party the id belongs to
		if (partyID == 1) {
			name = "Conservative party";
		} else if (partyID == 2) {
			name = "Democratic party";
		} else if (partyID == 3) {
			name = "Environment party";
		}
		return name;
	}

    public void getBasicValue() {

        if (partyID == 1) { //industry

            industry    = 60;
            tourism     = 50;
            nature      = 40;

        } else if (partyID == 2) { //Tourism

            industry = 40;
            tourism = 60;
            nature = 50;

        } else if (partyID == 3) { //Enviroment

            industry = 40;
            tourism = 50;
            nature = 60;

        }
    }
   
}
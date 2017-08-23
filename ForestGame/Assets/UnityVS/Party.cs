using UnityEngine;
using UnityEngine.UI;

public class Party : MonoBehaviour
{
    public static int partyID;
    public static int sloganID;
    public static float industry;
    public static float tourism;
    public static float nature;

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
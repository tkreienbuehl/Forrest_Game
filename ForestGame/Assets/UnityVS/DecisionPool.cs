using System;
using System.Collections;
using System.Collections.Generic;

public class DecisionPool : IDecisionPool {

    //Area for global Variables
    private static IDictionary Decissions = new Dictionary<int, int>();
    private Database db;
    private static bool useStub = false;

    public DecisionPool() {
        //instance of db class.
        db = new Database();
    }

    private int SelectRandomID()
    {
        //gobal value
        int returnID = 0;
        Boolean badid = true;

        // get value array from database class
        int[] ID = db.GetidArray();

        while (badid){

            int extractNumber = ID[getRandom(ID)];

            if (Decissions.Contains(extractNumber)){

                int amount = Convert.ToInt32(Decissions[extractNumber]);
                if (amount == 10){

                    //can reuse the ecission.
                    amount = 1;
                    Decissions[extractNumber] = amount;
                    badid = false;
                } else {
                    amount += 1;
                    Decissions[extractNumber] = amount;
                }
            } else {
                // add the decission to the map.
                Decissions.Add(extractNumber, 1);
                badid = false;
            }
            returnID = extractNumber;   
        }
        return returnID;
    }
    private int getRandom(int[] list) {
        //select a random id from the array
        Random rm = new Random();
        return rm.Next(0, list.Length);

    }

    public Pair<IDecision, IDecision> getDecisionPair()
    {
        if (useStub) {
            DecisionExample ex = new DecisionExample();
            return new Pair<IDecision, IDecision>(ex.Decision1(), ex.Decision2());
        }
        else {
            IDecision desc1 = db.get_descision(SelectRandomID());
            IDecision desc2 = db.get_descision(SelectRandomID());
            return new Pair<IDecision, IDecision>(desc1, desc2);
        }
    }

    public IDecision getDecision()
    {
        // TODO get decisions
        DecisionExample ex = new DecisionExample();
        return ex.SingleDecision();
    }
}

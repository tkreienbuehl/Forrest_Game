
using System;
using System.Collections;
using System.Collections.Generic;

public class DecisionPool : IDecisionPool {

    //Area for global Variables
    private static IDictionary decisions = new Dictionary<int, int>();
    private Database db;
    private static bool useStub = false;

    public DecisionPool() {
        //instance of db class.
        db = new Database();
    }

    private int SelectRandomID(bool pairDecisionAsked) {
        //gobal value
        int returnID = 0;
        Boolean badid = true;

        // get value array from database class
        int[] id = { 0 };
        if (pairDecisionAsked) {
            id = db.getPairRequestIDs();
        }
        else {
            id = db.getSingleDecisionsIDs();
        }

        while (badid) {

            int extractNumber = id[getRandom(id)];

            if (decisions.Contains(extractNumber)) {

                int amount = Convert.ToInt32(decisions[extractNumber]);
                if (amount == 10) {

                    //can reuse the decision.
                    amount = 1;
                    decisions[extractNumber] = amount;
                    badid = false;
                }
                else {
                    amount += 1;
                    decisions[extractNumber] = amount;
                }
            }
            else {
                // add the decission to the map.
                decisions.Add(extractNumber, 1);
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

    public Pair<IDecision, IDecision> getDecisionPair() {
        if (useStub) {
            DecisionExample ex = new DecisionExample();
            return new Pair<IDecision, IDecision>(ex.Decision1(), ex.Decision2());
        }
        else {
            int requestID = SelectRandomID(true);
            IDecision desc1 = db.get_descision(requestID);
            IDecision desc2 = db.get_descision(db.getOpponentID(requestID));
            return new Pair<IDecision, IDecision>(desc1, desc2);
        }
    }

    public IDecision getDecision() {
        if (useStub) {
            DecisionExample ex = new DecisionExample();
            return ex.SingleDecision();
        }
        else {
            return db.get_descision(SelectRandomID(false));
        }

    }
}
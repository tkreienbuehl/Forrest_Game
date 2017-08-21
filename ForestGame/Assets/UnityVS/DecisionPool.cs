using System;
using System.Collections;
using System.Collections.Generic;

public class DecisionPool : IDecisionPool {

    //Area for global Variables
    private static IDictionary Decissions = new Dictionary<int, int>();

    private int SelectRandomID()
    {
        //gobal value
        int returnID = 0;
        Boolean badid = true;

        //instance of other classes.
        Database db = new Database();

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

    //public Pair<IDecision, IDecision> getDecisionPair()
    //{
    //    AssemblyCSharp.DecisionExample ex = new AssemblyCSharp.DecisionExample();
    //   return new Pair<IDecision, IDecision>(ex.Decision1(), ex.Decision2());
    //}

    public IDecision getDecision()
    {
        // TODO get decisions
        throw new NotImplementedException();
    }

    public Pair<IDecision, IDecision> getDecisionPair()
    {
        throw new NotImplementedException();
    }
}

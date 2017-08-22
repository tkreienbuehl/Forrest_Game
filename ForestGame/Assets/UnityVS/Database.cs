using System;
using System.Data;
using System.Data.SqlClient;

public class Database {
    private static String connStr = "data source=81.169.245.35;initial catalog=forestGameDb;uid=User;pwd=Pass12@;";

    //get all ID's from requests with an opponent
    public int[] getPairRequestIDs() {
        return sqlGetRequestIDs(true);
    }

    //get opponent id chosen by request id
    public int getOpponentID(int requestID) {
        return sqlGetOpponentID(requestID);
    }

    // get the id from all the id from decisions.
    public int[] getSingleDecisionsIDs() {
        return sqlGetRequestIDs(false);
    }

    // get the id's from all pair decisions requests.
    private int[] sqlGetRequestIDs(bool pairRequestsOnly) {
        int[] list = new int[2];

        //This is your database connection:
        SqlConnection cn = new SqlConnection(connStr);
        string command;

        if (pairRequestsOnly) {
            command = "SELECT DECISION_ID FROM DECISION JOIN (SELECT * FROM OPPONENT WHERE fk_OPPONENT_ID != 0) AS OPP ON DECISION_ID = OPP.fk_REQUEST_ID"; //tested query on DB
        }
        else {
            command = "SELECT DECISION_ID " +
                        "FROM DECISION D " +
                        "WHERE NOT EXISTS " +
                        "(SELECT * FROM OPPONENT OP WHERE D.DECISION_ID = OP.fk_OPPONENT_ID OR D.DECISION_ID = OP.fk_REQUEST_ID)"; //tested query on DB
        }

        try {
            //Open the sql connection.
            cn.Open();

            //send the command string to sql
            SqlDataAdapter da = new SqlDataAdapter(command, cn);
            DataTable dataTable = new DataTable();

            //get the results.
            int recordsAffected = da.Fill(dataTable);
            list = new int[recordsAffected];

            if (recordsAffected > 0) {
                int i = 0;
                foreach (DataRow dr in dataTable.Rows) {
                    list[i] = Convert.ToInt32(dr["DECISION_ID"]);
                    i++;
                }
            }
        }
        catch (SqlException sqlEx) {

            if (sqlEx.Message != null || sqlEx.Message != string.Empty) { list[0] = 4004; }

        }
        finally {
            cn.Close();
        }


        return list;
    }

    private int sqlGetOpponentID(int requestID) {
        int retID = 0;

        //This is your database connection:
        SqlConnection cn = new SqlConnection(connStr);

        string command = "SELECT fk_OPPONENT_ID FROM OPPONENT WHERE fk_REQUEST_ID =" + requestID;

        try {
            //Open the sql connection.
            cn.Open();
            if (cn.State == ConnectionState.Open) {

                //send the command string to sql
                SqlDataAdapter da = new SqlDataAdapter(command, cn);
                DataTable dataTable = new DataTable();

                //get the results.
                da.Fill(dataTable);

                if (da != null) {
                    foreach (DataRow dr in dataTable.Rows) {
                        retID = (Convert.ToInt16(dr["fk_OPPONENT_ID"]));
                    }
                }
            }
        }
        catch (SqlException sqlEx) {
            if (sqlEx.Message != null || sqlEx.Message != string.Empty) { retID = 0; }
        }
        finally {
            cn.Close();
        }
        return retID;
    }

    // get a singl decission selected with a id
    public Decision get_descision(int id) {

        Decision dc = new Decision(id);
        dc = sql_get_Decission(id);
        dc.setInfluences(sql_get_influences(id));
        return dc;
    }

    private Decision sql_get_Decission(int id) {

        Decision dc = new Decision(id);

        //This is your database connection:
        SqlConnection cn = new SqlConnection(connStr);

        string command = "SELECT TEXT, fk_FACTION_ID, ACTION_ID, BRIBE, NR_OF_FIELDS FROM DECISION WHERE DECISION_ID=" + id;

        try {
            //Open the sql connection.
            cn.Open();
            if (cn.State == ConnectionState.Open) {

                //send the command string to sql
                SqlDataAdapter da = new SqlDataAdapter(command, cn);
                DataTable dataTable = new DataTable();

                //get the results.
                da.Fill(dataTable);

                if (da != null) {
                    foreach (DataRow dr in dataTable.Rows) {
                        dc.setRequestText(dr["TEXT"].ToString());
                        dc.setFactionID(Convert.ToInt16(dr["fk_FACTION_ID"]));
                        dc.setIsBribe(Convert.ToBoolean(dr["BRIBE"]));
                        dc.setActionID(Convert.ToInt16(dr["ACTION_ID"]));
                        dc.setNrOfFieldsAffected(Convert.ToInt16(dr["NR_OF_FIELDS"]));
                    }
                }
            }
        }
        catch (SqlException sqlEx) {
            if (sqlEx.Message != null || sqlEx.Message != string.Empty) { dc.setRequestText(sqlEx.Message); }
        }
        finally {
            cn.Close();
        }
        return dc;

    }

    private Influences sql_get_influences(int id) {

        Influences infl = new Influences();

        //This is your database connection:
        SqlConnection cn = new SqlConnection(connStr);

        //ned the change thinggy 
        string command = "SELECT INFLUENCE.fk_INFLUENCE_TYPE, INFLUENCE.VALUE, DECISION.fk_FACTION_ID, MONETARY_INFLUENCES.INCOME, MONETARY_INFLUENCES.YEARLY_COST\n" +
            "FROM INFLUENCE\n" +
            "INNER JOIN CONNECTED_INFLUENCE on CONNECTED_INFLUENCE.fk_INFLUENCE_ID = INFLUENCE.INFLUENCE_ID\n" +
            "INNER JOIN DECISION on CONNECTED_INFLUENCE.fk_DECISION_ID = DECISION.DECISION_ID\n" + 
            "INNER JOIN MONETARY_INFLUENCES on CONNECTED_INFLUENCE.fk_MONETARY_INFLUENCE = MONETARY_INFLUENCES.MONETARY_INFLUENCES_ID\n" + 
            "WHERE DECISION.DECISION_ID = " + id; //tested

        try {
            //Open the sql connection.
            cn.Open();

            //send the command string to sql
            SqlDataAdapter da = new SqlDataAdapter(command, cn);
            DataTable dataTable = new DataTable();

            //get the results.
            da.Fill(dataTable);

            if (cn.State == ConnectionState.Open) {
                foreach (DataRow dr in dataTable.Rows) {

                    int value = Convert.ToInt32(dr["value"]);
                    int faction = Convert.ToInt32(dr["fk_INFLUENCE_TYPE"]);
                    infl.setIncomeInfluence(Convert.ToDouble(dr["income"]));
                    infl.setCostYearlyInfluence(Convert.ToDouble(dr["yearly_cost"]));

                    if (faction == 1) {
                        //facction id 1 == industry
                        infl.setIndustrialInfluence(Convert.ToInt16(value));
                    }
                    else if (faction == 2) {
                        //faction id 2 == toerisme
                        infl.setTouristicalInfluence(Convert.ToInt16(value));
                    }
                    else if (faction == 3) {
                        //faction id 3 == envoirment
                        infl.setEnvironmentalInfluence(Convert.ToInt16(value));
                    }
                }
            }
        }
        catch (SqlException sqlEx) {
            if (sqlEx.Message != null || sqlEx.Message != string.Empty) { }
        }
        finally {
            cn.Close();
        }
        return infl;

    }
}
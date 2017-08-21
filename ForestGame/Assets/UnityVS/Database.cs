using System;
using System.Data;
using System.Data.SqlClient;

public class Database
{
    private static String db    = "81.169.245.35";
    private static String user  = "forestGameDb";
    private static String pass  = "User";
    private static String name  = "Pass12@";


    public int[] GetidArray() {
        return new int[10];
    }

    // get the id from all the id from decissions.
    public int[] get_id() {
        return sql_getID();
    }

    // get a singl decission selected with a id
    public Decision get_descision(int id) {

        Decision dc = new Decision(id);
        dc = sql_get_Decission(id);
        dc.setInfluences(sql_get_influences(id));
        return dc;
    }

    private int[] sql_getID() {

        int[] list = new int[2];

        //This is your database connection:
        string connectionString = "data source=81.169.245.35;initial catalog=forestGameDb;uid=User;pwd=Pass12@;";
        SqlConnection cn = new SqlConnection(connectionString);

        string command = "SELECT DECISION_ID FROM DECISION";

        try {
            //Open the sql connection.
            cn.Open();

            //send the command string to sql
            SqlDataAdapter da = new SqlDataAdapter(command, cn);
            DataTable dataTable = new DataTable();

            //get the results.
            int recordsAffected = da.Fill(dataTable);
            list = new int[recordsAffected];

            if (recordsAffected > 0)
            {
                int i = 0;
                foreach (DataRow dr in dataTable.Rows)
                {
                    list[i] = Convert.ToInt32(dr["DECISION_ID"]);
                    i++;
                }
            }



        }
        catch (SqlException sqlEx) {

            if(sqlEx.Message != null || sqlEx.Message != string.Empty) { list[0] = 4004; }
            
        } finally {
            cn.Close();
        }


        return list;
    }

    private Decision sql_get_Decission(int id){

        Decision dc = new Decision(id);

        //This is your database connection:
        string connectionString = "data source=81.169.245.35;initial catalog=forestGameDb;uid=User;pwd=Pass12@;";
        SqlConnection cn = new SqlConnection(connectionString);

        string command = "SELECT TEXT,fk_FACTION_ID FROM DECISION WHERE DECISION_ID="+ id;

            try {
                //Open the sql connection.
                cn.Open();

                //send the command string to sql
                SqlDataAdapter da = new SqlDataAdapter(command, cn);
                DataTable dataTable = new DataTable();

                //get the results.
                int recordsAffected = da.Fill(dataTable);

                if (recordsAffected > 0) {
                    foreach (DataRow dr in dataTable.Rows) {
                        dc.setRequestText(dr["TEXT"].ToString());
                        dc.setFactionID(Convert.ToInt16(dr["fk_FACTION_ID"]));
                    }
                }
            } catch (SqlException sqlEx){
                if (sqlEx.Message != null || sqlEx.Message != string.Empty) { dc.setRequestText(sqlEx.Message); }
            } finally {
                cn.Close();
            }
        return dc;

    }

    private Influences sql_get_influences(int id) {

        Influences infl = new Influences();

        //This is your database connection:
        string connectionString = "data source=81.169.245.35;initial catalog=forestGameDb;uid=User;pwd=Pass12@;";
        SqlConnection cn = new SqlConnection(connectionString);

        //ned the change thinggy 
        string command = "SELECT INFLUENCE.VALUE,DECISION.fk_FACTION_ID FROM INFLUENCE INNER JOIN CONNECTED_INFLUENCE on CONNECTED_INFLUENCE.fk_INFLUENCE_ID = UNFLUENCE.INFLUENCE_ID INNER JOIN DECISION on CONNECTED_INFLUENCE.fk_DECISION_ID = DECISION.DECISION_ID WHERE DECISION.DECISION_ID =" + id;

        try {
            //Open the sql connection.
            cn.Open();

            //send the command string to sql
            SqlDataAdapter da = new SqlDataAdapter(command, cn);
            DataTable dataTable = new DataTable();

            //get the results.
            int recordsAffected = da.Fill(dataTable);

            if (recordsAffected > 0) {
                foreach (DataRow dr in dataTable.Rows) {

                    int value   = Convert.ToInt32(dr["value"]);
                    int faction = Convert.ToInt32(dr["faction_id"]);

                    if (faction == 1) {
                        //facction id 1 == industry
                        infl.setIndustrialInfluence(Convert.ToByte(value));
                    } else if (faction == 2) {
                        //faction id 2 == toerisme
                        infl.setTouristicalInfluence(Convert.ToByte(value));
                    } else if (faction == 3) {
                        //faction id 3 == envoirment
                        infl.setEnvironmentalInfluence(Convert.ToByte(value));
                    }
                }
            }
        }
        catch (SqlException sqlEx)
        {
            if (sqlEx.Message != null || sqlEx.Message != string.Empty) { }
        }
        finally
        {
            cn.Close();
        }
        return infl;

    }
}
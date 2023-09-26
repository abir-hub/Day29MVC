using System;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_ADO
{
    public class CRUD
    {
        public static Boolean chkValidity(string uname, string pass)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-O7LF2JA;Initial Catalog=training;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from loginTbl", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString("uname").Equals(uname) && rdr.GetString("passwd").Equals(pass))
                        return true;
                }

            }
            catch (Exception e) { return false; }
            return false;
        }
        public static Boolean chkAdmin(string uname, string pass)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-O7LF2JA;Initial Catalog=training;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from loginTbl", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (uname=="admin" && pass == "CSharp")
                        return true;
                }

            }
            catch (Exception e) { return false; }
            return false;
        }
       

        public static Boolean insertValue(string name, string uname, string pass)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-O7LF2JA;Initial Catalog=training;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into loginTbl (name, uname, passwd) values(@name, @uname, @pass)", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@pass", pass);

                int r = cmd.ExecuteNonQuery();
                //Console.WriteLine("Number of rows inserted: " + recIns);

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e) { return false; }
            return false;
        }




        public static Boolean updateValidity(string name, string oldPass, string newPass, string confPass)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-O7LF2JA;Initial Catalog=training;Integrated Security=True");
                con.Open();
                if (newPass == confPass)
                {
                    SqlCommand cmd = new SqlCommand("Update loginTbl set passwd=@newPass where name=@name and passwd=@oldPass", con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@newPass", newPass);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@oldPass", oldPass);
                    int recUp = cmd.ExecuteNonQuery();
                    //Console.WriteLine("Number of Records Updated : " + recUp);
                    if (recUp > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e) { return false; }
            return false;
        }


        public static Boolean deleteValidity(string name, string uname, string pass)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-O7LF2JA;Initial Catalog=training;Integrated Security=True");
                con.Open();

                SqlCommand cmd = new SqlCommand("Delete from loginTbl where name=@name and passwd=@pass and uname=@uname" , con);
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@pass", pass);

                int recUp = cmd.ExecuteNonQuery();
                //Console.WriteLine("Number of Records Updated : " + recUp);
                if (recUp > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e) { return false; }
            return false;
        }
    
    }
}
